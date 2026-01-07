using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty; // Single, Double, etc.
        public string? Description { get; set; }
        public decimal PricePerNight { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
