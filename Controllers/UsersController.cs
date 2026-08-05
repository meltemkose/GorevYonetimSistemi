using GorevYonetimSistemi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GorevYonetimSistemi.Models;

namespace GorevYonetimSistemi.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();

            return View(users);
        }
        public async Task<IActionResult> Edit(int id)
{
    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
        return NotFound();
    }

    return View(user);
}

[HttpPost]
public async Task<IActionResult> Edit(User user)
{
    var existingUser = await _context.Users.FindAsync(user.Id);

    if (existingUser == null)
    {
        return NotFound();
    }

    existingUser.Name = user.Name;
    existingUser.Surname = user.Surname;
    existingUser.Email = user.Email;
    existingUser.Role = user.Role;

    if (!string.IsNullOrWhiteSpace(user.Password))
    {
        existingUser.Password = user.Password;
    }

    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
        public IActionResult Create()
{
        return View();
}
[HttpPost]
public async Task<IActionResult> Create(User user)
{
    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
}
}
    
