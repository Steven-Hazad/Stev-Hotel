using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StevHotel;
using StevHotel.Data;

// Create the host builder (this automatically loads appsettings.json!)
var builder = Host.CreateApplicationBuilder(args);

// Configure DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add other services if needed later (e.g., scoped services)

// Build the host
var host = builder.Build();

// Apply migrations and create DB if it doesn't exist
using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    db.Database.Migrate();  // This creates the DB and applies migrations
}

// WinForms setup
ApplicationConfiguration.Initialize();
Application.Run(new frmLogin());