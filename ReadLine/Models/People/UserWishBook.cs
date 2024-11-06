namespace ReadLine.Models.People
{
    public class UserWishBook
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long WishBookId { get; set; }
        public Book WishBook { get; set; }
    }
}
