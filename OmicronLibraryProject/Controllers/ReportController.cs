using Microsoft.AspNetCore.Mvc;
using OmicronLibraryProject.Services.ReportServices;

namespace OmicronLibraryProject.Controllers
{
	public class ReportController : Controller
	{
		private readonly ILibraryReportService _libraryReportService;

		public ReportController(ILibraryReportService libraryReportService)
		{
			_libraryReportService = libraryReportService;
		}

		public IActionResult LibraryReport()
		{
			var libraryReport = _libraryReportService.GenerateLibraryReport();
			return View(libraryReport);
		}
	}
}
