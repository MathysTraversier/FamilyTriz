using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFamilyTriz.Data;
using MvcFamilyTriz.Models;

namespace MvcFamilyTriz.Controllers;

public class EventController : Controller
{
    private readonly MvcFamilyTrizContext _context;

    public EventController(MvcFamilyTrizContext context)
    {
        _context = context;
    }

    // GET: Student
    public async Task<IActionResult> Index()
    {
        var events = await _context.Evenements
            .OrderBy(e => e.date)
            .ThenBy(e => e.nom)
            .ToListAsync();

        return View(events);
    }

    // GET: Student/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var evenement = await _context.Evenements
            .FirstOrDefaultAsync(m => m.id == id);
        if (evenement == null)
        {
            return NotFound();
        }

        return View(evenement);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,nom,description,nbPointAGagner,nbPointRouge,nbPointVert,nbPointBleu,nbPointJaune,nbPointOrange,date")] Evenement evenement)
    {
        // Apply model validation rules
        //if (ModelState.IsValid)
        //{
            _context.Add(evenement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        //}
        // At this point, something failed: redisplay form
        //return View(stud);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var evenement = await _context.Evenements
            .FirstOrDefaultAsync(m => m.id == id);
        if (evenement == null)
        {
            return NotFound();
        }

        return View(evenement);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var evenement = await _context.Evenements.FindAsync(id);
        _context.Evenements.Remove(evenement!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var evenement = await _context.Evenements.FindAsync(id);
        if (evenement == null)
        {
            return NotFound();
        }
        return View(evenement);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int Id, [Bind("id,nom,description,nbPointAGagner,date")] Evenement evenement)
    {
        if (Id != evenement.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(evenement);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(evenement.id))
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
        return View(evenement);
    }

    private bool EventExists(int id)
    {
        return _context.Evenements.Any(e => e.id == id);
    }

    public async Task<IActionResult> UpdatePoints(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var evenement = await _context.Evenements.FindAsync(id);
        if (evenement == null)
        {
            return NotFound();
        }
        return View(evenement);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdatePoints(int Id, [Bind("id,nbPointRouge,nbPointVert,nbPointBleu,nbPointJaune,nbPointOrange")] Evenement evenement)
    {
        if (Id != evenement.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var familleRouge = await _context.Familles.FirstAsync(m => m.couleur == "Rouge");
                familleRouge.points = familleRouge.points + evenement.nbPointRouge;

                var familleVerte = await _context.Familles.FirstAsync(m => m.couleur == "Vert");
                familleVerte.points = familleVerte.points + evenement.nbPointVert;

                var familleBleue = await _context.Familles.FirstAsync(m => m.couleur == "Bleu");
                familleBleue.points = familleBleue.points + evenement.nbPointBleu;

                var familleJaune = await _context.Familles.FirstAsync(m => m.couleur == "Jaune");
                familleJaune.points = familleJaune.points + evenement.nbPointJaune;

                var familleOrange = await _context.Familles.FirstAsync(m => m.couleur == "Orange");
                familleOrange.points = familleOrange.points + evenement.nbPointOrange;

                _context.Evenements.Update(evenement);
                _context.Familles.Update(familleRouge);
                _context.Familles.Update(familleVerte);
                _context.Familles.Update(familleBleue);
                _context.Familles.Update(familleJaune);
                _context.Familles.Update(familleOrange);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(evenement.id))
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
        return View(evenement);
    }
}
