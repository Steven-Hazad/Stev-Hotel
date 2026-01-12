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
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var host = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
                dbContext.Database.Migrate();
                SeedData.EnsureAdminUser(dbContext);
            }

            ServiceProvider = host.Services;

            Application.Run(new Forms.frmLogin());
        }
    }
}