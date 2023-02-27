using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFamilyTriz.Data;
using MvcFamilyTriz.Models;
using System.Diagnostics;

namespace MvcFamilyTriz.Controllers;

public class FamilyController : Controller // not ControllerBase!
{

    private readonly MvcFamilyTrizContext _context;

    public FamilyController(MvcFamilyTrizContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Lookup student and associated enrollments
        var family = await _context.Familles
            .Include(f => f.Eleves)
            .FirstOrDefaultAsync(m => m.id == id);
        if (family == null)
        {
            return NotFound();
        }

        return View(family);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var family = await _context.Familles.FindAsync(id);
        if (family == null)
        {
            return NotFound();
        }
        return View(family);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,couleur,points")] Famille family)
    {
        if (id != family.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(family);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyExists(family.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(family);
    }

    private bool FamilyExists(int id)
    {
        return _context.Familles.Any(e => e.id == id);
    }
}