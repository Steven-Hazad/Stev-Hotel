using System.ComponentModel;
using System.Windows.Forms;

namespace StevHotel.Forms
{
    partial class frmRoomList
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvRooms = new DataGridView();
            this.btnRefresh = new Button();
            this.btnAddRoom = new Button();
            this.btnEditRoom = new Button();
            this.btnDeleteRoom = new Button();
            this.cmbStatusFilter = new ComboBox();
            this.lblFilter = new Label();

            // Quick status buttons
            this.btnSetAvailable = new Button();
            this.btnSetCleaning = new Button();
            this.btnSetOccupied = new Button();
            this.btnSetReserved = new Button();

            ((ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();

            // dgvRooms
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.Location = new System.Drawing.Point(12, 55);
            this.dgvRooms.MultiSelect = false;
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(776, 350);
            this.dgvRooms.TabIndex = 0;

            // btnRefresh
            this.btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnRefresh.Location = new System.Drawing.Point(713, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnAddRoom
            this.btnAddRoom.Location = new System.Drawing.Point(12, 12);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(90, 30);
            this.btnAddRoom.Text = "Add";
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);

            // btnEditRoom
            this.btnEditRoom.Location = new System.Drawing.Point(108, 12);
            this.btnEditRoom.Name = "btnEditRoom";
            this.btnEditRoom.Size = new System.Drawing.Size(90, 30);
            this.btnEditRoom.Text = "Edit";
            this.btnEditRoom.Click += new System.EventHandler(this.btnEditRoom_Click);

            // btnDeleteRoom
            this.btnDeleteRoom.Location = new System.Drawing.Point(204, 12);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(90, 30);
            this.btnDeleteRoom.Text = "Delete";
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);

            // btnSetAvailable
            this.btnSetAvailable.Location = new System.Drawing.Point(300, 12);
            this.btnSetAvailable.Name = "btnSetAvailable";
            this.btnSetAvailable.Size = new System.Drawing.Size(100, 30);
            this.btnSetAvailable.Text = "Available";
            this.btnSetAvailable.Click += new System.EventHandler(this.btnSetAvailable_Click);

            // btnSetCleaning
            this.btnSetCleaning.Location = new System.Drawing.Point(406, 12);
            this.btnSetCleaning.Name = "btnSetCleaning";
            this.btnSetCleaning.Size = new System.Drawing.Size(100, 30);
            this.btnSetCleaning.Text = "Cleaning";
            this.btnSetCleaning.Click += new System.EventHandler(this.btnSetCleaning_Click);

            // btnSetOccupied
            this.btnSetOccupied.Location = new System.Drawing.Point(512, 12);
            this.btnSetOccupied.Name = "btnSetOccupied";
            this.btnSetOccupied.Size = new System.Drawing.Size(100, 30);
            this.btnSetOccupied.Text = "Occupied";
            this.btnSetOccupied.Click += new System.EventHandler(this.btnSetOccupied_Click);

            // btnSetReserved
            this.btnSetReserved.Location = new System.Drawing.Point(618, 12);
            this.btnSetReserved.Name = "btnSetReserved";
            this.btnSetReserved.Size = new System.Drawing.Size(100, 30);
            this.btnSetReserved.Text = "Reserved";
            this.btnSetReserved.Click += new System.EventHandler(this.btnSetReserved_Click);

            // lblFilter
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 420);
            this.lblFilter.Text = "Filter:";

            // cmbStatusFilter
            this.cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Location = new System.Drawing.Point(60, 417);
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 24);
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);

            // frmRoomList
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnEditRoom);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.btnSetAvailable);
            this.Controls.Add(this.btnSetCleaning);
            this.Controls.Add(this.btnSetOccupied);
            this.Controls.Add(this.btnSetReserved);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Room Management";
            this.Load += new System.EventHandler(this.frmRoomList_Load);

            ((ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DataGridView dgvRooms;
        private Button btnRefresh;
        private Button btnAddRoom;
        private Button btnEditRoom;
        private Button btnDeleteRoom;
        private Button btnSetAvailable;
        private Button btnSetCleaning;
        private Button btnSetOccupied;
        private Button btnSetReserved;
        private ComboBox cmbStatusFilter;
        private Label lblFilter;
    }
}
