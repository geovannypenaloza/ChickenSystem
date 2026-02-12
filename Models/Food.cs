using System.ComponentModel.DataAnnotations;

namespace ChickenSystem.Models;

public class Food
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
}