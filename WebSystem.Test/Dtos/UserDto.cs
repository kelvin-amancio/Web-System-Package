namespace WebSystem.Test.Dtos;

public class UserDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Role { get; set; }
}