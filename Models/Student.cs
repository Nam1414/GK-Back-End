namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string ClassName { get; set; } = "";// Không thay đổi lớp học
          // Khóa ngoại đến Class
        public int ClassId { get; set; }
        public Class? Class { get; set; }

        
    }
}
