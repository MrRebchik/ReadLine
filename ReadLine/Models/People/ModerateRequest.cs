namespace ReadLine.Models.People
{
    public class ModerateRequest
    {
        public long ModerateRequestId { get; set; }
        public string BookTitle { get; set; }
        public string? Description { get; set; }
        public string? ApproveResourceLink { get; set; }
    }
}
