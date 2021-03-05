using System;
using System.Collections.Generic;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Сategory>>> GetCategories()
        {
            return await _context.Categories.Include(c=>c.Books).ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Сategory>> GetСategory(int id)
        {
            var сategory = await _context.Categories.Include(c=>c.Books).Where(c=>c.Id == id).FirstOrDefaultAsync();

            if (сategory == null)
            {
                return NotFound();
            }

            return сategory;
        }

       
        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> PostСategory(CategoryViewModel model)
        {
            if(model.IsValide)
            {
                _context.Categories.Add(new Сategory { Name = model.Name});
                await _context.SaveChangesAsync();
                return model;
            }
            return BadRequest(model);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Сategory>> DeleteСategory(int id)
        {
            var сategory = await _context.Categories.FindAsync(id);
            if (сategory == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(сategory);
            await _context.SaveChangesAsync();

            return сategory;
        }

        private bool СategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
