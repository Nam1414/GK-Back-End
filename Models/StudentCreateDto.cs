namespace StudentAPI.Models
{
    public class StudentCreateDto
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public int ClassId { get; set; }
    }
}
