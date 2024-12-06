using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;
using ReadLine.Models.ViewModels;

namespace ReadLine.Controllers
{
    public class BookInfoController : BookControllerBase
    {
        public BookInfoController(MainDataContext context) : base(context){ }
        public async Task<IActionResult> Index(long id)
        {
            var book = context.Books.Include(b => b.Author).Include(b => b.Tags).Include(b => b.Category).First(b => b.BookId == id);
            BookViewModel bookViewModel = new BookViewModel(book);
            return View(bookViewModel);
        }
    }
}
