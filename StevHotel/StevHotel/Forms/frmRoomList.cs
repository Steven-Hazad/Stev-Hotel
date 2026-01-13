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
            using (var addForm = new frmRoomEdit())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms(); // Refresh grid
                }
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to edit.");
                return;
            }

            int roomId = (int)dgvRooms.SelectedRows[0].Cells["RoomID"].Value;
            var selectedRoom = _db.Rooms.Find(roomId);

            using (var editForm = new frmRoomEdit(selectedRoom))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = (int)dgvRooms.SelectedRows[0].Cells["RoomID"].Value;
            string roomNumber = dgvRooms.SelectedRows[0].Cells["RoomNumber"].Value.ToString();

            // Safety check: don't delete if room is occupied/reserved
            var room = _db.Rooms.Find(roomId);
            if (room == null)
            {
                MessageBox.Show("Room not found.");
                return;
            }

            if (room.Status == "Occupied" || room.Status == "Reserved")
            {
                MessageBox.Show($"Cannot delete room {roomNumber} — it is currently {room.Status.ToLower()}.",
                                "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Delete room {roomNumber} ({room.RoomType.TypeName})?\nThis cannot be undone.",
                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _db.Rooms.Remove(room);
                    _db.SaveChanges();
                    MessageBox.Show("Room deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms(); // Refresh grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeRoomStatus(string newStatus)
{
    if (dgvRooms.SelectedRows.Count == 0)
    {
        MessageBox.Show("Select a room first.");
        return;
    }

    int roomId = (int)dgvRooms.SelectedRows[0].Cells["RoomID"].Value;
    var room = _db.Rooms.Find(roomId);

    if (room == null) return;

    room.Status = newStatus;
    _db.SaveChanges();

    MessageBox.Show($"Room {room.RoomNumber} status updated to {newStatus}.");
    LoadRooms();
}

private void btnSetAvailable_Click(object sender, EventArgs e) => ChangeRoomStatus("Available");
private void btnSetCleaning_Click(object sender, EventArgs e) => ChangeRoomStatus("Cleaning");
private void btnSetOccupied_Click(object sender, EventArgs e) => ChangeRoomStatus("Occupied");
private void btnSetReserved_Click(object sender, EventArgs e) => ChangeRoomStatus("Reserved");
    }
}