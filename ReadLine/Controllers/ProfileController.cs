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
        public UserProfile Profile { get; set; }
        private ProfileContext ProfileContext;
        private MainDataContext MainDataContext;
        private List<Book> Books;
        private List<UserProfile> UserProfiles;
        public ProfileController(MainDataContext mainDataContext, ProfileContext profileContext) : base(mainDataContext)
        {
            ProfileContext = profileContext;
            MainDataContext = mainDataContext;
            Books = MainDataContext.Books.Include(b => b.Author).Include(b => b.Tags).Include(b => b.Category).ToList();
            UserProfiles = ProfileContext.UserProfiles
                    .Include(b => b.ReadBooks)
                    .Include(b => b.FavoriteBooks)
                    .Include(b => b.WishBooks).ToList();
        }
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
        public async Task<IActionResult> AddBook(long id, [FromQuery] string selectedList)
        {
            ProfileViewModel profileVM = new ProfileViewModel();
            if (User.Identity.IsAuthenticated)
            {
                Profile = await ProfileContext.UserProfiles.FindAsync(User.Identity.Name);
                Book book = MainDataContext.Books.First(b => b.BookId == id);
                switch (selectedList.ToLower())
                {
                    //сначала проверить что такой книги еще нет
                    case "readbooks":
                        Profile.ReadBooks.Add(book);
                        break;
                    case "wishbooks":
                        Profile.WishBooks.Add(book);
                        break;
                    case "favoritebooks":
                        Profile.FavoriteBooks.Add(book);
                        break;
                }
                profileVM = new ProfileViewModel(Profile);
            }
            return View("Index", profileVM);
        }
    }
}
