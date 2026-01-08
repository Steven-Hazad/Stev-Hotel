using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class CheckIn
    {
        [Key]
        public int CheckInID { get; set; }
        public DateTime CheckInTime { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; } = null!;

        public CheckOut? CheckOut { get; set; }
        public Invoice? Invoice { get; set; }
    }
}