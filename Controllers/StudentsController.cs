using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StudentAPI.Data;
using StudentAPI.Models;


namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //  GET - có phân trang (3.1)
        [HttpGet]
        public IActionResult GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var totalItems = _context.Students.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var students = _context.Students
                .Include(s => s.Class)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var data = _mapper.Map<List<StudentDto>>(students);

            return Ok(new { pageNumber, pageSize, totalPages, totalItems, data });
        }

        //  POST - tạo mới
        [HttpPost]
        public IActionResult Create(StudentCreateDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            _context.Students.Add(student);
            _context.SaveChanges();

            var result = _mapper.Map<StudentDto>(student);
            return CreatedAtAction(nameof(GetAll), new { id = student.Id }, result);
        }

        //  PUT - cập nhật sinh viên (không đổi lớp)
        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentUpdateDto dto)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            _mapper.Map(dto, student);
            _context.SaveChanges();

            var result = _mapper.Map<StudentDto>(student);
            return Ok(result);
        }

        //  DELETE - xoá sinh viên
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}


