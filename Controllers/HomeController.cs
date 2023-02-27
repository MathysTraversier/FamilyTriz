using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FamilyTriz.Models;
using MvcFamilyTriz.Data;

namespace FamilyTriz.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MvcFamilyTrizContext _context;

    public HomeController(ILogger<HomeController> logger, MvcFamilyTrizContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Rouge"] = _context.Familles.Where(f => f.couleur == "Rouge").FirstOrDefault();
        ViewData["Vert"] = _context.Familles.Where(f => f.couleur == "Vert").FirstOrDefault();
        ViewData["Bleu"] = _context.Familles.Where(f => f.couleur == "Bleu").FirstOrDefault();
        ViewData["Jaune"] = _context.Familles.Where(f => f.couleur == "Jaune").FirstOrDefault();
        ViewData["Orange"] = _context.Familles.Where(f => f.couleur == "Orange").FirstOrDefault();
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
