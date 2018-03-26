using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

    }
}