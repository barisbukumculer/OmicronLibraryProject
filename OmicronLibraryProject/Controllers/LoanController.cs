using Microsoft.AspNetCore.Mvc;
using OmicronLibraryProject.Models;
using OmicronLibraryProject.Services.LoanServices;

namespace OmicronLibraryProject.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        public IActionResult Index()
        {
            var loans = _loanService.GetLoansWithUsersAndBooks();
            return View(loans);
        }
        public IActionResult LoanDetails(int id)
        {
            var loan = _loanService.GetById(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }
        [HttpGet]
        public IActionResult CreateLoan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLoan(Loan loan)
        {
            if (ModelState.IsValid)
            {
                _loanService.Add(loan);
                return RedirectToAction("Index");
            }
            return View(loan);
        }
        [HttpGet]
        public IActionResult UpdateLoan(int id)
        {
            var loan = _loanService.GetById(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateLoan(int id, Loan loan)
        {
            if (id != loan.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _loanService.Update(loan);
                return RedirectToAction("Index");
            }
            return View(loan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLoan(int id)
        {
            _loanService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
