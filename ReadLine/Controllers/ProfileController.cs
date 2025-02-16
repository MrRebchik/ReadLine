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
    }
}
