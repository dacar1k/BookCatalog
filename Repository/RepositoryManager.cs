using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IBookRepository Book
        {
            get
            {
                if (_bookRepository == null) _bookRepository = new BookRepository(_repositoryContext);
                return _bookRepository;
            }
        }
        public IAuthorRepository Author
        {
            get
            {
                if (_authorRepository == null) _authorRepository = new AuthorRepository(_repositoryContext);
                return _authorRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
