namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime DateOfBirth { get; set; }

          // Khóa ngoại đến Class
        public int ClassId { get; set; }
        public Class? Class { get; set; }

        
    }
}
