namespace StevHotel.Forms
{
    partial class frmActivityLog
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
            dgvLogs = new DataGridView();
            btnRefresh = new Button();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblDateRange = new Label();
            cmbUserFilter = new ComboBox();
            lblUserFilter = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // dgvLogs
            // 
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;
            dgvLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Location = new Point(10, 56);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.RowHeadersWidth = 51;
            dgvLogs.RowTemplate.Height = 29;
            dgvLogs.Size = new Size(688, 328);
            dgvLogs.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(633, 11);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(66, 28);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(394, 14);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(106, 23);
            dtpFrom.TabIndex = 2;
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(525, 14);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(106, 23);
            dtpTo.TabIndex = 3;
            dtpTo.ValueChanged += dtpTo_ValueChanged;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Location = new Point(332, 17);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(61, 15);
            lblDateRange.TabIndex = 4;
            lblDateRange.Text = "From - To:";
            // 
            // cmbUserFilter
            // 
            cmbUserFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserFilter.Location = new Point(131, 14);
            cmbUserFilter.Name = "cmbUserFilter";
            cmbUserFilter.Size = new Size(176, 23);
            cmbUserFilter.TabIndex = 5;
            cmbUserFilter.SelectedIndexChanged += cmbUserFilter_SelectedIndexChanged;
            // 
            // lblUserFilter
            // 
            lblUserFilter.AutoSize = true;
            lblUserFilter.Location = new Point(26, 17);
            lblUserFilter.Name = "lblUserFilter";
            lblUserFilter.Size = new Size(78, 15);
            lblUserFilter.TabIndex = 6;
            lblUserFilter.Text = "Filter by User:";
            // 
            // frmActivityLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 422);
            Controls.Add(lblUserFilter);
            Controls.Add(cmbUserFilter);
            Controls.Add(lblDateRange);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(btnRefresh);
            Controls.Add(dgvLogs);
            Name = "frmActivityLog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Activity Log (Audit Trail)";
            Load += frmActivityLog_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.ComboBox cmbUserFilter;
        private System.Windows.Forms.Label lblUserFilter;
    }
}