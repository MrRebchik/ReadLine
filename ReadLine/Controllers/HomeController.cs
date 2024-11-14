using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;

namespace ReadLine.Controllers
{
    public class HomeController : Controller
    {
        private MainDataContext context;
        public HomeController(MainDataContext context) { this.context = context; }
        public async Task<IActionResult> Index()
        {
            var books = await context.Books.Include(b => b.Author).ToListAsync();
            return View(context.Books.ToList());
        }
        public IActionResult OpenBookPage()
        {
            long id = long.Parse(HttpContext.Request.Query["itemid"]);
            return RedirectPermanent($"/api/books/{id}");
        }
    }
}
