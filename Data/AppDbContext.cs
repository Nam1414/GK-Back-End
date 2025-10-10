using Microsoft.EntityFrameworkCore;
using Database_ClassesApi.Models;  // Namespace chứa thực thể (model) Class

namespace Database_ClassesApi.Data
{
    // Định nghĩa lớp AppDbContext kế thừa từ DbContext của Entity Framework Core
    public class AppDbContext : DbContext
    {
        // Constructor nhận vào tùy chọn cấu hình DbContext (ví dụ kết nối database)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Khai báo DbSet đại diện cho bảng Classes trong database
        // DbSet<Class> sẽ ánh xạ tới bảng chứa các đối tượng Class
        public DbSet<Class> Classes { get; set; }
    }
}
