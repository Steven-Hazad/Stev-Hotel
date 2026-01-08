using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Card
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; } = null!;
    }
}