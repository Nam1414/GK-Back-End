using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentClassApi.Data;
using StudentClassApi.Models;


namespace StudentClassApi.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
private readonly AppDbContext _db;
public StudentsController(AppDbContext db) => _db = db;


// GET: api/students
[HttpGet]
public async Task<ActionResult<IEnumerable<Student>>> GetAll()
=> Ok(await _db.Students.Include(s => s.Class).ToListAsync());


// POST: api/students
[HttpPost]
public async Task<ActionResult<Student>> Create(Student model)
{
// Ensure class exists before adding student
var cls = await _db.Classes.FindAsync(model.ClassId);
if (cls == null) return BadRequest($"Class with id {model.ClassId} not found.");


_db.Students.Add(model);
await _db.SaveChangesAsync();
return CreatedAtAction(nameof(GetAll), new { id = model.Id }, model);
}
}
}