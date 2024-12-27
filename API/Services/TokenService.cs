using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Interface;
using API.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot Access Token Key from appsettings");
        //throw new NotImplementedException();
        if (tokenKey.Length<64)
        {
            throw new Exception("Token Key must be at least 64 characters long");
        }
       
       var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

       var claims = new List<Claim>{
              new (ClaimTypes.NameIdentifier, user.UserName)
       };

       var tokenDescriptor = new SecurityTokenDescriptor
       {
              Subject = new ClaimsIdentity(claims),
              Expires = DateTime.Now.AddDays(7),
              SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
       };

       var tokenHandler = new JwtSecurityTokenHandler();
       var token = tokenHandler.CreateToken(tokenDescriptor);
        // Return a dummy token for now
        return tokenHandler.WriteToken(token);
    }
}
