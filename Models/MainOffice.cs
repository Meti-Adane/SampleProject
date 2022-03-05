
namespace sitesampleproject.Models{
    public record MainOffice {
        public Guid Id {get; init;}
        public string Name {get; set;}
        public string Location {get; set;}
        public string PhoneNumber {get; set;}
        public long  BankAccount {get; set;}
    }
}