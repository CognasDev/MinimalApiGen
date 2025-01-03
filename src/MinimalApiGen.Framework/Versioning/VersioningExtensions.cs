using Asp.Versioning;
using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiGen.Framework.Versioning;

/// <summary>
/// 
/// </summary>
public static class VersioningExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="defaultApiVersion"></param>
    public static IApiVersioningBuilder AddVersioning(this IServiceCollection serviceCollection, int defaultApiVersion = 1)
    {
        return serviceCollection.AddApiVersioning(apiVersioningAction =>
        {
            const string xApiVersion = "x-api-version";
            apiVersioningAction.DefaultApiVersion = new ApiVersion(defaultApiVersion);
            apiVersioningAction.AssumeDefaultVersionWhenUnspecified = true;
            apiVersioningAction.ReportApiVersions = true;
            apiVersioningAction.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                            new HeaderApiVersionReader(xApiVersion),
                                                                            new MediaTypeApiVersionReader(xApiVersion));
        })
        .AddApiExplorer(apiExplorerOptions =>
        {
            apiExplorerOptions.GroupNameFormat = "'v'V";
            apiExplorerOptions.SubstituteApiVersionInUrl = true;
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    /// <param name="majorVersion"></param>
    /// <returns></returns>
    public static RouteGroupBuilder GetApiVersionRoute(this WebApplication webApplication, int majorVersion)
    {
        ApiVersionSet apiVersionSet = webApplication.NewApiVersionSet().HasApiVersion(majorVersion).ReportApiVersions().Build();
        return webApplication.MapGroup("api/v{version:apiVersion}").WithApiVersionSet(apiVersionSet);
    }

    #endregion
}