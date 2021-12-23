using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Meeting_26.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Meeting_26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }
        //api/book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        //api/book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(t => t.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        //api/book
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if(book == null)
            {
                return BadRequest();
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            //return Ok(book);
            return CreatedAtAction("Get", new { id = book.Id }, book);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Put([FromBody]Book book)
        {
            if(book==null)
            {
                return BadRequest();
            }
            if (!_context.Books.Any(b => b.Id == book.Id))
                return NotFound();
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
        //api/book/2
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(t => t.Id == id);
            if (book == null)
                return NotFound();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
