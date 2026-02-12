using System.ComponentModel.DataAnnotations;

namespace ChickenSystem.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
    public required string Gender { get; set; }
}