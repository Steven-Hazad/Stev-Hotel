using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmGuestList : Form
    {
        private readonly HotelDbContext _db;

        public frmGuestList()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmGuestList_Load(object sender, EventArgs e)
        {
            LoadGuests();
        }

        private void LoadGuests(string search = null)
        {
            var guests = _db.Guests.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();
                guests = guests.Where(g =>
                    g.FullName.ToLower().Contains(search) ||
                    g.Phone.Contains(search) ||
                    (g.NationalID != null && g.NationalID.ToLower().Contains(search)) ||
                    (g.Email != null && g.Email.ToLower().Contains(search)));
            }

            dgvGuests.DataSource = guests
                .Select(g => new
                {
                    g.GuestID,
                    g.FullName,
                    g.Phone,
                    g.NationalID,
                    g.Address,
                    g.Email,
                    Registered = g.CreatedAt.ToShortDateString()
                })
                .ToList();

            if (dgvGuests.Columns["GuestID"] != null)
                dgvGuests.Columns["GuestID"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGuests();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGuests(txtSearch.Text);
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            using (var frm = new frmGuestEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadGuests();
                }
            }
        }

        private void btnEditGuest_Click(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a guest to edit.");
                return;
            }

            int guestId = (int)dgvGuests.SelectedRows[0].Cells["GuestID"].Value;
            var guest = _db.Guests.Find(guestId);

            if (guest == null)
            {
                MessageBox.Show("Guest not found.");
                return;
            }

            using (var frm = new frmGuestEdit(guest))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadGuests();
                }
            }
        }
    }
}