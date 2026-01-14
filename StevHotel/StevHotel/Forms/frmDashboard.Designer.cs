namespace StevHotel.Forms
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            lblWelcome = new Label();
            panelStats = new Panel();
            lblOccupancy = new Label();
            lblRevenue = new Label();
            lblStatus = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            mainMenuStrip.SuspendLayout();
            panelStats.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, roomsToolStripMenuItem, reservationsToolStripMenuItem, guestsToolStripMenuItem, billingToolStripMenuItem, reportsToolStripMenuItem, settingsToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(7, 2, 0, 2);
            mainMenuStrip.Size = new Size(933, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
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
            guestListToolStripMenuItem.Size = new Size(180, 22);
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
            invoicesToolStripMenuItem.Size = new Size(117, 22);
            invoicesToolStripMenuItem.Text = "&Invoices";
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
            dailySummaryToolStripMenuItem.Size = new Size(172, 22);
            dailySummaryToolStripMenuItem.Text = "Daily &Summary";
            // 
            // occupancyReportToolStripMenuItem
            // 
            occupancyReportToolStripMenuItem.Name = "occupancyReportToolStripMenuItem";
            occupancyReportToolStripMenuItem.Size = new Size(172, 22);
            occupancyReportToolStripMenuItem.Text = "Occupancy &Report";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "&Settings";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(35, 46);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 30);
            lblWelcome.TabIndex = 1;
            // 
            // panelStats
            // 
            panelStats.Controls.Add(lblOccupancy);
            panelStats.Controls.Add(lblRevenue);
            panelStats.Location = new Point(35, 104);
            panelStats.Margin = new Padding(4, 3, 4, 3);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(863, 138);
            panelStats.TabIndex = 2;
            // 
            // lblOccupancy
            // 
            lblOccupancy.AutoSize = true;
            lblOccupancy.Font = new Font("Segoe UI", 12F);
            lblOccupancy.Location = new Point(12, 23);
            lblOccupancy.Margin = new Padding(4, 0, 4, 0);
            lblOccupancy.Name = "lblOccupancy";
            lblOccupancy.Size = new Size(234, 21);
            lblOccupancy.TabIndex = 0;
            lblOccupancy.Text = "Today’s Occupancy: Calculating...";
            // 
            // lblRevenue
            // 
            lblRevenue.AutoSize = true;
            lblRevenue.Font = new Font("Segoe UI", 12F);
            lblRevenue.Location = new Point(12, 69);
            lblRevenue.Margin = new Padding(4, 0, 4, 0);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(218, 21);
            lblRevenue.TabIndex = 1;
            lblRevenue.Text = "Today’s Revenue: Calculating...";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(35, 265);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 3;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 497);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(933, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(80, 17);
            toolStripStatusLabel.Text = "Logged in as: ";
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(lblStatus);
            Controls.Add(panelStats);
            Controls.Add(lblWelcome);
            Controls.Add(mainMenuStrip);
            Controls.Add(statusStrip1);
            MainMenuStrip = mainMenuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stev-Hotel Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmDashboard_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailySummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem occupancyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblOccupancy;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}