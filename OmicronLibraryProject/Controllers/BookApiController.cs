using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmicronLibraryProject.Models;
using OmicronLibraryProject.Services.BookServices;

namespace OmicronLibraryProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookApiController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BookApiController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet("allBooks")]
		public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
		{
			var books = await _bookService.GetAllAsync();
			return Ok(books);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> GetBook(int id)
		{
			var book = await _bookService.GetByIdAsync(id);
			if (book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}
	}
}