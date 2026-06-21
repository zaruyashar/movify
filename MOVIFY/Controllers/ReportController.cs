using Microsoft.AspNetCore.Mvc;
using MOVIFY.Services;

namespace MOVIFY.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DownloadMoviesReport()
        {
            var content = _reportService.GenerateMoviesReport();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "Movies_Archive.xlsx";

            return File(content, contentType, fileName);
        }

        public IActionResult DownloadCategoriesReport()
        {
            var content = _reportService.GenerateCategoriesReport();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "Categories_Summary.xlsx";

            return File(content, contentType, fileName);
        }

        public IActionResult DownloadDirectorsReport()
        {
            var content = _reportService.GenerateDirectorsReport();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "Directors_Master_List.xlsx";

            return File(content, contentType, fileName);
        }

        public IActionResult DownloadAnalyticsReport()
        {
            var content = _reportService.GenerateAnalyticsReport();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "System_Analytics.xlsx";

            return File(content, contentType, fileName);
        }
    }
}