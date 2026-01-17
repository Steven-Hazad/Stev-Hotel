namespace StevHotel.Forms
{
    partial class frmReports
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnDailySummary = new System.Windows.Forms.Button();
            this.btnOccupancyReport = new System.Windows.Forms.Button();
            this.btnGuestHistory = new System.Windows.Forms.Button();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.lblReportDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(12, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(776, 380);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnDailySummary
            // 
            this.btnDailySummary.Location = new System.Drawing.Point(12, 12);
            this.btnDailySummary.Name = "btnDailySummary";
            this.btnDailySummary.Size = new System.Drawing.Size(140, 35);
            this.btnDailySummary.TabIndex = 1;
            this.btnDailySummary.Text = "Daily Summary";
            this.btnDailySummary.UseVisualStyleBackColor = true;
            this.btnDailySummary.Click += new System.EventHandler(this.btnDailySummary_Click);
            // 
            // btnOccupancyReport
            // 
            this.btnOccupancyReport.Location = new System.Drawing.Point(158, 12);
            this.btnOccupancyReport.Name = "btnOccupancyReport";
            this.btnOccupancyReport.Size = new System.Drawing.Size(140, 35);
            this.btnOccupancyReport.TabIndex = 2;
            this.btnOccupancyReport.Text = "Occupancy Report";
            this.btnOccupancyReport.UseVisualStyleBackColor = true;
            this.btnOccupancyReport.Click += new System.EventHandler(this.btnOccupancyReport_Click);
            // 
            // btnGuestHistory
            // 
            this.btnGuestHistory.Location = new System.Drawing.Point(304, 12);
            this.btnGuestHistory.Name = "btnGuestHistory";
            this.btnGuestHistory.Size = new System.Drawing.Size(140, 35);
            this.btnGuestHistory.TabIndex = 3;
            this.btnGuestHistory.Text = "Guest History";
            this.btnGuestHistory.UseVisualStyleBackColor = true;
            this.btnGuestHistory.Click += new System.EventHandler(this.btnGuestHistory_Click);
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.Location = new System.Drawing.Point(600, 15);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(150, 23);
            this.dtpReportDate.TabIndex = 4;
            this.dtpReportDate.Value = System.DateTime.Today;
            // 
            // lblReportDate
            // 
            this.lblReportDate.AutoSize = true;
            this.lblReportDate.Location = new System.Drawing.Point(530, 18);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(64, 16);
            this.lblReportDate.TabIndex = 5;
            this.lblReportDate.Text = "Report Date:";
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblReportDate);
            this.Controls.Add(this.dtpReportDate);
            this.Controls.Add(this.btnGuestHistory);
            this.Controls.Add(this.btnOccupancyReport);
            this.Controls.Add(this.btnDailySummary);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reports & Analytics";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnDailySummary;
        private System.Windows.Forms.Button btnOccupancyReport;
        private System.Windows.Forms.Button btnGuestHistory;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Label lblReportDate;
    }
}