using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BooksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.Include(b=>b.Category).ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }


        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] BookViewModel model)
        {
            if(model.IsValide)
            {
                _context.Books.Add(new Book { 
                    Name = model.Name,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Category =_context.Categories.Where(c=>c.Id == model.CategoryId).FirstOrDefault(),
                    Href = model.Href
                });
                Debug.Write("--------------------------------------------------------");
                Debug.Write(_context.Categories.Where(c => c.Id == model.CategoryId).FirstOrDefault().Name);
                Debug.Write("--------------------------------------------------------");
                await _context.SaveChangesAsync();
                return Ok(model);

            }
            else
            {
                return BadRequest(model);
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            Debug.Write("--------------------------------------------------------");
            Debug.Write("--------------------------------------------------------");
            Debug.Write("--------------------------------------------------------");

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
