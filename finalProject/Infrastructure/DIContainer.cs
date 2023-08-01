using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DIContainer
{
    public static IServiceCollection InfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        //DbContext
        var connectionString = configuration.GetConnectionString("Mssql");
        services.AddDbContext<SipayDbContext>(opt => opt.UseSqlServer(connectionString));


        //Identity
        services.AddIdentityCore<SipayDbContext>(opt => 
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 8;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddEntityFrameworkStores<SipayDbContext>();



        //Token generation
    

        
        

        
        return services;
    }
}