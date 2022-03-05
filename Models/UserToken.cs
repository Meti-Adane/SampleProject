
namespace sitesampleproject.Models;
public class UserToken
{
    public Guid Id { get; set; }
    public string EmailAddress { get; set; }
    public string Token { get; set; }


    public UserToken(User user, string token)
    {
        Id = user.Id;
        EmailAddress = user.EmailAddress;
        Token = token;
    }
}