namespace WebSystem.Test.Dtos;

public class OrderDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } 
    public string? Description { get; set; }
    
    public override string ToString() =>
        $"Id: {Id}, Name: {Name}, Description: {Description}";
}