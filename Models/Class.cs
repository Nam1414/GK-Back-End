using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StudentClassApi.Models
{
public class Class
{
    [Key]
public int Id { get; set; }

[Required]
public string Name { get; set; }


// 1 Class -> many Students
public ICollection<Student> Students { get; set; } = new List<Student>();
}
}