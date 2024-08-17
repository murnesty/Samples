using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.Schools.Models;

public class Person
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Age { get; set; }
}
