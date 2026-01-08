using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class InvoiceItem
    {
        [Key]
        public int ItemID { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; } = null!;
    }
}