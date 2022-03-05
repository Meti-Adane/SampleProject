
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace sitesampleproject.Models{
    public class SaleRecord{
        public Guid Id {get; set;}
        public User Author {get; set;}

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt {get; set;}
        [Required]
        public int NumberOfItemSold {get; set;}

        [Required]
        public double TotalSalePrice {get; set;}
        public Unit Unit {get; set;}
        public Branch Branch {get; set;}
        public int? NumberAccquiredCustomers {get; set;}
        
    }
}