namespace Dating.API.Entities; // Logical representation of where the file is located in the project

public class AppUser
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string UserName { get; set; }
    public required string Email { get; set; }
}
