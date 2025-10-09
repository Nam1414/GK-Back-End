using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentClassApi.Models
{
public class Student
{
[Key]
public int Id { get; set; }


[Required]
public string Name { get; set; }


public DateTime DateOfBirth { get; set; }


// Foreign key to Class
[ForeignKey("Class")]
public int ClassId { get; set; }


// Navigation property
public Class Class { get; set; }
}
}