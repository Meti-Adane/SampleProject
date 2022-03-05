
using System;
using System.ComponentModel.DataAnnotations;

namespace sitesampleproject.Models{
    public class User{
        [Required]
        [StringLength(40, MinimumLength = 2)]

        public Guid Id {get; set; }
        [Required]
        public Guid RoleId {get; set;}
        
        public string Name {get; set;}

        [Required]
        [StringLength(10)]
        [RegularExpression(@"[0-9]")]
        public string PhoneNumber {get; set;}

        [DataType(DataType.EmailAddress)]
        public string EmailAddress {get; set;}

        [DataType(DataType.Date)]
        public char Gender {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password{get; set;}

        [DataType(DataType.Date)]
        public DateOnly BirthDate {get; set;}

        [DataType(DataType.Date)]
        public DateTime ExemptDate {set; get;}
        public bool isActive {get; set;}
    }
}