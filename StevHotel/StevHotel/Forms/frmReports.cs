using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using StevHotel.Data;
using Microsoft.Reporting.WinForms;

namespace StevHotel.Forms
{
    public partial class frmReports : Form
    {
        private readonly HotelDbContext _db;

        public frmReports()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            // We'll load data on button clicks
        }

        private void btnDailySummary_Click(object sender, EventArgs e)
        {
            var reportDate = dtpReportDate.Value.Date;

            // Total rooms
            int totalRooms = _db.Rooms.Count();

            // Occupied
            int occupied = _db.Rooms.Count(r => r.Status == "Occupied");

            double occupancy = totalRooms > 0 ? (occupied * 100.0 / totalRooms) : 0;

            // Revenue today
            decimal revenue = _db.Payments
                .Where(p => p.PaymentDate.Date == reportDate)
                .Sum(p => (decimal?)p.Amount) ?? 0m;

            // Arrivals / Departures
            int arrivals = _db.Reservations
                .Count(r => r.CheckInDate.Date == reportDate && r.Status != "Cancelled");

            int departures = _db.Reservations
                .Count(r => r.CheckOutDate.Date == reportDate && r.Status != "Cancelled");

            // Create dataset for RDLC
            var ds = new DataSet("DailySummary");
            var dt = new DataTable("Summary");
            dt.Columns.Add("ReportDate", typeof(string));
            dt.Columns.Add("TotalRooms", typeof(int));
            dt.Columns.Add("Occupied", typeof(int));
            dt.Columns.Add("OccupancyPercent", typeof(double));
            dt.Columns.Add("Revenue", typeof(decimal));
            dt.Columns.Add("Arrivals", typeof(int));
            dt.Columns.Add("Departures", typeof(int));

            dt.Rows.Add(
                reportDate.ToShortDateString(),
                totalRooms,
                occupied,
                occupancy,
                revenue,
                arrivals,
                departures
            );

            ds.Tables.Add(dt);

            reportViewer1.LocalReport.ReportEmbeddedResource = "StevHotel.Reports.rdlcDailySummary.rdlc"; // we'll create this next
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDailySummary", ds.Tables["Summary"]));

            reportViewer1.RefreshReport();
        }

        // Placeholder for other reports
        private void btnOccupancyReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Occupancy report coming soon...");
        }

        private void btnGuestHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Guest history report coming soon...");
        }
    }
}