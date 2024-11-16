using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var book = context.Books.Include(b => b.Author).Include(b => b.Tags).Include(b => b.Category).First(b => b.BookId == id);
            foreach(var t in book.Tags)
            {
                t.Books = null;
            }
            book.Category.Books = null;
            book.Author.Books = null;
            return book;
        }
        [HttpPost]
        public void SaveBook([FromBody] Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}
