using Application.Dtos.Request.Users;
using Application.Dtos.Response.Common;
using Application.Dtos.Response.Token;

namespace Application.Interfaces.Services;

public interface IUserLogInService
{
    Task<Result<TokenResponse>> LogIn(UserLogInDto login);
}