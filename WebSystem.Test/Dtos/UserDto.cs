namespace WebSystem.Test.Dtos;

public class UserDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Company { get; set; }

    public override string ToString() =>
         $"Id: {Id}, Name: {Name}, Company: {Company}";
}