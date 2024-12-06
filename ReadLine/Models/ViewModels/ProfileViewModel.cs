using Microsoft.AspNetCore.Identity;
using ReadLine.Models.People;
using Microsoft.EntityFrameworkCore;

namespace ReadLine.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string UserName;
        public string ProfileQuote;
        public List<BookViewModel> ReadBooks;
        public List<BookViewModel> FavoriteBooks;
        public List<BookViewModel> WishBooks;
        public bool IsAuthenticated;
        public string SelectedList;

        public ProfileViewModel()
        {
            IsAuthenticated = false;
        }
    
        public ProfileViewModel(UserProfile userProfile)
        {
            UserName = userProfile.IdentityUserName;
            ProfileQuote = userProfile.ProfileQuote;
            IsAuthenticated = true;
            ReadBooks = userProfile.ReadBooks.Select(book => new BookViewModel(book)).ToList();
            FavoriteBooks = userProfile.FavoriteBooks.Select(book => new BookViewModel(book)).ToList();
            WishBooks = userProfile.WishBooks.Select(book => new BookViewModel(book)).ToList();
        }
    }
}
