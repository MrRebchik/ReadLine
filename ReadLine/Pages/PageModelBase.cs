using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReadLine.Models.People;

namespace ReadLine.Pages
{
    public class PageModelBase : PageModel
    {
        public UserManager<IdentityUser> UserManager;
        public ProfileContext ProfileContext;
        public PageModelBase(UserManager<IdentityUser> usrManager, ProfileContext profileContext)
        {
            UserManager = usrManager;
            ProfileContext = profileContext;
        }
    }
}
