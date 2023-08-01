using Application.Dtos.Request.Users;
using Application.Dtos.Response.Common;

namespace Application.Interfaces.Services;

public interface IUserSignUpService
{
    Task<Result<UserSignUpDto>> SignUp(UserSignUpDto signup);
}