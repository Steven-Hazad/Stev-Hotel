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

            // Status filter
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

            // Date filter
            reservations = reservations.Where(r => r.CheckInDate >= dtpFrom.Value.Date && r.CheckOutDate <= dtpTo.Value.Date.AddDays(1));

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

            // Hide ID
            if (dgvReservations.Columns["ReservationID"] != null)
                dgvReservations.Columns["ReservationID"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadReservations();

        private void dtpFrom_ValueChanged(object sender, EventArgs e) => LoadReservations();
        private void dtpTo_ValueChanged(object sender, EventArgs e) => LoadReservations();
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadReservations();

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

        // Placeholder for edit & cancel
        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit reservation coming soon...");
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel reservation coming soon...");
        }
    }
}