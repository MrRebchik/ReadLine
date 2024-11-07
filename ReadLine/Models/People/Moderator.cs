namespace ReadLine.Models.People
{
    public class Moderator : User
    {
        public IEnumerable<ModerateRequest> ModerateRequests { get; set; }
    }
}
