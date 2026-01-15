namespace StevHotel.Forms
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            roomsToolStripMenuItem = new ToolStripMenuItem();
            roomListToolStripMenuItem = new ToolStripMenuItem();
            addNewRoomToolStripMenuItem = new ToolStripMenuItem();
            reservationsToolStripMenuItem = new ToolStripMenuItem();
            newReservationToolStripMenuItem = new ToolStripMenuItem();
            reservationListToolStripMenuItem = new ToolStripMenuItem();
            guestsToolStripMenuItem = new ToolStripMenuItem();
            guestListToolStripMenuItem = new ToolStripMenuItem();
            billingToolStripMenuItem = new ToolStripMenuItem();
            invoicesToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            dailySummaryToolStripMenuItem = new ToolStripMenuItem();
            occupancyReportToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            lblWelcome = new Label();
            panelDashboardStats = new Panel();
            lblOccupancyTitle = new Label();
            lblOccupancyValue = new Label();
            lblRevenueTitle = new Label();
            lblRevenueValue = new Label();

            // MenuStrip
            mainMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                fileToolStripMenuItem,
                roomsToolStripMenuItem,
                reservationsToolStripMenuItem,
                guestsToolStripMenuItem,
                billingToolStripMenuItem,
                reportsToolStripMenuItem,
                settingsToolStripMenuItem
            });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1000, 24);

            // File
            fileToolStripMenuItem.Text = "&File";
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                logoutToolStripMenuItem,
                exitToolStripMenuItem
            });

            logoutToolStripMenuItem.Text = "&Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;

            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;

            // Rooms
            roomsToolStripMenuItem.Text = "&Rooms";
            roomsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                roomListToolStripMenuItem,
                addNewRoomToolStripMenuItem
            });

            roomListToolStripMenuItem.Text = "Room &List";
            roomListToolStripMenuItem.Click += roomListToolStripMenuItem_Click;

            addNewRoomToolStripMenuItem.Text = "Add New &Room";

            // Reservations
            reservationsToolStripMenuItem.Text = "&Reservations";
            reservationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                newReservationToolStripMenuItem,
                reservationListToolStripMenuItem
            });

            newReservationToolStripMenuItem.Text = "New &Reservation";
            newReservationToolStripMenuItem.Click += newReservationToolStripMenuItem_Click;

            reservationListToolStripMenuItem.Text = "Reservation &List";
            reservationListToolStripMenuItem.Click += reservationListToolStripMenuItem_Click;

            // Guests
            guestsToolStripMenuItem.Text = "&Guests";
            guestsToolStripMenuItem.DropDownItems.Add(guestListToolStripMenuItem);

            guestListToolStripMenuItem.Text = "Guest &List";
            guestListToolStripMenuItem.Click += guestListToolStripMenuItem_Click;

            // Billing
            billingToolStripMenuItem.Text = "&Billing";
            billingToolStripMenuItem.DropDownItems.Add(invoicesToolStripMenuItem);

            invoicesToolStripMenuItem.Text = "&Invoices";

            // Reports
            reportsToolStripMenuItem.Text = "&Reports";
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                dailySummaryToolStripMenuItem,
                occupancyReportToolStripMenuItem
            });

            dailySummaryToolStripMenuItem.Text = "Daily &Summary";
            occupancyReportToolStripMenuItem.Text = "Occupancy &Report";

            // Settings
            settingsToolStripMenuItem.Text = "&Settings";

            // Welcome label
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 40);
            lblWelcome.Text = "Welcome";

            // Dashboard Stats Panel
            panelDashboardStats.Location = new Point(30, 90);
            panelDashboardStats.Size = new Size(800, 120);
            panelDashboardStats.BackColor = Color.FromArgb(240, 248, 255);

            lblOccupancyTitle.Text = "Today's Occupancy";
            lblOccupancyTitle.Location = new Point(20, 20);

            lblOccupancyValue.Text = "0%";
            lblOccupancyValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOccupancyValue.Location = new Point(20, 45);

            lblRevenueTitle.Text = "Today's Revenue";
            lblRevenueTitle.Location = new Point(300, 20);

            lblRevenueValue.Text = "$0.00";
            lblRevenueValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRevenueValue.Location = new Point(300, 45);

            panelDashboardStats.Controls.Add(lblOccupancyTitle);
            panelDashboardStats.Controls.Add(lblOccupancyValue);
            panelDashboardStats.Controls.Add(lblRevenueTitle);
            panelDashboardStats.Controls.Add(lblRevenueValue);

            // StatusStrip
            statusStrip1.Items.Add(toolStripStatusLabel);
            statusStrip1.Location = new Point(0, 540);
            toolStripStatusLabel.Text = "Logged in as:";

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(panelDashboardStats);
            Controls.Add(lblWelcome);
            Controls.Add(mainMenuStrip);
            Controls.Add(statusStrip1);
            MainMenuStrip = mainMenuStrip;
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stev-Hotel Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmDashboard_Load;
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem roomsToolStripMenuItem;
        private ToolStripMenuItem roomListToolStripMenuItem;
        private ToolStripMenuItem addNewRoomToolStripMenuItem;
        private ToolStripMenuItem reservationsToolStripMenuItem;
        private ToolStripMenuItem newReservationToolStripMenuItem;
        private ToolStripMenuItem reservationListToolStripMenuItem;
        private ToolStripMenuItem guestsToolStripMenuItem;
        private ToolStripMenuItem guestListToolStripMenuItem;
        private ToolStripMenuItem billingToolStripMenuItem;
        private ToolStripMenuItem invoicesToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem dailySummaryToolStripMenuItem;
        private ToolStripMenuItem occupancyReportToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Label lblWelcome;
        private Panel panelDashboardStats;
        private Label lblOccupancyTitle;
        private Label lblOccupancyValue;
        private Label lblRevenueTitle;
        private Label lblRevenueValue;
    }
}
