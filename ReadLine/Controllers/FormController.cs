using Microsoft.AspNetCore.Mvc;
using ReadLine.Models;

namespace ReadLine.Controllers
{
    public class FormController : Controller
    {
        private MainDataContext context { get; set; }
        public FormController (MainDataContext mainDataContext)
        {
            this.context = mainDataContext;
        }
        public async Task<IActionResult> Index(long id = 1)
        {
            return View("Form", await context.Books.FindAsync(id));
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            foreach(string key in Request.Form.Keys.Where(k => !k.StartsWith("_")))
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }
            return RedirectToAction(nameof(Results));
        }
        public IActionResult Results()
        {
            return View(TempData);
        }
    }
}
