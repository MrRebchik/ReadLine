namespace ReadLine.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
