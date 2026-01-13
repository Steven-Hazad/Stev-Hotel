using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StevHotel.Data;
using StevHotel.Forms;
using StevHotel.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StevHotel
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = Host.CreateApplicationBuilder();

            // Register DbContext
            builder.Services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            var host = builder.Build();

            // Run migrations & seed data
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();

                db.Database.Migrate();

                // Seed admin user
                SeedData.EnsureAdminUser(db);

                // Seed room types & rooms (run only once)
                if (!db.RoomTypes.Any())
                {
                    var types = new[]
                    {
                        new RoomType { TypeName = "Single", Description = "Basic single bed room", PricePerNight = 35.00m },
                        new RoomType { TypeName = "Double", Description = "Queen bed for two", PricePerNight = 55.00m },
                        new RoomType { TypeName = "Deluxe", Description = "King bed + balcony", PricePerNight = 85.00m },
                        new RoomType { TypeName = "Suite", Description = "Luxury suite with living area", PricePerNight = 150.00m }
                    };

                    db.RoomTypes.AddRange(types);
                    db.SaveChanges();

                    var rooms = new[]
                    {
                        new Room { RoomNumber = "101", Floor = 1, RoomTypeID = 1, Status = "Available" },
                        new Room { RoomNumber = "102", Floor = 1, RoomTypeID = 1, Status = "Cleaning" },
                        new Room { RoomNumber = "201", Floor = 2, RoomTypeID = 2, Status = "Occupied" },
                        new Room { RoomNumber = "202", Floor = 2, RoomTypeID = 2, Status = "Reserved" },
                        new Room { RoomNumber = "301", Floor = 3, RoomTypeID = 3, Status = "Available" },
                        new Room { RoomNumber = "401", Floor = 4, RoomTypeID = 4, Status = "Available" }
                    };

                    db.Rooms.AddRange(rooms);
                    db.SaveChanges();
                }
            }

            ServiceProvider = host.Services;

            // Start WinForms app
            Application.Run(new frmLogin());
        }
    }
}
