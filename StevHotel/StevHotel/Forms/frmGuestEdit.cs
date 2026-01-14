using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmGuestEdit : Form
    {
        private readonly HotelDbContext _db;
        private Guest _guest; // ✅ removed readonly

        public frmGuestEdit(Guest guest = null)
        {
            InitializeComponent();

            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
            _guest = guest;

            if (_guest != null)
            {
                Text = "Edit Guest";
                btnSave.Text = "Update";
            }
        }

        private void frmGuestEdit_Load(object sender, EventArgs e)
        {
            if (_guest != null)
            {
                txtFullName.Text = _guest.FullName;
                txtPhone.Text = _guest.Phone;
                txtNationalID.Text = _guest.NationalID ?? "";
                txtAddress.Text = _guest.Address ?? "";
                txtEmail.Text = _guest.Email ?? "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Full Name and Phone are required.");
                return;
            }

            if (_guest == null)
            {
                // Add new guest
                _guest = new Guest
                {
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    NationalID = txtNationalID.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    CreatedAt = DateTime.Now
                };

                _db.Guests.Add(_guest);
            }
            else
            {
                // Update existing guest
                _guest.FullName = txtFullName.Text.Trim();
                _guest.Phone = txtPhone.Text.Trim();
                _guest.NationalID = txtNationalID.Text.Trim();
                _guest.Address = txtAddress.Text.Trim();
                _guest.Email = txtEmail.Text.Trim();
            }

            try
            {
                _db.SaveChanges();
                MessageBox.Show("Guest saved successfully!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving guest: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
