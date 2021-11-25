using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Repository
{
    public class AuthorRepository: RepositoryBase<Author>, IAuthorRepository
    {
        private readonly RepositoryContext _repository;
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repository = repositoryContext;
        }
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        public async Task<Author> GetAuthorAsync(Guid authorId, bool trackChanges) => FindByCondition(c => c.Id.Equals(authorId), trackChanges).SingleOrDefault();
        
        public async Task<AuthorBooksDto> GetAuthorBooksAsync(Guid auihorID, bool trackChanges)
        {
            var _authorBook = _repository.Authors.Where(a => a.Id == auihorID).Select(ab => new AuthorBooksDto
            {
                Id = ab.AuthorBook.Select(b => b.Id).ToList(),
                BookTitles = ab.AuthorBook.Select(b => b.Book.Title).ToList()
            }).FirstOrDefault() ;
            return _authorBook;
        }
        public void createAuthor(Author author) => Create(author);
        public void updateAuthor(Author author) => Update(author);
        public void deleteAuthor(Author author) => Delete(author);
    }
}
