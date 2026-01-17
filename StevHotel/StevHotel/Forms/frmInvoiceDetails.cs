using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmInvoiceDetails : Form
    {
        private readonly HotelDbContext _db;
        private readonly Invoice _invoice;

        public frmInvoiceDetails(Invoice invoice)
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
            _invoice = invoice;
        }

        private void frmInvoiceDetails_Load(object sender, EventArgs e)
        {
            _db.Entry(_invoice).Collection(i => i.Items).Load();
            _db.Entry(_invoice).Collection(i => i.Payments).Load();
            _db.Entry(_invoice.CheckIn.Reservation).Reference(r => r.Guest).Load();
            _db.Entry(_invoice.CheckIn.Reservation).Reference(r => r.Room).Load();

            lblGuest.Text = $"Guest: {_invoice.CheckIn.Reservation.Guest.FullName}";
            lblRoom.Text = $"Room: {_invoice.CheckIn.Reservation.Room.RoomNumber}";
            lblTotal.Text = $"Total: {_invoice.TotalAmount:N2} USD";
            lblStatus.Text = $"Status: {_invoice.Status}";

            LoadItems();
            LoadPayments();
        }

        private void LoadItems()
        {
            dgvInvoiceItems.DataSource = _invoice.Items
                .Select(it => new
                {
                    Description = it.Description,
                    Amount = it.Amount.ToString("N2") + " USD"
                })
                .ToList();
        }

        private void LoadPayments()
        {
            dgvPayments.DataSource = _invoice.Payments
                .Select(p => new
                {
                    p.Amount.ToString("N2") + " USD",
                    p.PaymentMethod,
                    p.PaymentDate.ToShortDateString()
                })
                .ToList();
        }

        private void btnAddExtra_Click(object sender, EventArgs e)
        {
            string desc = Microsoft.VisualBasic.Interaction.InputBox("Extra description (e.g. Mini-bar):", "Add Extra");
            if (string.IsNullOrWhiteSpace(desc)) return;

            string amtStr = Microsoft.VisualBasic.Interaction.InputBox("Amount (USD):", "Add Extra");
            if (!decimal.TryParse(amtStr, out decimal amt) || amt <= 0)
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            var item = new InvoiceItem
            {
                InvoiceID = _invoice.InvoiceID,
                Description = desc,
                Amount = amt
            };
            _db.InvoiceItems.Add(item);

            _invoice.TotalAmount += amt;
            _db.SaveChanges();

            LoadItems();
            lblTotal.Text = $"Total: {_invoice.TotalAmount:N2} USD";
            MessageBox.Show("Extra added.");
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            string amtStr = Microsoft.VisualBasic.Interaction.InputBox("Payment amount (USD):", "Add Payment");
            if (!decimal.TryParse(amtStr, out decimal amt) || amt <= 0)
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            string method = Microsoft.VisualBasic.Interaction.InputBox("Payment method (Cash/Card):", "Add Payment", "Cash");
            if (string.IsNullOrWhiteSpace(method)) return;

            var payment = new Payment
            {
                InvoiceID = _invoice.InvoiceID,
                Amount = amt,
                PaymentMethod = method,
                PaymentDate = DateTime.Now
            };
            _db.Payments.Add(payment);

            _db.SaveChanges();

            LoadPayments();
            MessageBox.Show("Payment added.");
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            if (_invoice.Status == "Paid")
            {
                MessageBox.Show("Invoice already paid.");
                return;
            }

            if (MessageBox.Show("Mark invoice as Paid?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _invoice.Status = "Paid";
                _db.SaveChanges();
                lblStatus.Text = "Status: Paid";
                MessageBox.Show("Invoice marked as Paid.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}