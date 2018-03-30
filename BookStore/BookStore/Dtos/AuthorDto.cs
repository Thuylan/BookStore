using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Dtos
{
    public class AuthorDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Biography { get; set; }
    }
}