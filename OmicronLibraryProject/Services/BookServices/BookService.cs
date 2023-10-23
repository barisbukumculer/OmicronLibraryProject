using Microsoft.EntityFrameworkCore;
using OmicronLibraryProject.Context;
using OmicronLibraryProject.Models;

namespace OmicronLibraryProject.Services.BookServices
{
    public class BookService : IBookService
    { private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Set<Book>().Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _context.Set<Book>().Remove(book);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAll()
        {
            return _context.Set<Book>().ToList();
        }

		public async Task<List<Book>> GetAllAsync()
		{
			var books = await _context.Books.ToListAsync(); 
			return books;
		}

		public Book GetById(int id)
        {
            return _context.Set<Book>().Find(id);
        }

		public async Task<Book> GetByIdAsync(int id)
		{
			var book = await _context.Books.FindAsync(id); 
			return book;
		}

		public Book GetByISBN(string ISBN)
        {
            return _context.Books.SingleOrDefault(book => book.ISBN == ISBN);
        }

        public void Update(Book book)
        {
            _context.Set<Book>().Update(book);
            _context.SaveChanges();
        }
    }
}
