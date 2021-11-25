using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public interface IAuthorRepository
    {
        Task <IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
        Task <Author> GetAuthorAsync(Guid authorID, bool trackChanges);
        Task <AuthorBooksDto> GetAuthorBooksAsync(Guid id, bool trackChanges);
        void createAuthor(Author author);
        void updateAuthor(Author author);
        void deleteAuthor(Author author);
    }
}
