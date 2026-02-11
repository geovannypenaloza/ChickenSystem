namespace ClientSystem.Dto
{
    public class CreateClientDto
    {
        //sin ID en create
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
