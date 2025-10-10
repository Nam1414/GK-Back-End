using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Entity;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // POST /api/students  → Thêm sinh viên vào lớp
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            // Kiểm tra lớp tồn tại
            var classExists = await _context.Classes.AnyAsync(c => c.Id == student.ClassId);
            if (!classExists)
            {
                return NotFound(new { message = $"Class with ID {student.ClassId} not found." });
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllStudents), new { id = student.Id }, student);
        }

        // GET /api/students  → Lấy tất cả sinh viên
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _context.Students
                .Include(s => s.Class)
                .ToListAsync();
            return Ok(students);
        }

        // GET /api/classes/{classId}/students  → Lấy sinh viên theo lớp
        [HttpGet("/api/classes/{classId}/students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByClass(int classId)
        {
            var classExists = await _context.Classes.AnyAsync(c => c.Id == classId);
            if (!classExists)
            {
                return NotFound(new { message = $"Class with ID {classId} not found." });
            }

            var students = await _context.Students
                .Where(s => s.ClassId == classId)
                .Include(s => s.Class)
                .ToListAsync();

            return Ok(students);
        }
    }
}
