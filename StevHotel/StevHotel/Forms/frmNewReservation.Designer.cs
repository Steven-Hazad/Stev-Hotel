namespace StevHotel.Forms
{
    partial class frmNewReservation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblGuest = new System.Windows.Forms.Label();
            this.txtGuestSearch = new System.Windows.Forms.TextBox();
            this.btnSearchGuest = new System.Windows.Forms.Button();
            this.dgvGuests = new System.Windows.Forms.DataGridView();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblAvailableRooms = new System.Windows.Forms.Label();
            this.cmbAvailableRooms = new System.Windows.Forms.ComboBox();
            this.lblNights = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnCreateReservation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGuest
            // 
            this.lblGuest.AutoSize = true;
            this.lblGuest.Location = new System.Drawing.Point(30, 30);
            this.lblGuest.Name = "lblGuest";
            this.lblGuest.Size = new System.Drawing.Size(45, 16);
            this.lblGuest.TabIndex = 0;
            this.lblGuest.Text = "Guest:";
            // 
            // txtGuestSearch
            // 
            this.txtGuestSearch.Location = new System.Drawing.Point(90, 27);
            this.txtGuestSearch.Name = "txtGuestSearch";
            this.txtGuestSearch.Size = new System.Drawing.Size(250, 23);
            this.txtGuestSearch.TabIndex = 1;
            // 
            // btnSearchGuest
            // 
            this.btnSearchGuest.Location = new System.Drawing.Point(350, 25);
            this.btnSearchGuest.Name = "btnSearchGuest";
            this.btnSearchGuest.Size = new System.Drawing.Size(80, 28);
            this.btnSearchGuest.TabIndex = 2;
            this.btnSearchGuest.Text = "Search";
            this.btnSearchGuest.UseVisualStyleBackColor = true;
            this.btnSearchGuest.Click += new System.EventHandler(this.btnSearchGuest_Click);
            // 
            // dgvGuests
            // 
            this.dgvGuests.AllowUserToAddRows = false;
            this.dgvGuests.AllowUserToDeleteRows = false;
            this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.Location = new System.Drawing.Point(30, 60);
            this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.ReadOnly = true;
            this.dgvGuests.RowHeadersWidth = 51;
            this.dgvGuests.RowTemplate.Height = 29;
            this.dgvGuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGuests.Size = new System.Drawing.Size(500, 150);
            this.dgvGuests.TabIndex = 3;
            this.dgvGuests.SelectionChanged += new System.EventHandler(this.dgvGuests_SelectionChanged);
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(30, 230);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(60, 16);
            this.lblCheckIn.TabIndex = 4;
            this.lblCheckIn.Text = "Check-In:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Location = new System.Drawing.Point(100, 227);
            this.dtpCheckIn.MinDate = System.DateTime.Today;
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(200, 23);
            this.dtpCheckIn.TabIndex = 5;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(30, 270);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(68, 16);
            this.lblCheckOut.TabIndex = 6;
            this.lblCheckOut.Text = "Check-Out:";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(100, 267);
            this.dtpCheckOut.MinDate = System.DateTime.Today.AddDays(1);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(200, 23);
            this.dtpCheckOut.TabIndex = 7;
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
            this.lblAvailableRooms.Location = new System.Drawing.Point(30, 310);
            this.lblAvailableRooms.Name = "lblAvailableRooms";
            this.lblAvailableRooms.Size = new System.Drawing.Size(90, 16);
            this.lblAvailableRooms.TabIndex = 8;
            this.lblAvailableRooms.Text = "Available Room:";
            // 
            // cmbAvailableRooms
            // 
            this.cmbAvailableRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAvailableRooms.FormattingEnabled = true;
            this.cmbAvailableRooms.Location = new System.Drawing.Point(130, 307);
            this.cmbAvailableRooms.Name = "cmbAvailableRooms";
            this.cmbAvailableRooms.Size = new System.Drawing.Size(200, 24);
            this.cmbAvailableRooms.TabIndex = 9;
            this.cmbAvailableRooms.SelectedIndexChanged += new System.EventHandler(this.cmbAvailableRooms_SelectedIndexChanged);
            // 
            // lblNights
            // 
            this.lblNights.AutoSize = true;
            this.lblNights.Location = new System.Drawing.Point(30, 350);
            this.lblNights.Name = "lblNights";
            this.lblNights.Size = new System.Drawing.Size(0, 16);
            this.lblNights.TabIndex = 10;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(30, 380);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 16);
            this.lblTotalPrice.TabIndex = 11;
            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.Location = new System.Drawing.Point(130, 420);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new System.Drawing.Size(120, 35);
            this.btnCreateReservation.TabIndex = 12;
            this.btnCreateReservation.Text = "Create Reservation";
            this.btnCreateReservation.UseVisualStyleBackColor = true;
            this.btnCreateReservation.Click += new System.EventHandler(this.btnCreateReservation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmNewReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 480);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateReservation);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblNights);
            this.Controls.Add(this.cmbAvailableRooms);
            this.Controls.Add(this.lblAvailableRooms);
            this.Controls.Add(this.dtpCheckOut);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.dgvGuests);
            this.Controls.Add(this.btnSearchGuest);
            this.Controls.Add(this.txtGuestSearch);
            this.Controls.Add(this.lblGuest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Reservation";
            this.Load += new System.EventHandler(this.frmNewReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblGuest;
        private System.Windows.Forms.TextBox txtGuestSearch;
        private System.Windows.Forms.Button btnSearchGuest;
        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblAvailableRooms;
        private System.Windows.Forms.ComboBox cmbAvailableRooms;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnCreateReservation;
        private System.Windows.Forms.Button btnCancel;
    }
}