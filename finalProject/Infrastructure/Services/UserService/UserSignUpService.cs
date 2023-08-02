using Application.Dtos.Request.Users;
using Application.Dtos.Response.Common;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.UserService;

public class UserSignUpService : IUserSignUpService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserSignUpService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<Result<UserSignUpDto>> SignUp(UserSignUpDto signup)
    {
        var user = await _userManager.FindByEmailAsync(signup.Email);
        if (user is not null)
        {
            throw new ApplicationException($"Unable to find user with email");
        }

        var newUser = new User
        {
            FirstName = signup.FirstName,
            LastName = signup.LastName,
            UserName = signup.UserName,
            Email = signup.Email,
            PhoneNumber = signup.Phone,
            IdNo = signup.IdNo,
            PasswordHash = signup.Password,
        };

        var isCreated = await _userManager.CreateAsync(newUser, signup.Password);
        //await _userManager.AddToRoleAsync(newUser, "user");

        if (!isCreated.Succeeded)
        {
            var errors = isCreated.Errors.Select(e => e.Description).FirstOrDefault();
            throw new ApplicationException($"User couldnt be added! {errors}");
        }

        var mappedUser = _mapper.Map<UserSignUpDto>(newUser);

        return Result.Success(mappedUser, "User is created!");
    }
}