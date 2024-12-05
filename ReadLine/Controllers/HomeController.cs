using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;
using ReadLine.Models.ViewModels;

namespace ReadLine.Controllers
{
    public class HomeController : BookControllerBase
    {
        public HomeController(MainDataContext context): base(context) { }
        public async Task<IActionResult> Index()
        {
            List<BookViewModel> books = await context.Books.Include(b => b.Author).Select(book => new BookViewModel()
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = book.Author.Name,
                AuthorSurname = book.Author.Surname,
                Category = book.Category.Name,
                AgeLimit = book.AgeLimit.ToString(),
                PublicationYear = book.PublicationYear,
                Tags = book.Tags.Select(b => b.Name).ToList(),
                PagesCount = book.PagesCount,
            }).ToListAsync();
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> SearchForm(string search = "")
        {
            List<Book> books = await context.Books.Include(b => b.Author).Include(b => b.Tags).Include(b => b.Category).ToListAsync();
            List<BookViewModel> result = books.
            Where(b =>
            search.ToString().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).
            Intersect(b.Title.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries)).Count() > 0).
            Select(book => new BookViewModel()
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = book.Author.Name,
                AuthorSurname = book.Author.Surname,
                Category = book.Category.Name,
                AgeLimit = book.AgeLimit.ToString(),
                PublicationYear = book.PublicationYear,
                Tags = book.Tags.Select(b => b.Name).ToList(),
                PagesCount = book.PagesCount,
            }).ToList();
            return View("Index", result);
        }
    }
}
