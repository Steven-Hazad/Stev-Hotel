using System;
using System.Windows.Forms;

namespace StevHotel.Forms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.Text = "Stev-Hotel Dashboard";
            this.WindowState = FormWindowState.Maximized;
            this.FormClosed += (s, e) => Application.Exit(); // Close app when dashboard closed
        }

        // We'll add buttons/menu for Rooms, Reservations, etc. next
    }
}