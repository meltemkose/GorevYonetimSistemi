using GorevYonetimSistemi.Data;
using GorevYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GorevYonetimSistemi.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
   {
            _context = context;
        } 
        public async Task<IActionResult> Index()
  {
    var projects = await _context.Projects.ToListAsync();

    return View(projects);
 }
 public IActionResult Create()
{
    return View();
}

[HttpPost]
public async Task<IActionResult> Create(Project project)
{
    _context.Projects.Add(project);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
public async Task<IActionResult> Edit(int id)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
    {
        return NotFound();
    }

    return View(project);
}
[HttpPost]
public async Task<IActionResult> Edit(Project project)
{
    var existingProject = await _context.Projects.FindAsync(project.Id);

    if (existingProject == null)
    {
        return NotFound();
    }

    existingProject.Name = project.Name;
    existingProject.Description = project.Description;

    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
    
    public async Task<IActionResult> Delete(int id)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
    {
        return NotFound();
    }
    
    return View(project);
}
[HttpPost]
public async Task<IActionResult> Delete(Project project)
{
    var existingProject = await _context.Projects.FindAsync(project.Id);

    if (existingProject == null)
    {
        return NotFound();
    }

    _context.Projects.Remove(existingProject);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
}
}