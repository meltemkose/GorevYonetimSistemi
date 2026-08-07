using GorevYonetimSistemi.Data;
using GorevYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GorevYonetimSistemi.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
{
    var tasks = await _context.Tasks.ToListAsync();

    return View(tasks);
}
public async Task<IActionResult> Create()
{
    ViewBag.Projects = new SelectList(
        await _context.Projects.ToListAsync(),
        "Id",
        "Name"
    );

    ViewBag.Users = new SelectList(
        await _context.Users.ToListAsync(),
        "Id",
        "Name"
    );

    return View();

} 
[HttpPost]
public async Task<IActionResult> Create(TaskItem task)
{
    _context.Tasks.Add(task);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
    }
}