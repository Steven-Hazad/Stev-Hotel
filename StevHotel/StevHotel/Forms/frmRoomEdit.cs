using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmRoomEdit : Form
    {
        private readonly HotelDbContext _db;
        private Room _room; // null for new room

        public frmRoomEdit(Room room = null)
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
            _room = room;
        }

        private void frmRoomEdit_Load(object sender, EventArgs e)
        {
            // Load room types into combo
            cmbRoomType.DataSource = _db.RoomTypes.ToList();
            cmbRoomType.DisplayMember = "TypeName";
            cmbRoomType.ValueMember = "RoomTypeID";

            if (_room != null)
            {
                // Edit mode
                this.Text = "Edit Room";
                txtRoomNumber.Text = _room.RoomNumber;
                numFloor.Value = _room.Floor ?? 0;
                cmbRoomType.SelectedValue = _room.RoomTypeID;
                cmbStatus.SelectedItem = _room.Status;
            }
            else
            {
                // Add mode
                this.Text = "Add New Room";
                cmbStatus.SelectedIndex = 0; // Default to Available
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Room number is required.");
                return;
            }

            if (cmbRoomType.SelectedValue == null)
            {
                MessageBox.Show("Select a room type.");
                return;
            }

            if (_room == null)
            {
                // New room
                _room = new Room
                {
                    RoomNumber = txtRoomNumber.Text.Trim(),
                    Floor = (int)numFloor.Value,
                    RoomTypeID = (int)cmbRoomType.SelectedValue,
                    Status = cmbStatus.SelectedItem.ToString()
                };
                _db.Rooms.Add(_room);
            }
            else
            {
                // Update existing
                _room.RoomNumber = txtRoomNumber.Text.Trim();
                _room.Floor = (int)numFloor.Value;
                _room.RoomTypeID = (int)cmbRoomType.SelectedValue;
                _room.Status = cmbStatus.SelectedItem.ToString();
            }

            _db.SaveChanges();
            MessageBox.Show("Room saved successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}