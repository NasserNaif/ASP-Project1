using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Project1.Repository;

public class TokenRepoImpl : ITokenRepo
{
    private readonly IConfiguration _configuration;

    public TokenRepoImpl(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string CreateToken(IdentityUser user, List<string> roles)
    {
        // Create claims
        var claims = new List<Claim>();
        
        claims.Add(new Claim(ClaimTypes.Email,user.Email));

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role,role));
        }
        
        // Get the secret key
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        // generate the token 
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"], // the issuer
            _configuration["Jwt:Audience"], // the audience
            claims, // the claims
            expires: DateTime.Now.AddMinutes(10), // the expiration
            signingCredentials: credential // credentials ( roles )
        );

        
        // return the token 
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}