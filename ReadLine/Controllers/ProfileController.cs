using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models;
using ReadLine.Models.People;
using ReadLine.Models.ViewModels;

namespace ReadLine.Controllers
{
    public class ProfileController : BookControllerBase
    {
        private ProfileContext ProfileContext;
        public ProfileController(MainDataContext mainDataContext, ProfileContext profileContext) : base(mainDataContext)
        {
            ProfileContext = profileContext;
        }

        public IdentityUser IdentityUser { get; set; }
        public UserProfile Profile { get; set; }
        public async Task<IActionResult> Index()
        {
            ProfileViewModel profileVM = new ProfileViewModel();
            if (User.Identity.IsAuthenticated)
            {
                Profile = await ProfileContext.UserProfiles.FindAsync(User.Identity.Name);
                profileVM = new ProfileViewModel(Profile) ;
            }
            return View(profileVM);
        }
        [HttpPost]
        public async Task<IActionResult> SearchForm(string search = "")
        {
            List<Book> books = await context.Books.Include(b => b.Author).Include(b => b.Tags).Include(b => b.Category).ToListAsync();
            List<BookViewModel> result = books.
            Where(b =>
            search.ToString().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).
            Intersect(b.Title.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries)).Count() > 0).
            Select(book => new BookViewModel(book))
            .ToList();
            return View("Index", new ProfileViewModel(await ProfileContext.UserProfiles.FindAsync(User.Identity.Name)) { SearchBooks = result, IfSearchModalOpen = "show"});
        }
    }
}
