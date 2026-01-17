namespace StevHotel.Forms
{
    partial class frmCleaningSchedule
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
            this.dgvCleaning = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMarkReady = new System.Windows.Forms.Button();
            this.cmbFloorFilter = new System.Windows.Forms.ComboBox();
            this.lblFloorFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCleaning)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCleaning
            // 
            this.dgvCleaning.AllowUserToAddRows = false;
            this.dgvCleaning.AllowUserToDeleteRows = false;
            this.dgvCleaning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCleaning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCleaning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCleaning.Location = new System.Drawing.Point(12, 50);
            this.dgvCleaning.Name = "dgvCleaning";
            this.dgvCleaning.ReadOnly = true;
            this.dgvCleaning.RowHeadersWidth = 51;
            this.dgvCleaning.RowTemplate.Height = 29;
            this.dgvCleaning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCleaning.Size = new System.Drawing.Size(776, 350);
            this.dgvCleaning.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(713, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMarkReady
            // 
            this.btnMarkReady.Location = new System.Drawing.Point(12, 12);
            this.btnMarkReady.Name = "btnMarkReady";
            this.btnMarkReady.Size = new System.Drawing.Size(140, 30);
            this.btnMarkReady.TabIndex = 2;
            this.btnMarkReady.Text = "Mark as Ready";
            this.btnMarkReady.UseVisualStyleBackColor = true;
            this.btnMarkReady.Click += new System.EventHandler(this.btnMarkReady_Click);
            // 
            // cmbFloorFilter
            // 
            this.cmbFloorFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloorFilter.Location = new System.Drawing.Point(450, 15);
            this.cmbFloorFilter.Name = "cmbFloorFilter";
            this.cmbFloorFilter.Size = new System.Drawing.Size(150, 24);
            this.cmbFloorFilter.TabIndex = 3;
            this.cmbFloorFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFloorFilter_SelectedIndexChanged);
            // 
            // lblFloorFilter
            // 
            this.lblFloorFilter.AutoSize = true;
            this.lblFloorFilter.Location = new System.Drawing.Point(380, 18);
            this.lblFloorFilter.Name = "lblFloorFilter";
            this.lblFloorFilter.Size = new System.Drawing.Size(64, 16);
            this.lblFloorFilter.TabIndex = 4;
            this.lblFloorFilter.Text = "Floor:";
            // 
            // frmCleaningSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFloorFilter);
            this.Controls.Add(this.cmbFloorFilter);
            this.Controls.Add(this.btnMarkReady);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvCleaning);
            this.Name = "frmCleaningSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Cleaning Schedule";
            this.Load += new System.EventHandler(this.frmCleaningSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCleaning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvCleaning;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMarkReady;
        private System.Windows.Forms.ComboBox cmbFloorFilter;
        private System.Windows.Forms.Label lblFloorFilter;
    }
}