
namespace StevHotel.Forms
{
    partial class frmCheckOut
    {
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
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblStayDates = new System.Windows.Forms.Label();
            this.lblNights = new System.Windows.Forms.Label();
            this.lblRoomCharge = new System.Windows.Forms.Label();
            this.lblExtras = new System.Windows.Forms.Label();
            this.numExtras = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.btnConfirmCheckout = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGuest
            // 
            this.lblGuest.AutoSize = true;
            this.lblGuest.Location = new System.Drawing.Point(30, 40);
            this.lblGuest.Name = "lblGuest";
            this.lblGuest.Size = new System.Drawing.Size(0, 20);
            this.lblGuest.TabIndex = 0;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(30, 70);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(0, 20);
            this.lblRoom.TabIndex = 1;
            // 
            // lblStayDates
            // 
            this.lblStayDates.AutoSize = true;
            this.lblStayDates.Location = new System.Drawing.Point(30, 100);
            this.lblStayDates.Name = "lblStayDates";
            this.lblStayDates.Size = new System.Drawing.Size(0, 20);
            this.lblStayDates.TabIndex = 2;
            // 
            // lblNights
            // 
            this.lblNights.AutoSize = true;
            this.lblNights.Location = new System.Drawing.Point(30, 130);
            this.lblNights.Name = "lblNights";
            this.lblNights.Size = new System.Drawing.Size(0, 20);
            this.lblNights.TabIndex = 3;
            // 
            // lblRoomCharge
            // 
            this.lblRoomCharge.AutoSize = true;
            this.lblRoomCharge.Location = new System.Drawing.Point(30, 160);
            this.lblRoomCharge.Name = "lblRoomCharge";
            this.lblRoomCharge.Size = new System.Drawing.Size(0, 20);
            this.lblRoomCharge.TabIndex = 4;
            // 
            // lblExtras
            // 
            this.lblExtras.AutoSize = true;
            this.lblExtras.Location = new System.Drawing.Point(30, 190);
            this.lblExtras.Name = "lblExtras";
            this.lblExtras.Size = new System.Drawing.Size(80, 20);
            this.lblExtras.TabIndex = 5;
            this.lblExtras.Text = "Extras ($):";
            // 
            // numExtras
            // 
            this.numExtras.DecimalPlaces = 2;
            this.numExtras.Location = new System.Drawing.Point(120, 188);
            this.numExtras.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numExtras.Name = "numExtras";
            this.numExtras.Size = new System.Drawing.Size(120, 23);
            this.numExtras.TabIndex = 6;
            this.numExtras.ValueChanged += new System.EventHandler(this.numExtras_ValueChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(30, 230);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 28);
            this.lblTotal.TabIndex = 7;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalValue.Location = new System.Drawing.Point(30, 260);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(0, 32);
            this.lblTotalValue.TabIndex = 8;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(30, 310);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(100, 20);
            this.lblPaymentMethod.TabIndex = 9;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Other"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(140, 307);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(150, 24);
            this.cmbPaymentMethod.TabIndex = 10;
            // 
            // btnConfirmCheckout
            // 
            this.btnConfirmCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnConfirmCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmCheckout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmCheckout.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCheckout.Location = new System.Drawing.Point(140, 350);
            this.btnConfirmCheckout.Name = "btnConfirmCheckout";
            this.btnConfirmCheckout.Size = new System.Drawing.Size(150, 40);
            this.btnConfirmCheckout.TabIndex = 11;
            this.btnConfirmCheckout.Text = "Confirm Check-Out";
            this.btnConfirmCheckout.UseVisualStyleBackColor = false;
            this.btnConfirmCheckout.Click += new System.EventHandler(this.btnConfirmCheckout_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(300, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmCheckout);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.numExtras);
            this.Controls.Add(this.lblExtras);
            this.Controls.Add(this.lblRoomCharge);
            this.Controls.Add(this.lblNights);
            this.Controls.Add(this.lblStayDates);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblGuestName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check-Out Guest";
            this.Load += new System.EventHandler(this.frmCheckOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numExtras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblGuest;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblStayDates;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.Label lblRoomCharge;
        private System.Windows.Forms.Label lblExtras;
        private System.Windows.Forms.NumericUpDown numExtras;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Button btnConfirmCheckout;
        private System.Windows.Forms.Button btnCancel;
        private Control lblGuestName;
    }
}