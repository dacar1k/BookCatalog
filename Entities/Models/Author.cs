using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;

namespace Entities.Models
{
    public class Author
    {
        [Column("AuthorId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Author name is required field.")]
        public string Name { get; set; }
        public List<AuthorBook> AuthorBook { get; set; }
        //public IEnumerable<Book> Books { get; set; } = new List<Book>();
        //Navigation properties

    }
}
