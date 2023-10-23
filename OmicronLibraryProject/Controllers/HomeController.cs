using Microsoft.AspNetCore.Mvc;
using OmicronLibraryProject.Models;
using OmicronLibraryProject.Services.BookServices;
using System.Diagnostics;

namespace OmicronLibraryProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IBookService _bookService;
		public HomeController(ILogger<HomeController> logger, IBookService bookService)
		{
			_logger = logger;
			_bookService = bookService;
		}

		public IActionResult Index()
        {
            var books = _bookService.GetAll();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}