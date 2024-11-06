namespace ReadLine.Models
{
    public class Author
    {
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; } //Отчество
        public IEnumerable<Book> Books { get; set; }
    }
}
