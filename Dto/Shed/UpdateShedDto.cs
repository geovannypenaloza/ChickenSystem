namespace ChickenSystem.Dto.Shed;

public class UpdateShedDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }
    public required bool Active { get; set; }
}