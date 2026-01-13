using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmReservationList : Form
    {
        private readonly HotelDbContext _db;

        public frmReservationList()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmReservationList_Load(object sender, EventArgs e)
        {
            // Default date range: today to +7 days
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddDays(7);

            // Status filter options
            cmbStatusFilter.Items.AddRange(new[] { "All", "Pending", "Confirmed", "Cancelled" });
            cmbStatusFilter.SelectedIndex = 0;

            LoadReservations();
        }

        private void LoadReservations()
        {
            var reservations = _db.Reservations
                .Include(r => r.Guest)
                .Include(r => r.Room)
                    .ThenInclude(r => r.RoomType)
                .AsQueryable();

            // Date range filter
            reservations = reservations.Where(r =>
                r.CheckInDate >= dtpFrom.Value.Date &&
                r.CheckOutDate <= dtpTo.Value.Date.AddDays(1));

            // Status filter
            string status = cmbStatusFilter.SelectedItem?.ToString();
            if (status != "All")
            {
                reservations = reservations.Where(r => r.Status == status);
            }

            dgvReservations.DataSource = reservations
                .Select(r => new
                {
                    r.ReservationID,
                    Guest = r.Guest.FullName,
                    Room = r.Room.RoomNumber,
                    Type = r.Room.RoomType.TypeName,
                    CheckIn = r.CheckInDate.ToShortDateString(),
                    CheckOut = r.CheckOutDate.ToShortDateString(),
                    Nights = (r.CheckOutDate - r.CheckInDate).Days,
                    r.Status
                })
                .ToList();

            // Hide ID column
            if (dgvReservations.Columns["ReservationID"] != null)
                dgvReservations.Columns["ReservationID"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            using (var newRes = new frmNewReservation())
            {
                if (newRes.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resId = (int)dgvReservations.SelectedRows[0].Cells["ReservationID"].Value;
            string status = dgvReservations.SelectedRows[0].Cells["Status"].Value?.ToString();

            if (status == "Cancelled")
            {
                MessageBox.Show("Cannot edit a cancelled reservation.");
                return;
            }

            var reservation = _db.Reservations.Find(resId);
            if (reservation == null)
            {
                MessageBox.Show("Reservation not found.");
                return;
            }

            using (var editForm = new frmNewReservation(reservation))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to cancel.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resId = (int)dgvReservations.SelectedRows[0].Cells["ReservationID"].Value;
            string guestName = dgvReservations.SelectedRows[0].Cells["Guest"].Value?.ToString() ?? "Unknown";
            string status = dgvReservations.SelectedRows[0].Cells["Status"].Value?.ToString();

            if (status == "Cancelled")
            {
                MessageBox.Show("This reservation is already cancelled.");
                return;
            }

            if (MessageBox.Show($"Cancel reservation for {guestName}?\nThis action cannot be undone.",
                                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var reservation = _db.Reservations
                        .Include(r => r.Room)
                        .FirstOrDefault(r => r.ReservationID == resId);

                    if (reservation == null)
                    {
                        MessageBox.Show("Reservation not found.");
                        return;
                    }

                    reservation.Status = "Cancelled";

                    // Free the room if it was reserved/occupied and no check-in exists
                    if (reservation.Room != null &&
                        (reservation.Room.Status == "Reserved" || reservation.Room.Status == "Occupied"))
                    {
                        bool hasCheckIn = _db.CheckIns.Any(ci => ci.ReservationID == resId);
                        if (!hasCheckIn)
                        {
                            reservation.Room.Status = "Available";
                        }
                    }

                    _db.SaveChanges();

                    MessageBox.Show("Reservation cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}