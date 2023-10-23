using OmicronLibraryProject.Models;

namespace OmicronLibraryProject.Services.BookServices
{
    public interface IBookService
    {
        Book GetById(int id);
        List<Book> GetAll();
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
        Book GetByISBN(string ISBN);
		Task<List<Book>> GetAllAsync();
		Task<Book> GetByIdAsync(int id);

	}
}
