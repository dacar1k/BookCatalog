using AutoMapper;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorToUpdateDto, Author>();
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<Author, AuthorBooksDto>();

            CreateMap<Book, BookDto>();
            CreateMap<Book, AllBooksDto>();
            CreateMap<BookForCreationDto, Book>();
            CreateMap<BookToUpdateDto, Book>();
        }
    }
}
