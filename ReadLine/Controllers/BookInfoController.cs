using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;

namespace ReadLine.Controllers
{
    public class BookInfoController : Controller
    {
        private MainDataContext context;
        public BookInfoController(MainDataContext context) { this.context = context; }
        public async Task<IActionResult> Index(long id)
        {
            var book = await context.Books.Include(b => b.Author).Where(b => b.BookId == id).FirstOrDefaultAsync();
            return View(await context.Books.FindAsync(id));
        }
    }
}
