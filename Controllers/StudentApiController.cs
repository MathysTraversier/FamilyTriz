using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFamilyTriz.Data;
using MvcFamilyTriz.Models;

namespace MvcFamilyTriz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentApiController : ControllerBase
{
    private readonly MvcFamilyTrizContext _context;

    public StudentApiController(MvcFamilyTrizContext context)
    {
        _context = context;
    }

    // GET: api/StudentApi
    public async Task<ActionResult<IEnumerable<Eleve>>> GetStudents()
    {
        // Get students
        var students = _context.Eleves
            .OrderBy(s => s.nom)
            .ThenBy(s => s.prenom);

        return await students.ToListAsync();
    }

    // GET: api/StudentApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Eleve>> GetStudent(int Id)
    {
        // Find student and related enrollments
        // SingleAsync() throws an exception if no student is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var student = await _context.Eleves
            .Where(s => s.id == Id)
            .SingleOrDefaultAsync();

        if (student == null)
            return NotFound();

        return student;
    }

    // POST: api/StudentApi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Eleve>> PostStudent(Eleve student)
    {
        student.famille = _context.Familles.Where(f => f.id == student.familleId).First();
        _context.Eleves.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.id }, student);
    }

    // DELETE: api/StudentApi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int Id)
    {
        var student = await _context.Eleves.FindAsync(Id);
        if (student == null)
            return NotFound();

        _context.Eleves.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int Id, Eleve stud)
    {
        if (Id != stud.id)
            return BadRequest();

        _context.Entry(stud).State = EntityState.Modified;
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