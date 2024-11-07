using Microsoft.EntityFrameworkCore;
using ReadLine.Models.People;

namespace ReadLine.Models
{
    public class MainDataContext : DbContext
    {
        public MainDataContext(DbContextOptions<MainDataContext> opts) : base(opts) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserReadBook> UserReadBooks { get; set; }
        public DbSet<UserFavoriteBook> UserFavoriteBooks { get; set; }
        public DbSet<UserWishBook> UserWishBooks { get; set; }

    }
}
