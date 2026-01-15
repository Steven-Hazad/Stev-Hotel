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

            // Total rooms
            int totalRooms = _db.Rooms.Count();

            // Occupied rooms today
            int occupied = _db.Rooms.Count(r => r.Status == "Occupied");

            // Occupancy %
            double occupancy = totalRooms > 0
                ? (occupied * 100.0 / totalRooms)
                : 0;

            lblOccupancyValue.Text = $"{occupancy:F1}%";
            lblOccupancyValue.ForeColor =
                occupancy >= 70 ? Color.Green :
                occupancy < 30 ? Color.Red :
                Color.Orange;

            // Today's revenue
            var tomorrow = today.AddDays(1);

            decimal todayRevenue =
                _db.Payments
                    .Where(p => p.PaymentDate >= today && p.PaymentDate < tomorrow)
                    .Sum(p => (decimal?)p.Amount) ?? 0;



            lblRevenueValue.Text = $"{todayRevenue:N2} USD";
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
            var roomList = new frmRoomList();
            roomList.ShowDialog();
        }

        private void newReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var newRes = new frmNewReservation();
            newRes.ShowDialog();
        }

        private void reservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resList = new frmReservationList();
            resList.ShowDialog();
        }

        private void guestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var guestList = new frmGuestList();
            guestList.ShowDialog();
        }
    }
}
