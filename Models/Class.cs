using System.Collections.Generic;

namespace Database_ClassesApi.Models
{
    // Lớp đại diện cho thực thể Class trong hệ thống
    public class Class
    {
        // Thuộc tính Id là khóa chính, kiểu int
        public int Id { get; set; }

        // Thuộc tính Name là tên lớp, kiểu string, bắt buộc phải có (required)
        public required string Name { get; set; }
    }
}
