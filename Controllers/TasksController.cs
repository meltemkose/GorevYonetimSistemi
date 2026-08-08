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
public async Task<IActionResult> Edit(int id)
{
    var task = await _context.Tasks.FindAsync(id);

    if (task == null)
    {
        return NotFound();
    }

    ViewBag.Projects = new SelectList(
        await _context.Projects.ToListAsync(),
        "Id",
        "Name",
        task.ProjectId
    );

    ViewBag.Users = new SelectList(
        await _context.Users.ToListAsync(),
        "Id",
        "Name",
        task.UserId
    );

    return View(task);
}
[HttpPost]
public async Task<IActionResult> Edit(TaskItem task)
{
    var existingTask = await _context.Tasks.FindAsync(task.Id);

    if (existingTask == null)
    {
        return NotFound();
    }

    existingTask.Title = task.Title;
    existingTask.Description = task.Description;
    existingTask.Status = task.Status;
    existingTask.Deadline = task.Deadline;
    existingTask.ProjectId = task.ProjectId;
    existingTask.UserId = task.UserId;

    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
public async Task<IActionResult> Delete(int id)
{
    var task = await _context.Tasks.FindAsync(id);

    if (task == null)
    {
        return NotFound();
    }

    return View(task);
}

[HttpPost, ActionName("Delete")]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var task = await _context.Tasks.FindAsync(id);

    if (task != null)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }

    return RedirectToAction(nameof(Index));
}
    }
}