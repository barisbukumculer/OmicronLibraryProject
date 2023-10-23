using OmicronLibraryProject.Models;

namespace OmicronLibraryProject.Services.LoanServices
{
    public interface ILoanService
    {
        Loan GetById(int id);
        List<Loan> GetAll();
        void Add(Loan loan);
        void Update(Loan loan);
        void Delete(int id);
        void BorrowBook(int userId, int bookId);
        List<Loan> GetLoansWithUsersAndBooks();
    }
}
