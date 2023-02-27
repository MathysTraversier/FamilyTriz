using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFamilyTriz.Data;
using MvcFamilyTriz.Models;

namespace MvcFamilyTriz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventApiController : ControllerBase
{
    private readonly MvcFamilyTrizContext _context;

    public EventApiController(MvcFamilyTrizContext context)
    {
        _context = context;
    }

    // GET: api/EventApi
    public async Task<ActionResult<IEnumerable<Evenement>>> GetEvents()
    {
        // Get students
        var events = _context.Evenements
            .OrderBy(e => e.date)
            .ThenBy(e => e.nom);

        return await events.ToListAsync();
    }

    // GET: api/EventApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Evenement>> GetEvent(int Id)
    {
        // Find student and related enrollments
        // SingleAsync() throws an exception if no student is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var evenement = await _context.Evenements
            .Where(e => e.id == Id)
            .SingleOrDefaultAsync();

        if (evenement == null)
            return NotFound();

        return evenement;
    }

    // POST: api/EventApi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Evenement>> PostEvent(Evenement evenement)
    {
        _context.Evenements.Add(evenement);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEvent), new { id = evenement.id }, evenement);
    }

    // DELETE: api/EventApi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int Id)
    {
        var evenement = await _context.Evenements.FindAsync(Id);
        if (evenement == null)
            return NotFound();

        _context.Evenements.Remove(evenement);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvent(int Id, Evenement evenement)
    {
        if (Id != evenement.id)
            return BadRequest();

        _context.Entry(evenement).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventExists(Id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // Returns true if a movie with specified id already exists
    private bool EventExists(int Id)
    {
        return _context.Evenements.Any(m => m.id == Id);
    }
}