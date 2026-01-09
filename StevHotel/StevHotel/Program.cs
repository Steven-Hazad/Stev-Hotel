using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StevHotel;
using StevHotel.Data;
using StevHotel.Forms;  // Adjust if your frmLogin namespace is different

// Create the host builder - this automatically discovers and loads appsettings.json
var builder = Host.CreateApplicationBuilder();

// Add services to the container
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build the host
var host = builder.Build();

// Ensure database is created and migrations are applied
using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    dbContext.Database.Migrate();  // This will now work because config is loaded
}

// Run the WinForms application
ApplicationConfiguration.Initialize();
Application.Run(new StevHotel.Forms.frmLogin());