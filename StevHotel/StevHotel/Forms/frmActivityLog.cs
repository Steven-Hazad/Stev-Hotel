using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;

namespace StevHotel.Forms
{
    public partial class frmActivityLog : Form
    {
        private readonly HotelDbContext _db;

        public frmActivityLog()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmActivityLog_Load(object sender, EventArgs e)
        {
            // Populate user filter (only admins see all)
            var users = _db.Users
                .Select(u => new { u.UserID, Display = $"{u.Username} ({u.FullName})" })
                .ToList();

            cmbUserFilter.Items.Add(new { UserID = 0, Display = "All Users" });
            foreach (var u in users)
                cmbUserFilter.Items.Add(u);

            cmbUserFilter.DisplayMember = "Display";
            cmbUserFilter.ValueMember = "UserID";
            cmbUserFilter.SelectedIndex = 0;

            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;

            LoadLogs();
        }

        private void LoadLogs()
        {
            var logs = _db.ActivityLogs
                .Include(l => l.User)
                .AsQueryable();

            // Date filter
            logs = logs.Where(l => l.Timestamp >= dtpFrom.Value && l.Timestamp <= dtpTo.Value.AddDays(1));

            // User filter
            if (cmbUserFilter.SelectedValue is int userId && userId > 0)
            {
                logs = logs.Where(l => l.UserID == userId);
            }

            dgvLogs.DataSource = logs
                .OrderByDescending(l => l.Timestamp)
                .Select(l => new
                {
                    Timestamp = l.Timestamp.ToString("dd/MM/yyyy HH:mm"),
                    User = l.User != null ? l.User.Username : "System",
                    Action = l.Action,
                    Details = l.Details
                })
                .ToList();

            // Auto-size columns
            dgvLogs.Columns["Timestamp"].Width = 140;
            dgvLogs.Columns["User"].Width = 120;
            dgvLogs.Columns["Action"].Width = 200;
            dgvLogs.Columns["Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadLogs();

        private void dtpFrom_ValueChanged(object sender, EventArgs e) => LoadLogs();
        private void dtpTo_ValueChanged(object sender, EventArgs e) => LoadLogs();
        private void cmbUserFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadLogs();
    }
}