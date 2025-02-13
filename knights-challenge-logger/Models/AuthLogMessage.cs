namespace knights_challenge_logger.Models
{
    public class AuthLogMessage
    {
        public required string Username { get; set; }
        public required string Status { get; set; }

        //public required Dictionary<string, string> Headers { get; set; }
        public required string UserAgent { get; set; }
        public required string IpAddress { get; set; }
    }
}
