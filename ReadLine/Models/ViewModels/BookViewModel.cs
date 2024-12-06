using Microsoft.EntityFrameworkCore;

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
        public BookViewModel(Book book)
        {
            BookId = book.BookId;
            Title = book.Title;
            AuthorName = book.Author.Name;
            AuthorSurname = book.Author.Surname;
            Category = book.Category.Name;
            AgeLimit = book.AgeLimit.ToString();
            PublicationYear = book.PublicationYear;
            Tags = book.Tags.Select(b => b.Name).ToList();
            PagesCount = book.PagesCount;
        }
    }
}
