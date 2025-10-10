using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StudentAPI.Models;
using StudentAPI.Data;

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

        // API PUT - Cập nhật sinh viên theo ID
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            
            if (student == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin sinh viên, không thay đổi lớp học
            student.Name = studentDto.Name;
            student.Age = studentDto.Age;
            // Đảm bảo không thay đổi lớp học

            _context.SaveChanges();

            return Ok(student);
        }

        // API GET - Lấy danh sách sinh viên với phân trang
        [HttpGet]
        public IActionResult GetStudents(int page = 1, int pageSize = 10)
        {
            var students = _context.Students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var studentDtos = _mapper.Map<List<StudentDto>>(students);
            
            return Ok(studentDtos);
        }
    }
}
