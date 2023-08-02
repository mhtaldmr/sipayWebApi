using Application.Dtos.Request.Users;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class UserController : ControllerBase
 {
    private readonly IUserSignUpService _signUpService;
    private readonly IUserLogInService _logInService;


    public UserController(IUserSignUpService signUpService, IUserLogInService logInService)
    {
        _signUpService = signUpService;
        _logInService = logInService;
    }


    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody]UserSignUpDto signup)
    {
        return Ok(await _signUpService.SignUp(signup));
    }

    [HttpPost("login")]
    public async Task<IActionResult> LogIn([FromBody]UserLogInDto login)
    {
        return Ok(await _logInService.LogIn(login));
    }

 }