using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;
using StevHotel.Models;

namespace StevHotel.Forms
{
    public partial class frmCheckOut : Form
    {
        private readonly HotelDbContext _db;
        private readonly CheckIn _checkIn;
        private decimal roomCharge;
        private decimal extras;
        private decimal total;

        public frmCheckOut(CheckIn checkIn)
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
            _checkIn = checkIn ?? throw new ArgumentNullException(nameof(checkIn));
        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            _db.Entry(_checkIn).Reference(ci => ci.Reservation).Load();
            _db.Entry(_checkIn.Reservation).Reference(r => r.Guest).Load();
            _db.Entry(_checkIn.Reservation).Reference(r => r.Room).Load();
            _db.Entry(_checkIn.Reservation.Room).Reference(r => r.RoomType).Load();

            lblGuest.Text = $"Guest: {_checkIn.Reservation.Guest.FullName} ({_checkIn.Reservation.Guest.Phone})";
            lblRoom.Text = $"Room: {_checkIn.Reservation.Room.RoomNumber} - {_checkIn.Reservation.Room.RoomType.TypeName}";
            lblStayDates.Text = $"Stay: {_checkIn.Reservation.CheckInDate:dd MMM yyyy} to {_checkIn.Reservation.CheckOutDate:dd MMM yyyy}";
            int nights = (_checkIn.Reservation.CheckOutDate - _checkIn.Reservation.CheckInDate).Days;
            lblNights.Text = $"Nights: {nights}";

            roomCharge = nights * _checkIn.Reservation.Room.RoomType.PricePerNight;
            lblRoomCharge.Text = $"Room Charge: {roomCharge:N2} USD";

            extras = 0;
            numExtras.Value = 0;
            UpdateTotal();

            cmbPaymentMethod.SelectedIndex = 0; // Default to Cash
        }

        private void numExtras_ValueChanged(object sender, EventArgs e)
        {
            extras = numExtras.Value;
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            total = roomCharge + extras;
            lblTotal.Text = "Total Amount:";
            lblTotalValue.Text = $"{total:N2} USD";
        }

        private void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Create and add CheckOut first
                var checkOut = new CheckOut
                {
                    CheckInID = _checkIn.CheckInID,
                    CheckOutTime = DateTime.Now,
                    Notes = "Checked out via system"
                };
                _db.CheckOuts.Add(checkOut);

                // 2. Create Invoice
                var invoice = new Invoice
                {
                    CheckInID = _checkIn.CheckInID,
                    TotalAmount = total,
                    IssuedDate = DateTime.Now,
                    Status = "Paid"
                };
                _db.Invoices.Add(invoice);

                // 3. Save changes → this generates InvoiceID
                _db.SaveChanges();

                // 4. Now that invoice has a real InvoiceID, create Payment
                var payment = new Payment
                {
                    InvoiceID = invoice.InvoiceID,   // ← now it's correct (e.g. 5)
                    Amount = total,
                    PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash",
                    PaymentDate = DateTime.Now
                };
                _db.Payments.Add(payment);

                // 5. Update room status
                _checkIn.Reservation.Room.Status = "Cleaning"; // or "Available"

                // 6. Optional: mark reservation as completed
                _checkIn.Reservation.Status = "Completed";

                // 7. Final save for payment + updates
                _db.SaveChanges();

                MessageBox.Show($"Check-out successful!\n" +
                                $"Invoice #{invoice.InvoiceID}\n" +
                                $"Total paid: {total:N2} USD ({cmbPaymentMethod.SelectedItem})\n" +
                                $"Room {_checkIn.Reservation.Room.RoomNumber} is now Cleaning.",
                                "Check-Out Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Check-out failed: {ex.Message}\n\nInner: {ex.InnerException?.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}