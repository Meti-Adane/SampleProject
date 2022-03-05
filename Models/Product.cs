using System;
using System.ComponentModel.DataAnnotations;

namespace sitesampleproject.Models {
    public class Product{
        [Required]
        public Guid Id {get; init; }
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        public double Price {get; set;}

    }
}