namespace StudentAPI.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
         public int ClassId { get; set; }
        public string ClassName { get; set; } = "";
    }
}
