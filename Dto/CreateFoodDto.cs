namespace ChickenSystem.Dto
{
    public class CreateFoodDto
    {
        
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
    }
}