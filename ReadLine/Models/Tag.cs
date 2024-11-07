namespace ReadLine.Models
{
    public class Tag
    {
        public long TagId { get; set; }
        public string Name { get; set; }
        //public IEnumerable<BookTag> BookTags { get; set; }
        public List<Book> Books { get; set; }
    }
}
