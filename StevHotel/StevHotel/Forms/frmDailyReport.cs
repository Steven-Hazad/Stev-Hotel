using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using StevHotel.Data;

namespace StevHotel.Forms
{
    public partial class frmDailyReport : Form
    {
        private readonly HotelDbContext _db;

        public frmDailyReport()
        {
            InitializeComponent();
            _db = Program.ServiceProvider.GetRequiredService<HotelDbContext>();
        }

        private void frmDailyReport_Load(object sender, EventArgs e)
        {
            LoadDailySummary();
        }

        private void LoadDailySummary()
        {
            var today = DateTime.Today;

            int totalRooms = _db.Rooms.Count();
            int occupied = _db.Rooms.Count(r => r.Status == "Occupied");
            double occupancy = totalRooms > 0 ? (occupied * 100.0 / totalRooms) : 0;

            decimal revenue = _db.Payments
                .Where(p => p.PaymentDate.Date == today)
                .Sum(p => p.Amount);

            int arrivals = _db.Reservations
                .Count(r => r.CheckInDate.Date == today && r.Status != "Cancelled");

            int departures = _db.Reservations
                .Count(r => r.CheckOutDate.Date == today && r.Status != "Cancelled");

            // Show in grid (single row summary)
            var data = new[]
            {
                new
                {
                    Metric = "Total Rooms",
                    Value = totalRooms.ToString(),
                    Details = "Total rooms in system"
                },
                new
                {
                    Metric = "Occupied Rooms",
                    Value = occupied.ToString(),
                    Details = "Currently occupied"
                },
                new
                {
                    Metric = "Occupancy %",
                    Value = $"{occupancy:F1}%",
                    Details = "Percentage of rooms occupied"
                },
                new
                {
                    Metric = "Revenue Today",
                    Value = revenue.ToString("N2") + " USD",
                    Details = "Total payments received today"
                },
                new
                {
                    Metric = "Arrivals Today",
                    Value = arrivals.ToString(),
                    Details = "Expected guest check-ins today"
                },
                new
                {
                    Metric = "Departures Today",
                    Value = departures.ToString(),
                    Details = "Expected guest check-outs today"
                }
            };

            dgvReport.DataSource = data;

            // Style the grid
            dgvReport.Columns["Metric"].HeaderText = "Metric";
            dgvReport.Columns["Value"].HeaderText = "Value";
            dgvReport.Columns["Details"].HeaderText = "Details";
            dgvReport.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPageHandler;
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // Simple text print (you can make it fancier with DrawString positions)
            using (Font font = new Font("Segoe UI", 12))
            {
                int y = 100;
                e.Graphics.DrawString("Stev-Hotel Daily Summary Report", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, 100, y);
                y += 40;
                e.Graphics.DrawString($"Date: {DateTime.Today:dd/MM/yyyy}", font, Brushes.Black, 100, y);
                y += 40;

                // Draw grid data
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    string line = $"{row.Cells[0].Value,-30} | {row.Cells[1].Value,-15} | {row.Cells[2].Value}";
                    e.Graphics.DrawString(line, font, Brushes.Black, 100, y);
                    y += 25;
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export to Excel coming soon (use NuGet: EPPlus or ClosedXML)");
            // Later: add EPPlus to export dgvReport to .xlsx
        }
    }
}