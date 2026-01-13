using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmCheckIn : Form
    {
        private readonly HotelDbContext _db;
        private readonly Reservation _reservation;

        public frmCheckIn(Reservation reservation)
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
            _reservation = reservation ?? throw new ArgumentNullException(nameof(reservation));
        }

        private void frmCheckIn_Load(object sender, EventArgs e)
        {
            // Load reservation details
            _db.Entry(_reservation).Reference(r => r.Guest).Load();
            _db.Entry(_reservation).Reference(r => r.Room).Load();
            _db.Entry(_reservation.Room).Reference(r => r.RoomType).Load();

            lblReservation.Text = $"Reservation #{_reservation.ReservationID}";
            lblGuestName.Text = $"Guest: {_reservation.Guest.FullName} ({_reservation.Guest.Phone})";
            lblRoom.Text = $"Room: {_reservation.Room.RoomNumber} - {_reservation.Room.RoomType.TypeName}";
            lblCheckInDate.Text = $"Check-In: {_reservation.CheckInDate:dddd, dd MMM yyyy}";
            lblNights.Text = $"Nights: {(_reservation.CheckOutDate - _reservation.CheckInDate).Days}";
        }

        private void btnConfirmCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Update reservation status (optional)
                if (_reservation.Status == "Pending")
                    _reservation.Status = "Confirmed";

                // Create CheckIn record
                var checkIn = new CheckIn
                {
                    ReservationID = _reservation.ReservationID,
                    CheckInTime = DateTime.Now,
                    Notes = txtNotes.Text.Trim()
                };

                _db.CheckIns.Add(checkIn);

                // Update room status to Occupied
                _reservation.Room.Status = "Occupied";

                _db.SaveChanges();

                MessageBox.Show($"Check-in successful for {_reservation.Guest.FullName} in room {_reservation.Room.RoomNumber}!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during check-in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}