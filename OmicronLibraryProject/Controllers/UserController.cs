using Microsoft.AspNetCore.Mvc;
using OmicronLibraryProject.Models;
using OmicronLibraryProject.Services.UserServices;

namespace OmicronLibraryProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users= _userService.GetAll();
            return View(users);
        }
        public IActionResult UserDetails(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
