namespace Application.Dtos.Request.Users;

public class UserLogInDto
{
    public string Email { get; set; } = string.Empty;    
    public string Password { get; set; } = string.Empty;
}