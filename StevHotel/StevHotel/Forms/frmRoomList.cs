using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmRoomList : Form
    {
        private readonly HotelDbContext _db;

        public frmRoomList()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmRoomList_Load(object sender, EventArgs e)
        {
            LoadRooms();

            // Populate filter combo
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Available");
            cmbStatusFilter.Items.Add("Reserved");
            cmbStatusFilter.Items.Add("Occupied");
            cmbStatusFilter.Items.Add("Cleaning");
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void LoadRooms()
        {
            var rooms = _db.Rooms
                .Include(r => r.RoomType)
                .AsQueryable();

            string filter = cmbStatusFilter.SelectedItem?.ToString();
            if (filter != null && filter != "All")
            {
                rooms = rooms.Where(r => r.Status == filter);
            }

            dgvRooms.DataSource = rooms
                .Select(r => new
                {
                    r.RoomID,
                    r.RoomNumber,
                    RoomType = r.RoomType.TypeName,
                    r.Floor,
                    r.Status,
                    Price = r.RoomType.PricePerNight
                })
                .ToList();

            // Auto-size columns nicely
            dgvRooms.Columns["RoomID"].Visible = false;
            dgvRooms.Columns["RoomNumber"].HeaderText = "Room No.";
            dgvRooms.Columns["RoomType"].HeaderText = "Type";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRooms();
        }

        // Placeholder for Add/Edit/Delete (we'll implement next)
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Room form coming soon...");
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a room first.");
                return;
            }
            MessageBox.Show("Edit form coming soon...");
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a room first.");
                return;
            }

            if (MessageBox.Show("Delete this room?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // We'll implement delete logic next round
                MessageBox.Show("Delete coming soon...");
            }
        }
    }
}