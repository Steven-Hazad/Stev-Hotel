using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmCleaningSchedule : Form
    {
        private readonly HotelDbContext _db;

        public frmCleaningSchedule()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmCleaningSchedule_Load(object sender, EventArgs e)
        {
            // Floor filter
            var floors = _db.Rooms.Select(r => r.Floor).Distinct().OrderBy(f => f).ToList();
            cmbFloorFilter.Items.Add("All Floors");
            foreach (var f in floors)
                cmbFloorFilter.Items.Add(f);
            cmbFloorFilter.SelectedIndex = 0;

            LoadCleaningList();
        }

        private void LoadCleaningList()
        {
            var rooms = _db.Rooms
                .Include(r => r.RoomType)
                .AsQueryable();

            // Show rooms that need cleaning: Cleaning status or Occupied but check-out today
            rooms = rooms.Where(r => r.Status == "Cleaning" ||
                                    (r.Status == "Occupied" &&
                                     _db.CheckIns.Any(ci => ci.Reservation.RoomID == r.RoomID &&
                                                           ci.Reservation.CheckOutDate.Date <= DateTime.Today)));

            // Floor filter
            if (cmbFloorFilter.SelectedIndex > 0 && cmbFloorFilter.SelectedItem is int floor)
            {
                rooms = rooms.Where(r => r.Floor == floor);
            }

            dgvCleaning.DataSource = rooms
                .Select(r => new
                {
                    r.RoomID,
                    r.RoomNumber,
                    Type = r.RoomType.TypeName,
                    r.Floor,
                    r.Status,
                    NeedsCleaning = r.Status == "Cleaning" ? "Yes" : "Check-Out Today"
                })
                .ToList();

            if (dgvCleaning.Columns["RoomID"] != null)
                dgvCleaning.Columns["RoomID"].Visible = false;

            dgvCleaning.Columns["NeedsCleaning"].HeaderText = "Needs Cleaning";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCleaningList();
        }

        private void cmbFloorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCleaningList();
        }

        private void btnMarkReady_Click(object sender, EventArgs e)
        {
            if (dgvCleaning.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a room to mark as ready.");
                return;
            }

            int roomId = (int)dgvCleaning.SelectedRows[0].Cells["RoomID"].Value;
            var room = _db.Rooms.Find(roomId);

            if (room == null)
            {
                MessageBox.Show("Room not found.");
                return;
            }

            if (MessageBox.Show($"Mark room {room.RoomNumber} as Ready / Available?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                room.Status = "Available";
                _db.SaveChanges();
                MessageBox.Show("Room marked as Ready.");
                LoadCleaningList();
            }
        }
    }
}