using Microsoft.AspNetCore.Mvc;
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

        //  PUT - Cập nhật sinh viên theo ID (dùng AutoMapper)
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            // Dùng AutoMapper để cập nhật các thuộc tính
            _mapper.Map(studentDto, student);

            _context.SaveChanges();

            var updatedDto = _mapper.Map<StudentDto>(student);
            return Ok(updatedDto);
        }

        //  GET - Lấy danh sách sinh viên có phân trang
        [HttpGet]
        public IActionResult GetStudents(int pageNumber = 1, int pageSize = 10)
        {
            var totalItems = _context.Students.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var students = _context.Students
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var studentDtos = _mapper.Map<List<StudentDto>>(students);

            var response = new
            {
                currentPage = pageNumber,
                totalPages = totalPages,
                totalItems = totalItems,
                pageSize = pageSize,
                data = studentDtos
            };

            return Ok(response);
        }
    }
}
