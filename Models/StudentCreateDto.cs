namespace StudentAPI.Models
{
    public class StudentCreateDto
    {
        public string Name { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
    }
}
