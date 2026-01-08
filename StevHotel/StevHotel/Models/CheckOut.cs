using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class CheckOut
    {
        [Key]
        public int CheckOutID { get; set; }
        public DateTime CheckOutTime { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

        public int CheckInID { get; set; }
        public CheckIn CheckIn { get; set; } = null!;
    }
}