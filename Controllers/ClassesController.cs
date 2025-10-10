using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_ClassesApi.Data;        // Namespace chứa lớp AppDbContext (Context Database)
using Database_ClassesApi.Models;      // Namespace chứa thực thể (model) Class
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database_ClassesApi.Controllers
{
    // Định nghĩa route API, [controller] sẽ được thay thế bởi tên controller (Classes)
    [Route("api/[controller]")]
    [ApiController]  // Đánh dấu đây là API controller
    public class ClassesController : ControllerBase
    {
        private readonly AppDbContext _context;  // Biến lưu trữ context để truy cập database

        // Constructor nhận vào AppDbContext qua Dependency Injection
        public ClassesController(AppDbContext context)
        {
            _context = context;
        }

        // Phương thức GET: Trả về danh sách tất cả các lớp (Class)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            // Truy vấn toàn bộ bảng Classes bất đồng bộ và trả về danh sách
            return await _context.Classes.ToListAsync();
        }

        // Phương thức POST: Thêm một lớp mới vào cơ sở dữ liệu
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Class newClass)
        {
            _context.Classes.Add(newClass);          // Thêm thực thể mới vào context
            await _context.SaveChangesAsync();       // Lưu thay đổi bất đồng bộ vào database

            // Trả về phản hồi 201 Created kèm theo vị trí lấy lớp mới được thêm
            return CreatedAtAction(nameof(GetClasses), new { id = newClass.Id }, newClass);
        }
        // [HttpDelete("reset")]
        // public async Task<IActionResult> ResetClasses()
        // {
        //     // Xóa toàn bộ dữ liệu trong bảng Classes
        //     _context.Classes.RemoveRange(_context.Classes);
        //     await _context.SaveChangesAsync();
        //     // Trả về phản hồi 204 No Content
        //     return NoContent();
        // }
    }
}
