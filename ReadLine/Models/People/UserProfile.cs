using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReadLine.Models.People
{
    public class UserProfile
    {
        [Key]
        public string IdentityUserName { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string? ProfileQuote { get; set; }
        public List<Book> ReadBooks { get; set; } = [];
        public List<Book> FavoriteBooks { get; set; } = [];
        public List<Book> WishBooks { get; set; } = [];
        public List<UserProfile> Friends { get; set; } = [];
    }
}
