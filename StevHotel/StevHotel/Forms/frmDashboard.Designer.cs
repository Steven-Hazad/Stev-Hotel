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
            cleaningScheduleToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            lblWelcome = new Label();
            panelStats = new Panel();
            lblOccupancyTitle = new Label();
            lblOccupancyValue = new Label();
            lblOccupiedRooms = new Label();
            lblArrivalsTitle = new Label();
            lblArrivalsValue = new Label();
            lblDeparturesTitle = new Label();
            lblDeparturesValue = new Label();
            lblRevenueTitle = new Label();
            lblRevenueValue = new Label();
            mainMenuStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelStats.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, roomsToolStripMenuItem, reservationsToolStripMenuItem, guestsToolStripMenuItem, billingToolStripMenuItem, reportsToolStripMenuItem, settingsToolStripMenuItem, cleaningScheduleToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1000, 24);
            mainMenuStrip.TabIndex = 2;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logoutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(112, 22);
            logoutToolStripMenuItem.Text = "&Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(112, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // roomsToolStripMenuItem
            // 
            roomsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { roomListToolStripMenuItem, addNewRoomToolStripMenuItem });
            roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            roomsToolStripMenuItem.Size = new Size(56, 20);
            roomsToolStripMenuItem.Text = "&Rooms";
            // 
            // roomListToolStripMenuItem
            // 
            roomListToolStripMenuItem.Name = "roomListToolStripMenuItem";
            roomListToolStripMenuItem.Size = new Size(158, 22);
            roomListToolStripMenuItem.Text = "Room &List";
            roomListToolStripMenuItem.Click += roomListToolStripMenuItem_Click;
            // 
            // addNewRoomToolStripMenuItem
            // 
            addNewRoomToolStripMenuItem.Name = "addNewRoomToolStripMenuItem";
            addNewRoomToolStripMenuItem.Size = new Size(158, 22);
            addNewRoomToolStripMenuItem.Text = "Add New &Room";
            // 
            // reservationsToolStripMenuItem
            // 
            reservationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newReservationToolStripMenuItem, reservationListToolStripMenuItem });
            reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
            reservationsToolStripMenuItem.Size = new Size(85, 20);
            reservationsToolStripMenuItem.Text = "&Reservations";
            // 
            // newReservationToolStripMenuItem
            // 
            newReservationToolStripMenuItem.Name = "newReservationToolStripMenuItem";
            newReservationToolStripMenuItem.Size = new Size(162, 22);
            newReservationToolStripMenuItem.Text = "New &Reservation";
            newReservationToolStripMenuItem.Click += newReservationToolStripMenuItem_Click;
            // 
            // reservationListToolStripMenuItem
            // 
            reservationListToolStripMenuItem.Name = "reservationListToolStripMenuItem";
            reservationListToolStripMenuItem.Size = new Size(162, 22);
            reservationListToolStripMenuItem.Text = "Reservation &List";
            reservationListToolStripMenuItem.Click += reservationListToolStripMenuItem_Click;
            // 
            // guestsToolStripMenuItem
            // 
            guestsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { guestListToolStripMenuItem });
            guestsToolStripMenuItem.Name = "guestsToolStripMenuItem";
            guestsToolStripMenuItem.Size = new Size(54, 20);
            guestsToolStripMenuItem.Text = "&Guests";
            // 
            // guestListToolStripMenuItem
            // 
            guestListToolStripMenuItem.Name = "guestListToolStripMenuItem";
            guestListToolStripMenuItem.Size = new Size(125, 22);
            guestListToolStripMenuItem.Text = "Guest &List";
            guestListToolStripMenuItem.Click += guestListToolStripMenuItem_Click;
            // 
            // billingToolStripMenuItem
            // 
            billingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { invoicesToolStripMenuItem });
            billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            billingToolStripMenuItem.Size = new Size(52, 20);
            billingToolStripMenuItem.Text = "&Billing";
            // 
            // invoicesToolStripMenuItem
            // 
            invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            invoicesToolStripMenuItem.Size = new Size(180, 22);
            invoicesToolStripMenuItem.Text = "&Invoices";
            invoicesToolStripMenuItem.Click += invoicesToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dailySummaryToolStripMenuItem, occupancyReportToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(59, 20);
            reportsToolStripMenuItem.Text = "&Reports";
            // 
            // dailySummaryToolStripMenuItem
            // 
            dailySummaryToolStripMenuItem.Name = "dailySummaryToolStripMenuItem";
            dailySummaryToolStripMenuItem.Size = new Size(180, 22);
            dailySummaryToolStripMenuItem.Text = "Daily &Summary";
            dailySummaryToolStripMenuItem.Click += dailySummaryToolStripMenuItem_Click;
            // 
            // occupancyReportToolStripMenuItem
            // 
            occupancyReportToolStripMenuItem.Name = "occupancyReportToolStripMenuItem";
            occupancyReportToolStripMenuItem.Size = new Size(180, 22);
            occupancyReportToolStripMenuItem.Text = "Occupancy &Report";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "&Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // cleaningScheduleToolStripMenuItem
            // 
            cleaningScheduleToolStripMenuItem.Name = "cleaningScheduleToolStripMenuItem";
            cleaningScheduleToolStripMenuItem.Size = new Size(117, 20);
            cleaningScheduleToolStripMenuItem.Text = "Cleaning Schedule";
            cleaningScheduleToolStripMenuItem.Click += cleaningScheduleToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1000, 22);
            statusStrip1.TabIndex = 3;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 40);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 30);
            lblWelcome.TabIndex = 1;
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.FromArgb(245, 245, 247);
            panelStats.BorderStyle = BorderStyle.FixedSingle;
            panelStats.Controls.Add(lblOccupancyTitle);
            panelStats.Controls.Add(lblOccupancyValue);
            panelStats.Controls.Add(lblOccupiedRooms);
            panelStats.Controls.Add(lblArrivalsTitle);
            panelStats.Controls.Add(lblArrivalsValue);
            panelStats.Controls.Add(lblDeparturesTitle);
            panelStats.Controls.Add(lblDeparturesValue);
            panelStats.Controls.Add(lblRevenueTitle);
            panelStats.Controls.Add(lblRevenueValue);
            panelStats.Location = new Point(30, 90);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(740, 140);
            panelStats.TabIndex = 0;
            // 
            // lblOccupancyTitle
            // 
            lblOccupancyTitle.Location = new Point(20, 10);
            lblOccupancyTitle.Name = "lblOccupancyTitle";
            lblOccupancyTitle.Size = new Size(100, 23);
            lblOccupancyTitle.TabIndex = 0;
            lblOccupancyTitle.Text = "Occupancy Today";
            // 
            // lblOccupancyValue
            // 
            lblOccupancyValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblOccupancyValue.Location = new Point(20, 35);
            lblOccupancyValue.Name = "lblOccupancyValue";
            lblOccupancyValue.Size = new Size(100, 35);
            lblOccupancyValue.TabIndex = 1;
            lblOccupancyValue.Text = "0%";
            // 
            // lblOccupiedRooms
            // 
            lblOccupiedRooms.Location = new Point(20, 91);
            lblOccupiedRooms.Name = "lblOccupiedRooms";
            lblOccupiedRooms.Size = new Size(100, 23);
            lblOccupiedRooms.TabIndex = 2;
            lblOccupiedRooms.Text = "Occupied: 0 / 0";
            // 
            // lblArrivalsTitle
            // 
            lblArrivalsTitle.Location = new Point(200, 10);
            lblArrivalsTitle.Name = "lblArrivalsTitle";
            lblArrivalsTitle.Size = new Size(100, 23);
            lblArrivalsTitle.TabIndex = 3;
            lblArrivalsTitle.Text = "Arrivals Today";
            // 
            // lblArrivalsValue
            // 
            lblArrivalsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblArrivalsValue.Location = new Point(200, 35);
            lblArrivalsValue.Name = "lblArrivalsValue";
            lblArrivalsValue.Size = new Size(100, 35);
            lblArrivalsValue.TabIndex = 4;
            lblArrivalsValue.Text = "0";
            // 
            // lblDeparturesTitle
            // 
            lblDeparturesTitle.Location = new Point(380, 10);
            lblDeparturesTitle.Name = "lblDeparturesTitle";
            lblDeparturesTitle.Size = new Size(100, 23);
            lblDeparturesTitle.TabIndex = 5;
            lblDeparturesTitle.Text = "Departures Today";
            // 
            // lblDeparturesValue
            // 
            lblDeparturesValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDeparturesValue.Location = new Point(380, 35);
            lblDeparturesValue.Name = "lblDeparturesValue";
            lblDeparturesValue.Size = new Size(100, 35);
            lblDeparturesValue.TabIndex = 6;
            lblDeparturesValue.Text = "0";
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.Location = new Point(560, 10);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(100, 23);
            lblRevenueTitle.TabIndex = 7;
            lblRevenueTitle.Text = "Revenue Today";
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRevenueValue.Location = new Point(560, 35);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(100, 35);
            lblRevenueValue.TabIndex = 8;
            lblRevenueValue.Text = "0.00 USD";
            // 
            // frmDashboard
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(panelStats);
            Controls.Add(lblWelcome);
            Controls.Add(mainMenuStrip);
            Controls.Add(statusStrip1);
            MainMenuStrip = mainMenuStrip;
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stev-Hotel Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmDashboard_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelStats.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem, logoutToolStripMenuItem, exitToolStripMenuItem;
        private ToolStripMenuItem roomsToolStripMenuItem, roomListToolStripMenuItem, addNewRoomToolStripMenuItem;
        private ToolStripMenuItem reservationsToolStripMenuItem, newReservationToolStripMenuItem, reservationListToolStripMenuItem;
        private ToolStripMenuItem guestsToolStripMenuItem, guestListToolStripMenuItem;
        private ToolStripMenuItem billingToolStripMenuItem, invoicesToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem, dailySummaryToolStripMenuItem, occupancyReportToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Label lblWelcome;
        private Panel panelStats;
        private Label lblOccupancyTitle, lblOccupancyValue, lblOccupiedRooms;
        private Label lblArrivalsTitle, lblArrivalsValue;
        private Label lblDeparturesTitle, lblDeparturesValue;
        private Label lblRevenueTitle, lblRevenueValue;
        private ToolStripMenuItem cleaningScheduleToolStripMenuItem;
    }
}
