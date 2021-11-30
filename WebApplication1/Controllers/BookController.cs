using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities;

namespace BookCatalog.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
                     
            var books1 = await _repository.Book.GetAllBooksAsync(trackChanges: false);
            var books = _mapper.Map<IEnumerable<AllBooksDto>>(books1);
            if (books == null) 
            {                         
                return NotFound(); 
            } 
            else 
            { 
                return Ok(books); 
            }
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task <IActionResult> GetBook(Guid id)
        {
            var book = await _repository.Book.getBookInfoAsync(id, trackChanges: false);
            if (book == null)
            {
                _logger.LogInfo($"Book with id: {id} doesn't exist in database");
                return NotFound();
            }
            else
            {
                var bookDto = _mapper.Map<BookDto>(book);
                return Ok(bookDto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Guid bookID, [FromBody] BookToUpdateDto book)
        {
            if (book == null)
            {
                _logger.LogError("BookUpdateDto object sent from client is null.");
                return BadRequest("BookUpdateDto object is null");
            }
            var bookEntity = await _repository.Book.GetBookAsync(bookID, trackChangers: true);
            if (bookEntity == null)
            {
                _logger.LogInfo($"Book with id: {bookID} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(book, bookEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost(Name = "CreateBookForAuthor")]
        public async Task <IActionResult> CreateBookForAuthor([FromBody] BookForCreationDto book)
        {
            if (book == null)
            {
                _logger.LogError("BookForCreationDto object sent from client is null.");
                return BadRequest("BookForCreationDto object is null");
            }

            var bookEntity = _mapper.Map<Book>(book);
            await _repository.Book.CreateBookForAuthor(book);
            await _repository.SaveAsync();

            return Ok();
        }

        [HttpPost("{bookId}", Name = "AddbooktoAuthor")]
        public async Task<IActionResult> AddAuthorForBook(Guid bookID, AddAuthorToBookDto author)
        {
            if (author == null)
            {
                _logger.LogError("BookUpdateDto object sent from client is null.");
                return BadRequest("BookUpdateDto object is null");
            }
            var bookEntity = await _repository.Book.GetBookAsync(bookID, trackChangers: true);
            if (bookEntity == null)
            {
                _logger.LogInfo($"Book with {bookID} doesn't exists in database.");
                return NotFound();
            }
            await _repository.Book.addAuthorToBook(bookID, author);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            var book = await _repository.Book.GetBookAsync(bookId, trackChangers: false);
            if (book == null)
            {
                _logger.LogInfo($"Book with id:{bookId} doesn't exist in the database");
                return NotFound();
            }

            _repository.Book.deleteBook(book);
            await _repository.SaveAsync();
            return NoContent();
        }


    }

}
