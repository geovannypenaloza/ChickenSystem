namespace ChickenSystem.Dto
{
    public class ChickenDto
    {
        public required int Id { get; set; }
        
        public required string Name { get; set; }
        public required DateTime Date { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public required string Color { get; set; }
        public required int Age { get; set; }
        public required string Breed { get; set; }
        public required string Sex { get; set; }
        public bool Sing { get; set; }
    }
}
