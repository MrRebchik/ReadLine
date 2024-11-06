namespace ReadLine.Models.People
{
    public class UserReadBook
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long ReadBookId { get; set; }
        public Book ReadBook { get; set; }
    }
}
