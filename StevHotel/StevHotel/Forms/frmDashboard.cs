using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;

namespace StevHotel.Forms
{
    public partial class frmDashboard : Form
    {
        private readonly HotelDbContext _db;

        public frmDashboard()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {frmLogin.CurrentUser.FullName}";
            toolStripStatusLabel.Text =
                $"Logged in as: {frmLogin.CurrentUser.Username} ({frmLogin.CurrentUser.Role?.RoleName})";

            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            int totalRooms = _db.Rooms.Count();
            int occupied = _db.Rooms.Count(r => r.Status == "Occupied");

            double occupancy = totalRooms > 0 ? (occupied * 100.0 / totalRooms) : 0;
            lblOccupancyValue.Text = $"{occupancy:F1}%";
            lblOccupiedRooms.Text = $"Occupied: {occupied} / {totalRooms}";

            lblOccupancyValue.ForeColor =
                occupancy >= 70 ? Color.ForestGreen :
                occupancy < 30 ? Color.Crimson :
                Color.DarkOrange;

            int arrivals = _db.Reservations.Count(r =>
                r.CheckInDate >= today &&
                r.CheckInDate < tomorrow &&
                r.Status != "Cancelled");

            lblArrivalsValue.Text = arrivals.ToString();

            int departures = _db.Reservations.Count(r =>
                r.CheckOutDate >= today &&
                r.CheckOutDate < tomorrow &&
                r.Status != "Cancelled");

            lblDeparturesValue.Text = departures.ToString();

            decimal revenueToday =
                _db.Payments
                   .Where(p => p.PaymentDate >= today && p.PaymentDate < tomorrow)
                   .Sum(p => (decimal?)p.Amount) ?? 0;

            lblRevenueValue.Text = $"{revenueToday:N2} USD";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                new frmLogin().Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roomListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmRoomList().ShowDialog();
        }

        private void newReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmNewReservation().ShowDialog();
        }

        private void reservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReservationList().ShowDialog();
        }

        private void guestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmGuestList().ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLogin.CurrentUser?.Role?.RoleName != "Admin")
            {
                MessageBox.Show("Only Admins can view activity logs.");
                return;
            }

            var logForm = new frmActivityLog();
            logForm.ShowDialog();
        }

        private void dailySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = new frmDailyReport();
            report.ShowDialog();
        }

        private void cleaningScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cleaning = new frmCleaningSchedule();
            cleaning.ShowDialog();
        }
    }
}
