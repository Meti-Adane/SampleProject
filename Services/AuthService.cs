using sitesampleproject.Data;
using sitesampleproject.Models;
using sitesampleproject.JwtHelpers;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace sitesampleproject.Services;

public class AuthService{
    private readonly AppDBContext _context;
    private readonly AppSettings _appSettings;

    public AuthService(AppDBContext context, IOptions<AppSettings> appSettings){
        _context = context;
        _appSettings = appSettings.Value;
    }

    public User GetUserById (Guid id){
        return _context.Users.SingleOrDefault(user => user.Id == id);
    }
    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public string? SignupRegularUser(User user){
        try {
             _context.Users.Add(user);
            _context.SaveChangesAsync();
            return  generateJwtToken(user);
        }  catch{
            return null;
        }   

    }
    public string? Login(User user){
        User? userprofile = _context.Users.SingleOrDefault(entity => (entity.EmailAddress == user.EmailAddress && Guid.Equals(entity.Id, user.Id)) );
        if (userprofile is null){
            return null;
        }
        return  generateJwtToken(userprofile);
    }
}