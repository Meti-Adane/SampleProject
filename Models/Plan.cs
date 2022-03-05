
using System.ComponentModel.DataAnnotations;

namespace sitesampleproject.Models{
    public class Plan {
        public Guid Id {get; set;}
        public User Author {get; set;}

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt {get; init;}
        public string? Title {get; set;}
        public string? Content {get; set;}
    }
}