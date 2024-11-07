using Microsoft.AspNetCore.Identity;

namespace ReadLine.Models.People
{
    public class UserProfile
    {
        public long UserProfileId { get; set; }
        public long IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string ProfileQuote { get; set; }
        public List<Book> ReadBooks { get; set; } = [];
        public List<Book> FavoriteBooks { get; set; } = [];
        public List<Book> WishBooks { get; set; } = [];
        public List<UserProfile> Friends { get; set; } = [];
    }
}
