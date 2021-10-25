using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookRepository bookRepository, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> GetBook()
        {
            return _bookRepository.GetAll();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var books = _bookRepository.GetById(id);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

      

        // POST: api/Book
        [HttpPost]
        public async Task<IActionResult> AddBookToStock([FromBody] Book books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _bookRepository.Add(books);
                _bookRepository.Commit();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var book = _bookRepository.GetById(books.Id);
            return Ok(book.Id);
           
        }

        //private bool BookExists(int id)
        //{
        //    return _bookRepository.Find(e => e.Id == id).Any();
        //}

        // GET: api/Book/validate/5
        [HttpGet("validate/{id}")]
        public IActionResult ValidateIsbn([FromRoute] int id)
        {
            if (_bookRepository.Find(e => e.Id == id).Any())
                return Ok();
            else
            {
                return NotFound();
            }


        }
    }
}
