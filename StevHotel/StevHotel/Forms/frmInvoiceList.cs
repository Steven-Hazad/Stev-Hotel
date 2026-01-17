using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmInvoiceList : Form
    {
        private readonly HotelDbContext _db;

        public frmInvoiceList()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmInvoiceList_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.Items.AddRange(new[] { "All", "Unpaid", "Paid" });
            cmbStatusFilter.SelectedIndex = 0;

            LoadInvoices();
        }

        private void LoadInvoices()
        {
            var invoices = _db.Invoices
                .Include(i => i.CheckIn)
                    .ThenInclude(ci => ci.Reservation)
                        .ThenInclude(r => r.Guest)
                .Include(i => i.CheckIn)
                    .ThenInclude(ci => ci.Reservation)
                        .ThenInclude(r => r.Room)
                .AsQueryable();

            string status = cmbStatusFilter.SelectedItem?.ToString();
            if (status != "All")
            {
                invoices = invoices.Where(i => i.Status == status);
            }

            dgvInvoices.DataSource = invoices
                .Select(i => new
                {
                    i.InvoiceID,
                    Guest = i.CheckIn.Reservation.Guest.FullName,
                    Room = i.CheckIn.Reservation.Room.RoomNumber,
                    Issued = i.IssuedDate.ToShortDateString(),
                    Total = i.TotalAmount.ToString("N2") + " USD",
                    Status = i.Status
                })
                .ToList();

            if (dgvInvoices.Columns["InvoiceID"] != null)
                dgvInvoices.Columns["InvoiceID"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an invoice to view/edit.");
                return;
            }

            int invoiceId = (int)dgvInvoices.SelectedRows[0].Cells["InvoiceID"].Value;
            var invoice = _db.Invoices
                .Include(i => i.CheckIn)
                    .ThenInclude(ci => ci.Reservation)
                        .ThenInclude(r => r.Guest)
                .Include(i => i.CheckIn)
                    .ThenInclude(ci => ci.Reservation)
                        .ThenInclude(r => r.Room)
                .FirstOrDefault(i => i.InvoiceID == invoiceId);

            if (invoice == null)
            {
                MessageBox.Show("Invoice not found.");
                return;
            }

            using (var details = new frmInvoiceDetails(invoice))
            {
                details.ShowDialog();
                LoadInvoices(); // refresh list after edit
            }
        }
    }
}