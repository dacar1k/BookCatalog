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
        
        public async Task addAuthorToBook(Guid bookId, AddAuthorToBookDto addAuthorToBook)
        {

            var BookInf = await getBookInfoAsync(bookId, trackChanges: false);
            foreach (var _authorsBooks in addAuthorToBook.AuthorsIds.Select(id => new AuthorBook()
            {
                BookId = bookId,
                AuthorId = id
            }).Where(_authorsBooks => !BookInf.AuthorsIds.Exists(_authorsBooks.AuthorId.Equals)))
            {
                _repository.AuthorBook.Add(_authorsBooks);
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
        public void CreateBookForAuthor(BookForCreationDto book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Year = book.Year,
            };
            _repository.Books.Add(_book);
            _repository.SaveChanges();

            foreach (var id in book.AuthorsIds)
            {
                var _authorsBooks = new AuthorBook()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _repository.AuthorBook.Add(_authorsBooks);
                _repository.SaveChanges();
            }
        }
    }
}
