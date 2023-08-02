using Application.Interfaces.Services.TokenService;
using Application.Dtos.Request.Users;
using Application.Dtos.Response.Common;
using Application.Dtos.Response.Token;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Domain.Entity;


namespace Infrastructure.Services.UserService;

public class UserLogInService : IUserLogInService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public UserLogInService(UserManager<User> userManager,SignInManager<User> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }
    
    public async Task<Result<TokenResponse>> LogIn(UserLogInDto login)
    {
        var existingUser = await _userManager.FindByEmailAsync(login.Email);
        if (existingUser is null)
            throw new KeyNotFoundException("User can not be found!");
        if(await _userManager.IsLockedOutAsync(existingUser))
            throw new LockRecursionException("User is locked!");

        var isCorrect = await _userManager.CheckPasswordAsync(existingUser, login.Password);

        if (!isCorrect)
        {
            await AccessRightControl(existingUser);
            throw new ArgumentException("Password is not correct!");
        }

        if (existingUser.AccessFailedCount < 3)
        {
            existingUser.AccessFailedCount = 0;
            await _userManager.UpdateAsync(existingUser);
        }

        await _signInManager.CheckPasswordSignInAsync(existingUser, login.Password,false);
        await _signInManager.SignInAsync(existingUser, false);

        //Get the token
        var roles = await _userManager.GetRolesAsync(existingUser);
        var jwtToken = _tokenService.GetToken(existingUser, roles);

        return Result.Success( jwtToken , "Token is created.");   
    }

    private async Task AccessRightControl(User existingUser)
    {
        existingUser.AccessFailedCount++;
        
        await _userManager.UpdateAsync(existingUser);

        if (existingUser.AccessFailedCount >= 3)
        {
            existingUser.LockoutEnabled = true;
            await _userManager.UpdateAsync(existingUser);
            throw new InvalidOperationException("User blocked");
        }
    }
}