using System.Text;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.Services.TokenService;
using Domain.Entity;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using Infrastructure.Services.TokenService;
using Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Infrastructure;

public static class DIContainer
{
    public static IServiceCollection InfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        //DbContext
        var connectionString = configuration.GetConnectionString("Mssql");
        services.AddDbContext<SipayDbContext>(opt => opt.UseSqlServer(connectionString));


        //Identity
        services.AddIdentity<User, IdentityRole>(opt => 
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 8;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SipayDbContext>()
            .AddDefaultTokenProviders();



        //Token generation
        TokenValidationParameters tokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = configuration["JWT:Audience"],
            ValidIssuer = configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };

        //JWT Bearer configurations
        services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(opt => opt.TokenValidationParameters = tokenValidationParameters);

        //Adding the authorization for role based.
        services.AddAuthorization();    


        
        //Interface Registirations
        //Identity
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserSignUpService, UserSignUpService>();
        services.AddScoped<IUserLogInService, UserLogInService>();

        //Entities
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();



         //Swagger Authorization
        services.AddSwaggerGen(opt =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            opt.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
        });

        
        return services;
    }
}