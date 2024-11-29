using Microsoft.AspNetCore.Mvc;
using ReadLine.Models;

namespace ReadLine.Controllers
{
    public class BookControllerBase : Controller
    {
        protected MainDataContext context;
        public BookControllerBase(MainDataContext context) { this.context = context; }
    }
}
