namespace ReadLine.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Book> ReadBooks { get; set; }
        public IEnumerable<Book> FavoriteBooks { get; set; }
        public IEnumerable<Book> WishBooks { get; set; }
        public IEnumerable<User> Friends { get; set; }
    }
}
