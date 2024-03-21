namespace WebSystem.Core.models
{
    public class WsEmail
    {
        public string ToName { get; set; } = null!;
        public string ToEmail { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string FromEmail { get; set; } = null!;
    }
}