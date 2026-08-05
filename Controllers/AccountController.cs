using GorevYonetimSistemi.Data;
using Microsoft.AspNetCore.Mvc;

namespace GorevYonetimSistemi.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ViewBag.ErrorMessage = "E-posta veya şifre hatalı.";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}