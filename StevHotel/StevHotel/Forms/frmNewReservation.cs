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
        private Reservation _editingReservation; // null = new, not null = edit mode

        // Constructor for new reservation
        public frmNewReservation()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        // Constructor for editing existing reservation
        public frmNewReservation(Reservation editing) : this()
        {
            _editingReservation = editing;
        }

        private void frmNewReservation_Load(object sender, EventArgs e)
        {
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(3);

            if (_editingReservation != null)
            {
                this.Text = "Edit Reservation";
                btnCreateReservation.Text = "Update Reservation";

                // Load existing data
                _selectedGuest = _db.Guests.Find(_editingReservation.GuestID);
                if (_selectedGuest != null)
                {
                    txtGuestSearch.Text = $"{_selectedGuest.FullName} ({_selectedGuest.Phone})";
                }

                dtpCheckIn.Value = _editingReservation.CheckInDate;
                dtpCheckOut.Value = _editingReservation.CheckOutDate;

                UpdateAvailableRooms();
                cmbAvailableRooms.SelectedValue = _editingReservation.RoomID;
            }

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
                .Where(g => g.FullName.Contains(search) || g.Phone.Contains(search) ||
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
            {
                MessageBox.Show("No guests found.");
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
                    txtGuestSearch.Text = $"{_selectedGuest.FullName} ({_selectedGuest.Phone})";
                    UpdateAvailableRooms();
                }
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);

            UpdateNightsAndPrice();
            UpdateAvailableRooms();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);

            UpdateNightsAndPrice();
            UpdateAvailableRooms();
        }

        private void UpdateNightsAndPrice()
        {
            int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
            lblNights.Text = $"Nights: {nights}";

            if (cmbAvailableRooms.SelectedValue is int roomTypeId)
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
            cmbAvailableRooms.DataSource = null;
            cmbAvailableRooms.Items.Clear();

            if (_selectedGuest == null)
            {
                lblAvailableRooms.Text = "Available Rooms: (Select guest first)";
                return;
            }

            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;

            // Get booked room IDs in the date range (exclude cancelled)
            var bookedRoomIds = _db.Reservations
                .Where(r => r.Status != "Cancelled" &&
                            r.CheckInDate < checkOut && r.CheckOutDate > checkIn)
                .Select(r => r.RoomID)
                .ToList();

            // If editing, exclude current reservation from conflict check
            if (_editingReservation != null)
            {
                bookedRoomIds.Remove(_editingReservation.RoomID);
            }

            var availableRooms = _db.Rooms
                .Include(r => r.RoomType)
                .Where(r => !bookedRoomIds.Contains(r.RoomID))
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
                cmbAvailableRooms.Items.Add("No rooms available for selected dates");
                cmbAvailableRooms.Enabled = false;
            }
            else
            {
                cmbAvailableRooms.DataSource = availableRooms;
                cmbAvailableRooms.DisplayMember = "Display";
                cmbAvailableRooms.ValueMember = "RoomID";
                cmbAvailableRooms.Enabled = true;
            }

            UpdateNightsAndPrice();
        }

        private void cmbAvailableRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNightsAndPrice();
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            if (_selectedGuest == null)
            {
                MessageBox.Show("Please select a guest.");
                return;
            }

            if (!(cmbAvailableRooms.SelectedValue is int roomId))
            {
                MessageBox.Show("Please select a valid room.");
                return;
            }

            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Check-out must be after check-in.");
                return;
            }

            try
            {
                if (_editingReservation != null)
                {
                    // Edit mode
                    var oldRoom = _db.Rooms.Find(_editingReservation.RoomID);
                    if (oldRoom != null && oldRoom.Status == "Reserved")
                        oldRoom.Status = "Available"; // free old room if it was reserved

                    _editingReservation.GuestID = _selectedGuest.GuestID;
                    _editingReservation.RoomID = roomId;
                    _editingReservation.CheckInDate = dtpCheckIn.Value.Date;
                    _editingReservation.CheckOutDate = dtpCheckOut.Value.Date;

                    var newRoom = _db.Rooms.Find(roomId);
                    if (newRoom != null)
                        newRoom.Status = "Reserved";
                }
                else
                {
                    // New mode
                    var reservation = new Reservation
                    {
                        GuestID = _selectedGuest.GuestID,
                        RoomID = roomId,
                        CheckInDate = dtpCheckIn.Value.Date,
                        CheckOutDate = dtpCheckOut.Value.Date,
                        Status = "Pending"
                    };

                    _db.Reservations.Add(reservation);

                    var room = _db.Rooms.Find(roomId);
                    if (room != null)
                        room.Status = "Reserved";
                }

                _db.SaveChanges();
                MessageBox.Show(_editingReservation != null ? "Reservation updated successfully!" : "Reservation created successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}