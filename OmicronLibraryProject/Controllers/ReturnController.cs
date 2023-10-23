using Microsoft.AspNetCore.Mvc;
using OmicronLibraryProject.Context;
using OmicronLibraryProject.Services.LoanServices;

public class ReturnController : Controller
{
	private readonly ILoanService _loanService;

	public ReturnController(ILoanService loanService)
	{
		_loanService = loanService;
	}

	public IActionResult ProcessReturn()
	{
		var allLoans = _loanService.GetLoansWithUsersAndBooks();
		return View(allLoans);
	}

	[HttpPost]
	public IActionResult ProcessReturn(int loanId)
	{
		if (loanId <= 0)
		{
			ModelState.AddModelError(string.Empty, "Geçerli bir ödünç alma kimliği belirtmelisiniz.");
			return View();
		}

		var loan = _loanService.GetById(loanId);

		if (loan == null)
		{
			ModelState.AddModelError(string.Empty, "Belirtilen ödünç alma kaydı bulunamadı.");
			return View();
		}

		_loanService.Delete(loanId);

		return RedirectToAction("Index","Home");
	}

	public IActionResult ReturnSuccess()
	{
		return View();
	}
}
