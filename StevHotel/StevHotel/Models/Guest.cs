using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? NationalID { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}