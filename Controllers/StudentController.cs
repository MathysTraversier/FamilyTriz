using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFamilyTriz.Data;
using MvcFamilyTriz.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcFamilyTriz.Controllers;

public class StudentController : Controller
{
    private readonly MvcFamilyTrizContext _context;

    public StudentController(MvcFamilyTrizContext context)
    {
        _context = context;
    }

    // GET: Student
    public async Task<IActionResult> Index()
    {
        var students = await _context.Eleves
            .OrderBy(s => s.nom)
            .ThenBy(s => s.prenom)
            .ToListAsync();

        return View(students);
    }

    // GET: Student/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Eleves
            .Include(s => s.famille)
            .Include(s => s.parrain)
            .FirstOrDefaultAsync(m => m.id == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    public IActionResult Create()
    {
        var availableFamilyQuery = from f in _context.Familles
                                    select f;
        var availableFamily = availableFamilyQuery.ToList();

        var availableStudQuery = from s in _context.Eleves
                                    orderby s.nom
                                    select s;
        var availableStud = availableStudQuery.ToList();

        ViewData["FamilyId"] = new SelectList(availableFamily, "id", "couleur");
        ViewData["StudId"] = new SelectList(availableStud, "id", "nom");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,nom,prenom,promotion,familleId,parrainId")] Eleve stud)
    {
        var family = _context.Familles.Find(stud.familleId);
        var _parrain = _context.Eleves.Find(stud.parrainId);

        stud.famille = family!;
        stud.parrain = _parrain;

        _context.Add(stud);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stud = await _context.Eleves
            .Include(s => s.famille)
            .Include(s => s.parrain)
            .FirstOrDefaultAsync(m => m.id == id);
        if (stud == null)
        {
            return NotFound();
        }

        return View(stud);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var stud = await _context.Eleves.FindAsync(id);
        _context.Eleves.Remove(stud!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stud = await _context.Eleves.FindAsync(id);
        if (stud == null)
        {
            return NotFound();
        }

        var availableFamilyQuery = from f in _context.Familles
                                    select f;
        var availableFamily = availableFamilyQuery.ToList();

        var availableStudQuery = from s in _context.Eleves
                                    orderby s.nom
                                    select s;
        var availableStud = availableStudQuery.ToList();

        ViewData["FamilyId"] = new SelectList(availableFamily, "id", "couleur");
        ViewData["StudId"] = new SelectList(availableStud, "id", "nom");

        return View(stud);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int Id, [Bind("id,nom,prenom,promotion,familleId,parrainId")] Eleve stud)
    {
        if (Id != stud.id)
        {
            return NotFound();
        }

        try
        {
            var family = _context.Familles.Find(stud.familleId);
            var _parrain = _context.Eleves.Find(stud.parrainId);

            stud.famille = family!;
            stud.parrain = _parrain;

            _context.Update(stud);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudExists(stud.id))
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

    private bool StudExists(int id)
    {
        return _context.Eleves.Any(e => e.id == id);
    }
}
