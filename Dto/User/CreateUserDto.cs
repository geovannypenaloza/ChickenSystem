namespace ChickenSystem.Dto.User;

public class CreateUserDto
{
    
    public required string Name { get; set; }
    public required int Age { get; set; }
    public required string Gender { get; set; }
}