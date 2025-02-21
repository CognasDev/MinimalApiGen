using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.Pagination;
using MinimalApiGen.Framework.Swagger;
using MinimalApiGen.Framework.Versioning;

namespace MinimalApiGen.Framework.Extensions;

/// <summary>
/// 
/// </summary>
public static class ServiceCollectionExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMinimalApiFramework(this WebApplicationBuilder builder)
    {
        IServiceCollection serviceCollection = builder.Services;
        serviceCollection.AddVersioning();
        serviceCollection.ConfigureOptions<ConfigureSwaggerGenOptions>();
        serviceCollection.ConfigureSwaggerGen();
        serviceCollection.AddSingleton<IPaginationService, PaginationService>();
        serviceCollection.AddOutputCache();
    }

    #endregion
}