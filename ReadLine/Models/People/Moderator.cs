namespace ReadLine.Models.People
{
    public class Moderator
    {
        public long ModeratorId { get; set; }
        public string ModeratorName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<ModereteRequest> ModereteRequests { get; set; }
    }
}
