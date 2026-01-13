using System;
using System.Windows.Forms;

namespace StevHotel.Forms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {frmLogin.CurrentUser.FullName}";
            toolStripStatusLabel.Text = $"Logged in as: {frmLogin.CurrentUser.Username} ({frmLogin.CurrentUser.Role?.RoleName})";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                new frmLogin().Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roomListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rooslist = new frmRoomList();
            rooslist.ShowDialog();
        }

        private void newReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var newRes = new frmNewReservation())
            {
                newRes.ShowDialog();
            }
        }

        private void reservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resList = new frmReservationList();
            resList.ShowDialog();
        }
    }
}