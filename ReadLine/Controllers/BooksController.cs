using Microsoft.AspNetCore.Mvc;
using ReadLine.Models;

namespace ReadLine.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private MainDataContext context;
        public BooksController(MainDataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }
        [HttpGet("{id}")]
        public Book GetBook(long id)
        {
            return context.Books.Find(id);
        }
        [HttpPost]
        public void SaveBook([FromBody] Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}
