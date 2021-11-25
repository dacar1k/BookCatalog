using Entities.DataTransferObjects;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly RepositoryContext _repository;

        public BookRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            _repository = repositoryContext;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Title).ToList();
        public async Task<Book> GetBookAsync(Guid bookId, bool trackChanges) => FindByCondition(c => c.Id.Equals(bookId), trackChanges).SingleOrDefault();

        public void createBook(Book book) => Create(book);
        public void updateBook(Book book) => Update(book);
        public void deleteBook(Book book) => Delete(book);
        
        public void addAuthorToBook(Guid bookId, AddAuthorToBookDto addAuthorToBook)
        {
            var bookProperties = getBookInfoAsync(bookId, false);
            foreach (var _authorsBook in addAuthorToBook.AuthorsIds.Select(a => new AuthorBook
            {
                AuthorId = a,
                BookId = bookId
            }))
            {
                _repository.AuthorBook.Add(_authorsBook);
                _repository.SaveChanges();
            }
        }
        public async Task<BookDto> getBookInfoAsync(Guid id, bool trackChanges)
        {
            var bookInfo = _repository.Books.Where(a => a.Id == id).Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                AuthorsIds = book.AuthorBook.Select(a => a.AuthorId).ToList()
            }).FirstOrDefault();
            return bookInfo;
        }
    }
}
