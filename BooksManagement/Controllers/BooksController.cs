using BooksManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagement.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDbContext _context;

        public BooksController(BooksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.Where(d => !d.IsDeleted).ToList();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var books = _context.Books.SingleOrDefault(d => d.Id == id);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id,Book input)
        {
            var book = _context.Books.SingleOrDefault(d => d.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.Update(input.Title, input.Genre, input.Author, input.StartDate, input.EndDate);

            _context.Books.Update(book);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var books = _context.Books.SingleOrDefault(d => d.Id == id);

            if (books == null)
            {
                return NotFound();
            }

            books.Delete();

            _context.SaveChanges();

            return NoContent();
        }
    }
}
