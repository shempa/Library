using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Threading.Tasks;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        LibraryContext db;
        public BooksController(LibraryContext context)
        {
            db = context;
            if (!db.Books.Any())
            {
                db.Books.Add(new Book { Name = "Tom"});
                db.Books.Add(new Book { Name = "Alice"});
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await db.Books.ToListAsync();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book book = await db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if (book == null)
                return BadRequest();

            if (book.Name == "")
                return BadRequest();

            db.Books.Add(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        // PUT api/book/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(Book book)
        {
            if (book == null)
                return BadRequest();

            if (db.Books.Where(x => x.Id = book.Id && x.UserId = book.UserId))
                book.UserId = null;

            if (!db.Books.Any(x => x.Id == book.Id))
                return NotFound();

            db.Update(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            Book book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }
    }
}