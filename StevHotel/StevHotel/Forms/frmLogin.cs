using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StevHotel.Data;
using StevHotel.Models;
using Microsoft.Extensions.DependencyInjection;

namespace StevHotel.Forms
{
    public partial class frmLogin : Form
    {
        private readonly HotelDbContext _dbContext;

        // Static current user (global access)
        public static User? CurrentUser { get; private set; }

        public frmLogin()
        {
            InitializeComponent();

            // ✅ Get DbContext from DI container
            _dbContext = Program.ServiceProvider
                .GetRequiredService<HotelDbContext>();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter username and password");
                return;
            }

            try
            {
                // ✅ Case-insensitive username lookup
                var user = _dbContext.Users
                    .Include(u => u.Role)
                    .AsNoTracking()
                    .FirstOrDefault(u =>
                        u.Username.ToLower() == username.ToLower()
                        && u.IsActive);

                if (user == null)
                {
                    ShowError("Invalid username or password");
                    return;
                }

                // ✅ BCrypt password verification
                if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    ShowError("Invalid username or password");
                    return;
                }

                // ✅ SUCCESS
                CurrentUser = user;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = $"Welcome {user.Username}!";

                // Open dashboard
                Hide();
                new frmDashboard().Show();
            }
            catch (Exception ex)
            {
                ShowError("Login failed: " + ex.Message);
            }
            finally
            {
                txtPassword.Clear(); // security
            }
        }

        private void ShowError(string message)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = message;
        }
    }
}
