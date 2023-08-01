using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Application.Dtos.Request.Users;

public class UserSignUpDto
{
    public string FirstName { get; set; } = string.Empty; 
    public string LastName { get; set;} = string.Empty; 
    public string IdNo { get; set; } = string.Empty; 
    public int Phone {get; set;}
    public string Email { get; set; } = string.Empty;    
    public string Password { get; set; } = string.Empty;
}