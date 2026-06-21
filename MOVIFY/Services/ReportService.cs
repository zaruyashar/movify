using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using MOVIFY.Data.Data;
using System.IO;
using System.Linq;

namespace MOVIFY.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public byte[] GenerateMoviesReport()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Director)
                .ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Movies Archive");

            worksheet.Cell(1, 1).Value = "Movie ID";
            worksheet.Cell(1, 2).Value = "Title";
            worksheet.Cell(1, 3).Value = "Release Year";
            worksheet.Cell(1, 4).Value = "Category";
            worksheet.Cell(1, 5).Value = "Director";

            var headerRange = worksheet.Range("A1:E1");
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#8e44ad");
            headerRange.Style.Font.FontColor = XLColor.White;

            int row = 2;
            foreach (var movie in movies)
            {
                worksheet.Cell(row, 1).Value = movie.MovieId;
                worksheet.Cell(row, 2).Value = movie.MovieTitle;
                worksheet.Cell(row, 3).Value = movie.ReleaseYear;
                worksheet.Cell(row, 4).Value = movie.Category?.CategoryName;
                worksheet.Cell(row, 5).Value = movie.Director?.DirectorFullName;
                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] GenerateCategoriesReport()
        {
            var categories = _context.Categories.Include(c => c.Movies).ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Categories Summary");

            worksheet.Cell(1, 1).Value = "Category ID";
            worksheet.Cell(1, 2).Value = "Category Name";
            worksheet.Cell(1, 3).Value = "Total Movies";

            var headerRange = worksheet.Range("A1:C1");
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#1e88e5");
            headerRange.Style.Font.FontColor = XLColor.White;

            int row = 2;
            foreach (var category in categories)
            {
                worksheet.Cell(row, 1).Value = category.CategoryId;
                worksheet.Cell(row, 2).Value = category.CategoryName;
                worksheet.Cell(row, 3).Value = category.Movies?.Count ?? 0;
                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] GenerateDirectorsReport()
        {
            var directors = _context.Directors.Include(d => d.Movies).ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Directors Master List");

            worksheet.Cell(1, 1).Value = "Director ID";
            worksheet.Cell(1, 2).Value = "Full Name";
            worksheet.Cell(1, 3).Value = "Directed Movies Count";

            var headerRange = worksheet.Range("A1:C1");
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#26c6da");
            headerRange.Style.Font.FontColor = XLColor.White;

            int row = 2;
            foreach (var director in directors)
            {
                worksheet.Cell(row, 1).Value = director.DirectorId;
                worksheet.Cell(row, 2).Value = director.DirectorFullName;
                worksheet.Cell(row, 3).Value = director.Movies?.Count ?? 0;
                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] GenerateAnalyticsReport()
        {
            var totalMovies = _context.Movies.Count();
            var totalCategories = _context.Categories.Count();
            var totalDirectors = _context.Directors.Count();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("System Analytics");

            worksheet.Cell(1, 1).Value = "System Metric";
            worksheet.Cell(1, 2).Value = "Total Count";

            var headerRange = worksheet.Range("A1:B1");
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#ffb22b");
            headerRange.Style.Font.FontColor = XLColor.White;

            worksheet.Cell(2, 1).Value = "Total Registered Movies";
            worksheet.Cell(2, 2).Value = totalMovies;

            worksheet.Cell(3, 1).Value = "Total Genres/Categories";
            worksheet.Cell(3, 2).Value = totalCategories;

            worksheet.Cell(4, 1).Value = "Total Directors on File";
            worksheet.Cell(4, 2).Value = totalDirectors;

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}