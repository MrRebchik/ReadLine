namespace ReadLine.Models.People
{
    public class ModeratorModerateRequest
    {
        public long ModeratorId { get; set; }
        public Moderator Moderator { get; set; }
        public long ModerateRequestId { get; set; }
        public ModerateRequest ModerateRequest { get; set; }
    }
}
