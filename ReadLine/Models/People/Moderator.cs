namespace ReadLine.Models.People
{
    public class Moderator : UserProfile
    {
        public List<ModerateRequest> ModerateRequests { get; set; } = [];
    }
}
