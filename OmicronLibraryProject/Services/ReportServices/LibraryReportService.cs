using Microsoft.EntityFrameworkCore;
using OmicronLibraryProject.Context;
using OmicronLibraryProject.Models;
using OmicronLibraryProject.Services.LoanServices;

namespace OmicronLibraryProject.Services.ReportServices
{
	public class LibraryReportService : ILibraryReportService
	{
		private readonly LibraryDbContext _context;

		public LibraryReportService(LibraryDbContext context)
		{
			_context = context;
		}

		public List<LibraryReportItem> GenerateLibraryReport()
		{
			var libraryReport = _context.Loans
		.Where(loan => loan.ReturnedDate.HasValue)
		.Include(loan => loan.Book)
		.Include(loan => loan.User)
		.AsEnumerable()
		.Select(loan => new LibraryReportItem
		{
			ISBN = loan.Book.ISBN,
			BookTitle = loan.Book.Title,
			userTC = loan.User.TCIdentityNumber,
			TimeOutsideLibrary = TimeSpan.FromHours((loan.ReturnedDate.Value - loan.BorrowedDate).TotalHours)
		})
		.OrderByDescending(item => item.TimeOutsideLibrary)
		.ToList();

			return libraryReport;
		}
	}
}
