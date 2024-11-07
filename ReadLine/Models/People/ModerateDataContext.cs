using Microsoft.EntityFrameworkCore;

namespace ReadLine.Models.People
{
    public class ModerateDataContext : DbContext
    {
        public ModerateDataContext(DbContextOptions<ModerateDataContext> opts) : base(opts) { }
        public DbSet<ModeratorModerateRequest> ModeratorModerateRequests { get; set; }
    }
}
