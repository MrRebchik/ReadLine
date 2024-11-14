using Microsoft.EntityFrameworkCore;

namespace ReadLine.Models.People
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> opts) : base(opts) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
