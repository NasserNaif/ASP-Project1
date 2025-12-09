using System.ComponentModel.DataAnnotations;

namespace Project1.Models.DTO;

public class UserLogInDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}