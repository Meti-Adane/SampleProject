
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sitesampleproject.Models{
    public record Unit{
        public Guid Id {get; set;}
        
        public Branch? Branch {get; set;}
        public string? Location {get; set;}
    }
}