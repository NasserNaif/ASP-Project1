using Microsoft.AspNetCore.Identity;

namespace Project1.Repository;

public interface ITokenRepo
{
    string CreateToken(IdentityUser user, List<string> roles);
}