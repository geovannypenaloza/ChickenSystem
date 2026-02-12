using System.ComponentModel.DataAnnotations;

namespace ChickenSystem.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
