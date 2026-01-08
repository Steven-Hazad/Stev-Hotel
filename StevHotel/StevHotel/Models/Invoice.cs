using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime IssuedDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Unpaid";

        public int CheckInID { get; set; }
        public CheckIn CheckIn { get; set; } = null!;

        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}