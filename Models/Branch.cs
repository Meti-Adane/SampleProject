
namespace sitesampleproject.Models{
    public record Branch{
        public Guid Id {get; set;}
        public string? CompanyName {get; set;}
        public string? Location {get; set;}
        public Guid MainOfficeId {get; init;}
    }
}