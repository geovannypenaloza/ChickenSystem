namespace ChickenSystem.Dto.Chicken
{
    public class CreateChickenDto
    {       
        
        public required string Name { get; set; }
        public required DateTime Date { get; set; }
        public required decimal Height { get; set; }
        public required decimal Weight { get; set; }
        public required string Color { get; set; }
        public required int Age { get; set; }
        public required string Breed { get; set; }
        public required string Sex { get; set; }
        public required bool Sing { get; set; }
    }
}
