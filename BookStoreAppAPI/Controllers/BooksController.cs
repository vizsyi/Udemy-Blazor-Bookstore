using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAppAPI.Data;
using BookStoreAppAPI.Model.BookDTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BookStoreAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadDTO>>> GetBooks()
        {
            //var books = await _context.Books.Include(q => q.Author).ToListAsync();
            //var booksDTO = _mapper.Map<IEnumerable<BookReadDTO>>(books);
            var booksDTO = await _context.Books
                .Include(q => q.Author)
                .ProjectTo<BookReadDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(booksDTO);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBook(int id)
        {
            var bookDTO = await _context.Books
                .Include(q => q.Author)
                .ProjectTo<BookDetailsDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (bookDTO == null)
            {
                return NotFound();
            }

            return bookDTO;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookUpdateDTO bookDTO)
        {
            if (id != bookDTO.Id)
            {
                return BadRequest();
            }

            var book = await _context.Authors.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDTO, book);
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BookExistsAsync(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookCreateDTO>> PostBook(BookCreateDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> BookExistsAsync(int id)
        {
            return await _context.Books.AnyAsync(e => e.Id == id);
        }
    }
}
