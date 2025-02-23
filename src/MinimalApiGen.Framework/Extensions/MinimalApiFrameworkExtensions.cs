using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.ExceptionHandling;
using MinimalApiGen.Framework.HealthChecks;
using MinimalApiGen.Framework.Services;
using MinimalApiGen.Framework.Swagger;
using MinimalApiGen.Framework.Versioning;
using System.Diagnostics;

namespace MinimalApiGen.Framework.Extensions;

/// <summary>
/// 
/// </summary>
public static class MinimalApiFrameworkExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMinimalApiFramework(this WebApplicationBuilder builder)
    {
        IServiceCollection serviceCollection = builder.Services;
        serviceCollection.AddPagination(); //needs to be ahead of AddExceptionHandlers

        serviceCollection.AddDefaultHealthChecks();
        serviceCollection.AddExceptionHandlers();
        serviceCollection.AddHttpClientServices();
        serviceCollection.AddOutputCache();
        serviceCollection.AddVersioning();

        serviceCollection.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                context.ProblemDetails.Extensions.TryAdd("traceId", context.HttpContext.TraceIdentifier);
                Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                context.ProblemDetails.Extensions.TryAdd("activityId", activity?.Id);
            };
        });

        serviceCollection.ConfigureOptions<ConfigureSwaggerGenOptions>();
        serviceCollection.ConfigureSwaggerGen();
    }

    #endregion
}