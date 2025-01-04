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
    /// <param name="services"></param>
    public static void AddMinimalApiGenFramework(this IServiceCollection services)
    {
        services.AddVersioning();
        services.ConfigureOptions<ConfigureSwaggerGenOptions>();
        services.ConfigureSwaggerGen();
        services.AddSingleton<IPaginationService, PaginationService>();
        services.AddOutputCache();
    }

    #endregion
}