using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.DataTransferObjects;
using AutoMapper;
using Entities.Models;

namespace BookCatalog.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public AuthorController(IRepositoryManager repository ,ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var Authors = await _repository.Author.GetAllAuthorsAsync(trackChanges: false);
            if (Authors == null)
            {
                return NotFound();
            }
            else
            {
                var mappedAuthors = _mapper.Map<IEnumerable<AuthorDto>>(Authors);
                return Ok(mappedAuthors);
            }
        }

        [HttpGet("{authorId}", Name = "GetAuthorBooks")]
        public async Task<IActionResult> GetAuthorsBook(Guid authorId)
        {
            var author = await _repository.Author.GetAuthorAsync(authorId, trackChanges: false);
            if (author == null)
            {
                _logger.LogInfo($"Author with id: {authorId} doesn't exist in the database");
                return NotFound();
            }

            var authorBooks = await _repository.Author.GetAuthorBooksAsync(authorId, trackChanges: false);
            if (authorBooks == null)
            {
                _logger.LogInfo($"Author with {authorId} hasn't written any book yet.");
                return NotFound();
            }
            var _authorBooks = _mapper.Map<AuthorBooksDto>(authorBooks);
            return Ok(_authorBooks);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author == null)
            {
                _logger.LogError("AuthorForCreationDto");
                return BadRequest("AuthorForCreationDto object is null");
            }

            var authorEntity = _mapper.Map<Author>(author);
            _repository.Author.createAuthor(authorEntity);
            await _repository.SaveAsync();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return Ok(authorToReturn);
        }

        [HttpDelete("{authorId}", Name = "DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(Guid authorID)
        {
            var author =  await _repository.Author.GetAuthorAsync(authorID, trackChanges:false);
            if(author == null)
            {
                _logger.LogInfo($"Author with id {authorID} doesen't exists in database.");
                return NotFound();
            }
            else
            {
                _repository.Author.deleteAuthor(author);
                await _repository.SaveAsync();
                return NoContent();
            }
        }
        [HttpPut]
        public async Task <IActionResult> UpdateAuthor(Guid authorID, [FromBody] AuthorToUpdateDto author)
        {
            if (author == null)
            {
                _logger.LogInfo($"Author object set from client is null.");
                return BadRequest();
            }
            var authorEntity = await _repository.Author.GetAuthorAsync(authorID, trackChanges: true);
            if(authorEntity == null)
            {
                _logger.LogInfo($"Author with id: {authorID} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(author, authorEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
