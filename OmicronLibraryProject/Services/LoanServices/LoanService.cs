using Microsoft.EntityFrameworkCore;
using OmicronLibraryProject.Context;
using OmicronLibraryProject.Models;

namespace OmicronLibraryProject.Services.LoanServices
{
    public class LoanService : ILoanService
    {
        private readonly LibraryDbContext _context;

        public LoanService(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(Loan loan)
        {
            _context.Set<Loan>().Add(loan);
            _context.SaveChanges();
        }

        public void BorrowBook(int userId, int bookId)
        {
            var loan = new Loan
            {
                UserId = userId,
                BookId = bookId,
                BorrowedDate = DateTime.Now,
                ReturnedDate = null
            };

            _context.Set<Loan>().Add(loan);
            _context.SaveChanges();

            var book = _context.Set<Book>().Find(bookId);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var loan = GetById(id);
            if (loan != null)
            {
                _context.Set<Loan>().Remove(loan);
                _context.SaveChanges();
            }
        }

        public List<Loan> GetAll()
        {
            return _context.Set<Loan>().ToList();
        }

        public Loan GetById(int id)
        {
           return _context.Set<Loan>().Find(id);
        }

        public List<Loan> GetLoansWithUsersAndBooks()
        {
            var loans = _context.Loans
             .Include(loan => loan.Book)
             .Include(loan => loan.User)
             .ToList();

            return loans;
        }

        public void Update(Loan loan)
        {
            _context.Set<Loan>().Update(loan);
            _context.SaveChanges();
        }
    }
}
