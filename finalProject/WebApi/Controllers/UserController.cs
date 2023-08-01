using Application.Dtos.Request.Users;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class UserController : ControllerBase
 {
    private readonly UserManager<User> _userManager;

    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }


    [HttpPost("signUp")]
    public async Task<IActionResult> SignUp(UserSignUpDto signUpDto)
    {
        var user = await _userManager.FindByEmailAsync(signUpDto.Email);
        if (user is not null)
        {
            throw new ApplicationException($"Unable to find user with email");
        }

        var newUser = new User()
        {
            UserName = signUpDto.Email,
            PasswordHash = signUpDto.Password
        };


        var isCreated = await _userManager.CreateAsync(newUser, signUpDto.Password);
        //await _userManager.AddToRoleAsync(newUser, "user");

        if (!isCreated.Succeeded)
        {
            var errors = isCreated.Errors.Select(e => e.Description).FirstOrDefault();
            throw new ApplicationException($"User couldnt be added! {errors}");
        }

        return Ok(newUser);
    }






 }