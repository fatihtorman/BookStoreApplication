using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookStoreController : ControllerBase
    {
        private IBookRepository _bookRepository;
        private IPublisherRepository _publisherRepository;
        private IAuthorRepository _authorRepository;
        private readonly ILogger<BookStoreController> _logger;
        public BookStoreController(IBookRepository bookRepository, IPublisherRepository publisherRepository, IAuthorRepository authorRepository, ILogger<BookStoreController> logger)
        {
            _bookRepository = bookRepository;
            _publisherRepository = publisherRepository;
            _authorRepository = authorRepository;
            _logger = logger;
        }

        // GET: api/BookStore/Author
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return _authorRepository.GetAll();
        }

        // GET: api/BookStore/Author/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authors = _authorRepository.GetById(id);

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        // GET: api/BookStore/Publisher
        [HttpGet]
        public IEnumerable<Publisher> GetPublishers()
        {
            return _publisherRepository.GetAll();
        }

        // GET: api/BookStore/Publisher/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublishers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publishers = _publisherRepository.GetById(id);

            if (publishers == null)
            {
                return NotFound();
            }

            return Ok(publishers);
        }



        // POST: api/BookStore/Book
        [HttpPost]
        public async Task<IActionResult> AddBookToStock([FromBody] Book books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!ValidateIsbnNo(books.Isbn.IsbnNo))
                {
                    return NotFound("invalid isbn");
                }
                else
                {
                    _bookRepository.Add(books);
                    _bookRepository.Commit();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var book = _bookRepository.GetById(books.Id);
            return Ok(book.Id);
            
        }

        private bool ValidateIsbnNo(int id)
        {
            return _bookRepository.Find(e => e.Id == id).Any();
        }

        // GET: api/BookStore/validate/5
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
