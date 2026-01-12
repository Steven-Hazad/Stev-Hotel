using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StevHotel.Data;
using StevHotel.Forms;

namespace StevHotel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Use modern host builder
            var builder = Host.CreateApplicationBuilder();

            // Register DbContext with connection string from appsettings.json
            builder.Services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var host = builder.Build();

            // Apply migrations + seed data
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<HotelDbContext>();

                // 1. Apply any pending migrations (create/update DB schema)
                dbContext.Database.Migrate();

                // 2. Seed default admin user if needed
                SeedData.EnsureAdminUser(dbContext);
            }

            // Start the login form
            Application.Run(new frmLogin());
        }
    }
}