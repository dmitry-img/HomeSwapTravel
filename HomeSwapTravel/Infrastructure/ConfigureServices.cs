using Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Application.Common.Interfaces.Identity;
using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Application.Common.Models;
using HomeSwapTravel.Infrastructure.Identity;
using HomeSwapTravel.Infrastructure.Persistence;
using HomeSwapTravel.Infrastructure.Persistence.Interceptors;
using Infrastructure.Identity;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<UserManager<ApplicationUser>>();
        services.AddScoped<SignInManager<ApplicationUser>>();

        services.AddTransient<IHomeOwnerService, HomeOwnerService>();
        services.AddTransient<IHomeRepository, HomeRepository>();
        services.AddTransient<IRequestRepository, RequestRepository>();
        services.AddTransient<IReviewRepository, ReviewRepository>();
        services.AddTransient<IHomeOwnerVisitedHomeRepository, HomeOwnerVisitedHomeRepository>();
        services.AddTransient<IHomeReviewRepository, HomeReviewRepository>();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });


        return services;
    }
}
