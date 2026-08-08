using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GorevYonetimSistemi.Models;
using GorevYonetimSistemi.Data;
using Microsoft.EntityFrameworkCore;

namespace GorevYonetimSistemi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
private readonly ApplicationDbContext _context;
   public HomeController(
    ILogger<HomeController> logger,
    ApplicationDbContext context)
{
    _logger = logger;
    _context = context;
}

    public async Task<IActionResult> Index()
{
    ViewBag.TotalTasks = await _context.Tasks.CountAsync();
    ViewBag.PendingTasks = await _context.Tasks.CountAsync(t => t.Status == "Bekliyor");
    ViewBag.InProgressTasks = await _context.Tasks.CountAsync(t => t.Status == "Devam Ediyor");
    ViewBag.CompletedTasks = await _context.Tasks.CountAsync(t => t.Status == "Tamamlandı");

    return View();
}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
