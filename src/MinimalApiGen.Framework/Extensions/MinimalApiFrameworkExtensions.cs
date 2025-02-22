using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.ExceptionHandling;
using MinimalApiGen.Framework.HealthChecks;
using MinimalApiGen.Framework.Services;
using MinimalApiGen.Framework.Swagger;
using MinimalApiGen.Framework.Versioning;

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
        serviceCollection.AddProblemDetails();
        serviceCollection.AddVersioning();

        serviceCollection.ConfigureOptions<ConfigureSwaggerGenOptions>();
        serviceCollection.ConfigureSwaggerGen();
    }

    #endregion
}