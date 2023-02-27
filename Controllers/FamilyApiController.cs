using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFamilyTriz.Data;
using MvcFamilyTriz.Models;

namespace MvcFamilyTriz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FamilyApiController : ControllerBase
{
    private readonly MvcFamilyTrizContext _context;

    public FamilyApiController(MvcFamilyTrizContext context)
    {
        _context = context;
    }

    // GET: api/FamilyApi
    public async Task<ActionResult<IEnumerable<Famille>>> GetFamilies()
    {
        // Get students
        var families = _context.Familles;

        return await families.ToListAsync();
    }

    // GET: api/FamilyApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Famille>> GetFamily(int Id)
    {
        // Find student and related enrollments
        // SingleAsync() throws an exception if no student is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var family = await _context.Familles
            .Where(f => f.id == Id)
            .SingleOrDefaultAsync();

        if (family == null)
            return NotFound();

        return family;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFamily(int Id, Famille family)
    {
        if (Id != family.id)
            return BadRequest();

        _context.Entry(family).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudExists(Id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // Returns true if a movie with specified id already exists
    private bool StudExists(int Id)
    {
        return _context.Eleves.Any(m => m.id == Id);
    }
}