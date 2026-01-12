using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using StevHotel.Models;

namespace StevHotel.Data
{
    public static class SeedData
    {
        public static void EnsureAdminUser(HotelDbContext context)
        {
            // Only create if admin doesn't exist
            if (!context.Users.Any(u => u.Username == "admin1"))
            {
                var admin = new User
                {
                    Username = "admin1",
                    FullName = "System Administrator",
                    RoleID = 1,          // Admin
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                // Use a strong password (you should change this later!)
                admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@2025");

                context.Users.Add(admin);
                context.SaveChanges();

                // Optional: Log that we created admin
                Console.WriteLine("Default admin user created successfully.");
            }
        }
    }
}