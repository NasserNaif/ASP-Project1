using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project1.Models.DTO;
using Project1.Repository;

namespace Project1.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly ITokenRepo _tokenRepo;

    public AuthController(UserManager<IdentityUser> _userManager, ITokenRepo tokenRepo)
    {
        userManager = _userManager;
        _tokenRepo = tokenRepo;
    }
    
    // Register user API
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto  userRegisterRequestDto)
    {
        var user = new IdentityUser
        {
            Email = userRegisterRequestDto.Username,
            UserName = userRegisterRequestDto.Username
        };
        
        var result  = await userManager.CreateAsync(user, userRegisterRequestDto.Password);

        if (!result.Succeeded || userRegisterRequestDto.Roles is not { Length: > 0 }) return BadRequest("Something went wrong");
        result =   await userManager.AddToRolesAsync(user,userRegisterRequestDto.Roles);

        if (result.Succeeded)
        {
            return Ok("User created successfully");
        }

        return BadRequest("Something went wrong");
    }
    
    // Login user API
    [HttpPost]
    [Route(("Login"))]
    public async Task<IActionResult> Login([FromBody] UserLogInDto userLogInDto)
    {
        var existUser = await userManager.FindByEmailAsync(userLogInDto.Username);
        
        if (existUser == null) return Unauthorized();
        
        var result = await userManager.CheckPasswordAsync(existUser, userLogInDto.Password);
        if (result)
        {
            // Get user roles
            var roles = await userManager.GetRolesAsync(existUser);
            if (roles == null || roles.Count < 1) return Unauthorized();
            // Generate a token 
            var token =  _tokenRepo.CreateToken(existUser, roles.ToList());
            
            var response = new {Token = token, Message = "Welcome back"};
            return Ok(response);
        }
        return Unauthorized();
    }
}
