using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Infrastructure.Persistence;
using HomeSwapTravel.WebUI.Services;


namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();



        // Customise default API behaviour
        //services.Configure<ApiBehaviorOptions>(options =>
        //    options.SuppressModelStateInvalidFilter = true);

        //services.AddOpenApiDocument(configure =>
        //{
        //    configure.Title = "HomeSwap API";
        //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //    {
        //        Type = OpenApiSecuritySchemeType.ApiKey,
        //        Name = "Authorization",
        //        In = OpenApiSecurityApiKeyLocation.Header,
        //        Description = "Type into the textbox: Bearer {your JWT token}."
        //    });

        //    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        //});

        return services;
    }
}
