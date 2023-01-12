using AsanPardakhtTest.Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AsanPardakhtTest.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddControllers()
             .AddFluentValidation(mvcConfiguration =>
             {
                 mvcConfiguration.RegisterValidatorsFromAssemblyContaining<IApplicationDbContext>();
             });

        #region Swagger

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AsanPardakhtTest API"
            });
        });

        #endregion Swagger

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        return services;
    }
}