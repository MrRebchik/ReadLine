using Microsoft.AspNetCore.Mvc;
using ReadLine.Models;

namespace ReadLine.Controllers
{
    public class HomeController : Controller
    {
        private MainDataContext context;
        public HomeController(MainDataContext context) { this.context = context; }
        public async Task<IActionResult> Index()
        {
            return View(context.Books.ToList());
        }
    }
}
