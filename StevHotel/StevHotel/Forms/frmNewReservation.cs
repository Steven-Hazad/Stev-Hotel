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
            dtpCheckOut.Value = DateTime.Today.AddDays(3); // default 3 nights

            UpdateNightsAndPrice();
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
                .Take(20) // limit results
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
            {
                MessageBox.Show("No guests found. You may need to add a new guest first.");
            }
        }

        private void dgvGuests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count > 0)
            {
                int guestId = (int)dgvGuests.SelectedRows[0].Cells["GuestID"].Value;
                _selectedGuest = _db.Guests.Find(guestId);

                if (_selectedGuest != null)
                {
                    txtGuestSearch.Text = _selectedGuest.FullName + " (" + _selectedGuest.Phone + ")";
                    UpdateAvailableRooms(); // trigger room search when guest selected
                }
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }
            UpdateNightsAndPrice();
            UpdateAvailableRooms();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }
            UpdateNightsAndPrice();
            UpdateAvailableRooms();
        }

        private void UpdateNightsAndPrice()
        {
            int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
            lblNights.Text = $"Nights: {nights}";

            // Price preview only if room selected
            if (cmbAvailableRooms.SelectedItem != null && cmbAvailableRooms.SelectedValue is int roomTypeId)
            {
                var roomType = _db.RoomTypes.Find(roomTypeId);
                if (roomType != null)
                {
                    decimal total = nights * roomType.PricePerNight;
                    lblTotalPrice.Text = $"Estimated Total: {total:N2} USD";
                }
            }
            else
            {
                lblTotalPrice.Text = "";
            }
        }

        private void UpdateAvailableRooms()
        {
            cmbAvailableRooms.Items.Clear();
            cmbAvailableRooms.DataSource = null;

            if (_selectedGuest == null)
            {
                lblAvailableRooms.Text = "Available Rooms: (Select guest first)";
                return;
            }

            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;

            // Find rooms that are NOT reserved/occupied during the date range
            var bookedRoomIds = _db.Reservations
                .Where(r => r.Status != "Cancelled" &&
                            ((r.CheckInDate < checkOut && r.CheckOutDate > checkIn)))
                .Select(r => r.RoomID)
                .ToList();

            var availableRooms = _db.Rooms
                .Include(r => r.RoomType)
                .Where(r => r.Status == "Available" && !bookedRoomIds.Contains(r.RoomID))
                .Select(r => new
                {
                    r.RoomID,
                    Display = $"{r.RoomNumber} - {r.RoomType.TypeName} (${r.RoomType.PricePerNight:N2}/night)",
                    r.RoomTypeID,
                    r.RoomType.PricePerNight
                })
                .ToList();

            if (availableRooms.Count == 0)
            {
                cmbAvailableRooms.Items.Add("No available rooms for these dates");
                cmbAvailableRooms.Enabled = false;
            }
            else
            {
                cmbAvailableRooms.DataSource = availableRooms;
                cmbAvailableRooms.DisplayMember = "Display";
                cmbAvailableRooms.ValueMember = "RoomID";
                cmbAvailableRooms.Enabled = true;
                UpdateNightsAndPrice();
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

            if (cmbAvailableRooms.SelectedValue == null || cmbAvailableRooms.SelectedValue is not int roomId)
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
                Status = "Pending" // or "Confirmed" depending on your flow
            };

            try
            {
                _db.Reservations.Add(reservation);
                _db.SaveChanges();

                // Optional: Update room status to Reserved
                var room = _db.Rooms.Find(roomId);
                if (room != null)
                {
                    room.Status = "Reserved";
                    _db.SaveChanges();
                }

                MessageBox.Show("Reservation created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}