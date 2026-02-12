using System.ComponentModel.DataAnnotations;

namespace ChickenSystem.Models;

public class Shed
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }
    public required bool Active { get; set; }
    
}