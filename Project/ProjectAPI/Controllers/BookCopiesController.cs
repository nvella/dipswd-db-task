using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopiesController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public BookCopiesController(ProjectDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BookCopies
        [HttpGet]
        public IEnumerable<BookCopy> GetBookCopy()
        {
            return _context.BookCopy;
        }

        // GET: api/BookCopies/isbn/copyCount
        [HttpGet("{isbn}/{copyCount}")]
        public async Task<IActionResult> GetBookCopy([FromRoute] string isbn, [FromRoute] int copyCount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookCopy = await _context.BookCopy.FindAsync(copyCount, isbn);

            if (bookCopy == null)
            {
                return NotFound();
            }

            return Ok(bookCopy);
        }

        // PUT: api/BookCopies/isbn/copyCount
        [HttpPut("{isbn}/{copyCount}")]
        public async Task<IActionResult> PutBookCopy([FromRoute] string isbn, [FromRoute] int copyCount, [FromBody] BookCopy bookCopy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (copyCount != bookCopy.CopyCount && isbn != bookCopy.Isbn)
            {
                return BadRequest();
            }

            _context.Entry(bookCopy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCopyExists(isbn, copyCount))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookCopies
        [HttpPost]
        public async Task<IActionResult> PostBookCopy([FromBody] BookCopy bookCopy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BookCopy.Add(bookCopy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookCopyExists(bookCopy.Isbn, bookCopy.CopyCount))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookCopy", new { copyCount = bookCopy.CopyCount, isbn = bookCopy.Isbn }, bookCopy);
        }

        // DELETE: api/BookCopies/isbn/copyCount
        [HttpDelete("{isbn}/{copyCount}")]
        public async Task<IActionResult> DeleteBookCopy([FromRoute] string isbn, [FromRoute] int copyCount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookCopy = await _context.BookCopy.FindAsync(copyCount, isbn);
            if (bookCopy == null)
            {
                return NotFound();
            }

            _context.BookCopy.Remove(bookCopy);
            await _context.SaveChangesAsync();

            return Ok(bookCopy);
        }

        private bool BookCopyExists(string isbn, int copyCount)
        {
            return _context.BookCopy.Any(e => e.CopyCount == copyCount && e.Isbn == isbn);
        }
    }
}