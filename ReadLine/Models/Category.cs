namespace ReadLine.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
