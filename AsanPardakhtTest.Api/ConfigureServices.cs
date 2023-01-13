using AsanPardakhtTest.Api.Filters;
using AsanPardakhtTest.Api.Services;
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

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        //services.AddControllers()
        //     .AddFluentValidation(mvcConfiguration =>
        //     {
        //         mvcConfiguration.RegisterValidatorsFromAssemblyContaining<IApplicationDbContext>();
        //     });

        services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
        .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

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