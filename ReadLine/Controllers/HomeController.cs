using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReadLine.Controllers
{
    public class HomeController : Controller
    {
        private MainDataContext context;
        public HomeController(MainDataContext context) { this.context = context; }
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
        public IActionResult OpenBookPage()
        {
            long id = long.Parse(HttpContext.Request.Query["itemid"]);
            return Redirect($"/BookInfo/Index/{id}");
        }

        [HttpPost]
        public IActionResult SearchForm()
        {
            foreach (string key in Request.Form.Keys.Where(k => !k.StartsWith("_")))
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }
            return RedirectToAction(nameof(Results));
        }
        public async Task<IActionResult> Results()
        {

            IEnumerable<Book> books = await context.Books.Include(b => b.Author).ToListAsync();
            IEnumerable<Book> result = books.
                Where(b => 
                TempData["search-string"].ToString().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).Intersect(b.Title.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries)).Count()>0).
                ToList();
            return View("Index", result);
        }
        //private List<Book> AssertFilter(Book b, string filter)
        //{
        //    string[] inputs = filter.Split([' ', ',', '.']);
        //    int matchCount = 0;
        //    foreach (var item in inputs)
        //    {
        //        Regex regex = new Regex(item.Substring(0,item.Length-2) + "(\\w*)", RegexOptions.IgnoreCase); //TODO если строка длиной 1
        //        MatchCollection titleMatches = regex.Matches(b.Title);
        //        MatchCollection authorMatches = regex.Matches(b.Author.Name);
        //        matchCount += titleMatches.Count;
        //        matchCount += authorMatches.Count;
        //    }
        //    return matchCount > 0;
        //}
        public List<Book> SearchProducts(string pattern)
        {
            // Компиляция регулярного выражения
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // Фильтрация товаров по совпадению с регулярным выражением
            var filteredProducts = context.Books.Where(p => regex.IsMatch(p.Title)).ToList();

            return filteredProducts;
        }
    }
}
