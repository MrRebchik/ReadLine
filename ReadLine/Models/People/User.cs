using Microsoft.AspNetCore.Identity;

namespace ReadLine.Models.People
{
    public class User
    {
        public long IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string ProfileQuote { get; set; }
        public IEnumerable<Book> ReadBooks { get; set; }
        public IEnumerable<Book> FavoriteBooks { get; set; }
        public IEnumerable<Book> WishBooks { get; set; }
        public IEnumerable<User> Friends { get; set; }
    }
}
