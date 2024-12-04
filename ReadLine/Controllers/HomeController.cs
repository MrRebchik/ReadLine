using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;
using System.Linq;

namespace ReadLine.Controllers
{
    public class HomeController : BookControllerBase
    {
        public HomeController(MainDataContext context): base(context) { }
        public async Task<IActionResult> Index(IEnumerable<Book> booksSearch = null)
        {
            IEnumerable<Book> books;
            if (booksSearch == null)
            {
                books = await context.Books.Include(b => b.Author).ToListAsync();
            }
            else
            {
                books = booksSearch;
            }
            return View(context.Books.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> SearchForm(string search)
        {
            IEnumerable<Book> books = await context.Books.Include(b => b.Author).ToListAsync();
            IEnumerable<Book> result = books.
                Where(b =>
                search.ToString().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Intersect(b.Title.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries)).Count() > 0).
                ToList();
            return View("Index", result);
        }
    }
}
