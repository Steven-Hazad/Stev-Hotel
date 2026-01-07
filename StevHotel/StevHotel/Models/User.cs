using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int RoleID { get; set; }
        public Role Role { get; set; } = null!;

        // Navigation
        public ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();
    }
}