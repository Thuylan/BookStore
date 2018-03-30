﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public AuthorDto Author { get; set; }

        [Required]
        [Display(Name = "Author")]
        public byte AuthorId { get; set; }

        public GenreDto Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Required]
        public string Publisher { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Content Summary")]
        public string ContentSummary { get; set; }

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
    }
}