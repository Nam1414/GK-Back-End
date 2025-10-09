using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentClassApi.Data;
using StudentClassApi.Models;


namespace StudentClassApi.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class ClassesController : ControllerBase
{
private readonly AppDbContext _db;
public ClassesController(AppDbContext db) => _db = db;


// GET: api/classes
[HttpGet]
public async Task<ActionResult<IEnumerable<Class>>> GetAll()
=> Ok(await _db.Classes.Include(c => c.Students).ToListAsync());


// POST: api/classes
[HttpPost]
public async Task<ActionResult<Class>> Create(Class model)
{
_db.Classes.Add(model);
await _db.SaveChangesAsync();
return CreatedAtAction(nameof(GetAll), new { id = model.Id }, model);
}
}
}