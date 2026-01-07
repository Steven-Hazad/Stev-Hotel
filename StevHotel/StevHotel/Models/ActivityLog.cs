using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class ActivityLog
    {
        public int LogID { get; set; }
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string? Details { get; set; }

        public int UserID { get; set; }
        public User User { get; set; } = null!;
    }
}