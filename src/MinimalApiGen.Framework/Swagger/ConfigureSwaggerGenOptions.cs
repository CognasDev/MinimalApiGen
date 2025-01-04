using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace MinimalApiGen.Framework.Swagger;

/// <summary>
/// 
/// </summary>
public sealed class ConfigureSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    #region Field Declaration

    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="apiVersionDescriptionProvider"></param>
    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        ArgumentNullException.ThrowIfNull(apiVersionDescriptionProvider, nameof(apiVersionDescriptionProvider));
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    public void Configure(string? name, SwaggerGenOptions options) => Configure(options);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Configure(SwaggerGenOptions options)
    {
        foreach (ApiVersionDescription apiVersionDescription in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            OpenApiInfo openApiInfo = new()
            {
                Title = Assembly.GetEntryAssembly()!.GetName().Name + (apiVersionDescription.IsDeprecated ? " - depreceated." : string.Empty),
                Version = apiVersionDescription.ApiVersion.ToString()
            };
            options.SwaggerDoc(apiVersionDescription.GroupName, openApiInfo);
        }
    }

    #endregion
}