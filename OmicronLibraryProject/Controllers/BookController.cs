using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmicronLibraryProject.Models;
using OmicronLibraryProject.Services.BookServices;
using OmicronLibraryProject.Services.LoanServices;
using OmicronLibraryProject.Services.UserServices;
using System.Net;

namespace OmicronLibraryProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly ILoanService _loanService;
        public BookController(IBookService bookService, IUserService userService, ILoanService loanService)
        {
            _bookService = bookService;
            _userService = userService;
            _loanService = loanService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAll();
            return View(books);

        }
        public IActionResult BookDetails(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookService.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult BorrowBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BorrowBook(BorrowBookModel borrowBookModel)
        {
            string userTC = borrowBookModel.UserTC;
            string ISBN = borrowBookModel.ISBN;
            var book = _bookService.GetByISBN(ISBN);
            if (book != null && userTC != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                _bookService.Update(book);
                var user = _userService.GetByTC(userTC);

                var loan = new Loan
                {
                    BookId = book.Id,
                    UserId = user.Id,
                    BorrowedDate = DateTime.Now,
                    ReturnedDate = null
                };

                _loanService.Add(loan);
                return RedirectToAction("processreturn", "return");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ReturnBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReturnBook(string ISBN,int id)
        {
            var book = _bookService.GetByISBN(ISBN);
            var loan = _loanService.GetById(id);
            
            if (book != null)
            {
                book.IsAvailable = true;
                loan.ReturnedDate = DateTime.Now;
                book.ReturnedDate = DateTime.Now;
               
                _bookService.Update(book);
                _loanService.Update(loan);

                return RedirectToAction("processreturn", "return");
            }
            else
            {
                ModelState.AddModelError("ISBN", "Kitap bulunamadı.");
                return View();
            }

        }
    }
 }

