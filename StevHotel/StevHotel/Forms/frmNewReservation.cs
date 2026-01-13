using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmNewReservation : Form
    {
        private readonly HotelDbContext _db;
        private Guest _selectedGuest;

        public frmNewReservation()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmNewReservation_Load(object sender, EventArgs e)
        {
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(3);

            lblTotalPrice.Text = "";
            lblNights.Text = "Nights: 0";
        }

        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            string search = txtGuestSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                MessageBox.Show("Enter guest name or phone to search.");
                return;
            }

            var guests = _db.Guests
                .Where(g =>
                    g.FullName.Contains(search) ||
                    g.Phone.Contains(search) ||
                    (g.NationalID != null && g.NationalID.Contains(search)))
                .Take(20)
                .ToList();

            dgvGuests.DataSource = guests.Select(g => new
            {
                g.GuestID,
                g.FullName,
                g.Phone,
                g.NationalID,
                g.Email
            }).ToList();

            if (dgvGuests.Columns["GuestID"] != null)
                dgvGuests.Columns["GuestID"].Visible = false;

            if (guests.Count == 0)
                MessageBox.Show("No guests found. Add new guest first.");
        }

        private void dgvGuests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count == 0)
                return;

            int guestId = (int)dgvGuests.SelectedRows[0].Cells["GuestID"].Value;
            _selectedGuest = _db.Guests.Find(guestId);

            if (_selectedGuest != null)
            {
                txtGuestSearch.Text = $"{_selectedGuest.FullName} ({_selectedGuest.Phone})";
                UpdateAvailableRooms();
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);

            UpdateAvailableRooms();
            UpdateNightsAndPrice();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);

            UpdateAvailableRooms();
            UpdateNightsAndPrice();
        }

        private void UpdateNightsAndPrice()
        {
            int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
            lblNights.Text = $"Nights: {nights}";

            if (cmbAvailableRooms.SelectedItem == null || cmbAvailableRooms.SelectedValue is not int roomId || roomId == 0)
            {
                lblTotalPrice.Text = "";
                return;
            }

            var room = _db.Rooms
                .Include(r => r.RoomType)
                .FirstOrDefault(r => r.RoomID == roomId);

            if (room != null)
            {
                decimal total = nights * room.RoomType.PricePerNight;
                lblTotalPrice.Text = $"Estimated Total: {total:N2} USD";
            }
        }

        private void UpdateAvailableRooms()
        {
            cmbAvailableRooms.DataSource = null;
            cmbAvailableRooms.Enabled = false;

            if (_selectedGuest == null)
            {
                lblAvailableRooms.Text = "Available Rooms: (Select guest first)";
                return;
            }

            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;

            var bookedRoomIds = _db.Reservations
                .Where(r => r.Status != "Cancelled"
                    && r.CheckInDate < checkOut
                    && r.CheckOutDate > checkIn)
                .Select(r => r.RoomID)
                .ToList();

            var availableRooms = _db.Rooms
                .Include(r => r.RoomType)
                .Where(r => r.Status == "Available" && !bookedRoomIds.Contains(r.RoomID))
                .Select(r => new
                {
                    r.RoomID,
                    Display = $"{r.RoomNumber} - {r.RoomType.TypeName} (${r.RoomType.PricePerNight:N2}/night)"
                })
                .ToList();

            if (availableRooms.Count == 0)
            {
                cmbAvailableRooms.DataSource = new[]
                {
                    new { RoomID = 0, Display = "No available rooms for these dates" }
                };
                cmbAvailableRooms.DisplayMember = "Display";
                cmbAvailableRooms.ValueMember = "RoomID";
                cmbAvailableRooms.Enabled = false;
            }
            else
            {
                cmbAvailableRooms.DataSource = availableRooms;
                cmbAvailableRooms.DisplayMember = "Display";
                cmbAvailableRooms.ValueMember = "RoomID";
                cmbAvailableRooms.Enabled = true;
            }
        }

        private void cmbAvailableRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNightsAndPrice();
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            if (_selectedGuest == null)
            {
                MessageBox.Show("Please select a guest first.");
                return;
            }

            if (cmbAvailableRooms.SelectedValue is not int roomId || roomId == 0)
            {
                MessageBox.Show("Please select an available room.");
                return;
            }

            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Check-out must be after check-in.");
                return;
            }

            var reservation = new Reservation
            {
                GuestID = _selectedGuest.GuestID,
                RoomID = roomId,
                CheckInDate = dtpCheckIn.Value.Date,
                CheckOutDate = dtpCheckOut.Value.Date,
                Status = "Pending"
            };

            try
            {
                _db.Reservations.Add(reservation);
                _db.SaveChanges();

                var room = _db.Rooms.Find(roomId);
                if (room != null)
                {
                    room.Status = "Reserved";
                    _db.SaveChanges();
                }

                MessageBox.Show("Reservation created successfully!", "Success");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
