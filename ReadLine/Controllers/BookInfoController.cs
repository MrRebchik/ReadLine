using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;

namespace ReadLine.Controllers
{
    public class BookInfoController : BookControllerBase
    {
        public BookInfoController(MainDataContext context) : base(context){ }
        public async Task<IActionResult> Index(long id)
        {
            var book = context.Books.Include(b => b.Author).Include(b => b.Tags).Include(b => b.Category).First(b => b.BookId == id);
            foreach (var t in book.Tags)
            {
                t.Books = null;
            }
            book.Category.Books = null;
            book.Author.Books = null;
            return View(book);
        }
    }
}
