namespace ReadLine.Models.People
{
    public class UserFavoriteBook
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long FavoriteBookId { get; set; }
        public Book FavoriteBook { get; set; }
    }
}
