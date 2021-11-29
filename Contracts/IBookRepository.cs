using Entities;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetBookAsync(Guid id, bool trackChangers);
        Task<BookDto> getBookInfoAsync(Guid id, bool trackChanges);
        void CreateBookForAuthor(BookForCreationDto book);
        Task addAuthorToBook(Guid id, AddAuthorToBookDto addAuthorToBook);
        void createBook(Book book);
        void updateBook(Book book);
        void deleteBook(Book book);

    }
}
