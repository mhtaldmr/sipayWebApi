using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dtos.Response.Token;
using Application.Interfaces.Services.TokenService;
using Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.TokenService;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponse GetToken(User user, IList<string> roles)
    {
        var token = new TokenResponse();
        token.Expiration = DateTime.Now.AddMinutes(15);

        var claims = new List<Claim>
        {
            new Claim("id", user.Id),
            new Claim(ClaimTypes.Name,user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        //Add role as multiple claims
        foreach(var role in roles)
        {
            if (role is not null)
                claims.Add(new  Claim(ClaimTypes.Role,role.ToString()));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        var signingCrendentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
                signingCredentials: signingCrendentials,
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(1),
                claims: claims
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        string accessToken = tokenHandler.WriteToken(securityToken);
        token.AccessToken = accessToken;
        token.RefreshToken = Guid.NewGuid().ToString();


        return token;
    }
}