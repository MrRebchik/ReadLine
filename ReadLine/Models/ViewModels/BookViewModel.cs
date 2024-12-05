namespace ReadLine.Models.ViewModels
{
    public class BookViewModel
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Category { get; set; }
        public string AgeLimit { get; set; }
        public int PublicationYear { get; set; }
        public List<string> Tags { get; set; }
        public int PagesCount { get; set; }
    }
}
