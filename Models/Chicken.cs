using System.ComponentModel.DataAnnotations;
using ChickenSystem.Dto;
namespace ChickenSystem.Models {
    public class Chicken
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime Date { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public required string Color { get; set; }
        public required int Age { get; set; }
        public required string Breed { get; set; }
        [MaxLength(20)]
        public required string Sex { get; set; }
        public bool Sing { get; set; }

    }
}
