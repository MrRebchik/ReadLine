using Microsoft.EntityFrameworkCore;
using ReadLine.Models.People;

namespace ReadLine.Models
{
    public class ModerateDataContext : DbContext
    {
        public ModerateDataContext(DbContextOptions<ModerateDataContext> opts) : base(opts) { }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<ModereteRequest> ModereteRequests { get; set; }
    }
}
