using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Cancelled

        public int GuestID { get; set; }
        public Guest Guest { get; set; } = null!;

        public int RoomID { get; set; }
        public Room Room { get; set; } = null!;

        public CheckIn? CheckIn { get; set; }
    }
}