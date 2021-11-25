using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Book
    {
        [Column("BookId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Book title is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for book title 30 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is a required field.")]
        public int Year { get; set; }

        [ForeignKey(nameof(Author))]
        public List<AuthorBook> AuthorBook { get; set; }

    }
}
