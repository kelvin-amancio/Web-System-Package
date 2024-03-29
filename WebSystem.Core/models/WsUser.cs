
namespace WebSystem.Core.models
{
    public class WsUser
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string[]? Roles { get; set; }
    }
}