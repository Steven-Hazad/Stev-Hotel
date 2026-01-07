using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevHotel.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;

        // Navigation
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}