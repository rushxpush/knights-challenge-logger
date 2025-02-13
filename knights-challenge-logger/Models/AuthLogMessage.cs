namespace knights_challenge_logger.Models
{
    public class AuthLogMessage : LogMessage
    {
        public required string Username { get; set; }
        public required string Status { get; set; }
        public required string IpAddress { get; set; }
        public required string UserAgent { get; set; }
    }
}
