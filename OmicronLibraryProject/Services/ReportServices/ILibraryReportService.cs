using OmicronLibraryProject.Models;

namespace OmicronLibraryProject.Services.ReportServices
{
	public interface ILibraryReportService
	{
		List<LibraryReportItem> GenerateLibraryReport();
	}
}
