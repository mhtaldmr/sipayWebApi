using Application.Dtos.Response.Token;
using Domain.Entity;

namespace Application.Interfaces.Services.TokenService;

public interface ITokenService 
{
    TokenResponse GetToken(User user, IList<string> roles);
}