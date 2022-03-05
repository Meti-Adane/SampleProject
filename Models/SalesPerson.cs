
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sitesampleproject.Models{
    [Keyless]
    public class SalesPerson {
        
        public User Id {get; set;}
        public long NumberOfItemsSold {get; set;}
        public double TotalSalePrice {get; set;}

        [DataType(DataType.Date)]
        public DateTime StartDate {get; init;}
        
        [Required]
        public Unit? Unit {get; set;}

        
    }
}