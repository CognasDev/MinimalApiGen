namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class AddMinimalApiFrameworkBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hasCommandResults"></param>
    /// <param name="hasQueryResults"></param>
    /// <param name="withJwtAuthentication"></param>
    /// <param name="withPagination"></param>
    /// <param name="withCaching"></param>
    /// <param name="withMappingServices"></param>
    /// <returns></returns>
    public static string Build(bool hasCommandResults, bool hasQueryResults, bool withJwtAuthentication, bool withPagination, bool withCaching, bool withMappingServices) =>
@$"using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.ExceptionHandling;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.HealthChecks;
using MinimalApiGen.Framework.Services;
using MinimalApiGen.Framework.Swagger;
using MinimalApiGen.Framework.Versioning;
using System.Diagnostics;

namespace MinimalApiGen.Framework.Extensions;

/// <summary>
/// 
/// </summary>
public static class AddMinimalApiFrameworkExtensions
{{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""builder""></param>
    public static void AddMinimalApiFramework(this WebApplicationBuilder builder)
    {{
        IServiceCollection serviceCollection = builder.Services;

        {AddPagination(withPagination)}
        {AddCaching(withCaching)}
        {AddAuthorization(withJwtAuthentication)}
        {AddMappingServices(withMappingServices)}

        serviceCollection.AddDefaultHealthChecks();
        serviceCollection.AddExceptionHandlers();
        serviceCollection.AddHttpClientServices();
        serviceCollection.AddVersioning();

        //Data
        serviceCollection.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
        serviceCollection.AddSingleton<IDatabaseTransactionService, DatabaseTransactionService>();
        serviceCollection.AddSingleton<IDynamicParameterFactory, DynamicParameterFactory>();
        serviceCollection.AddSingleton<IIdsParameterFactory, IdsParameterFactory>();
        {AddCommandDatabaseService(hasCommandResults)}
        {AddQueryDatabaseService(hasQueryResults)}

        serviceCollection.AddProblemDetails(options =>
        {{
            options.CustomizeProblemDetails = context =>
            {{
                context.ProblemDetails.Instance = $""{{context.HttpContext.Request.Method}} {{context.HttpContext.Request.Path}}"";
                context.ProblemDetails.Extensions.TryAdd(""traceId"", context.HttpContext.TraceIdentifier);
                Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                context.ProblemDetails.Extensions.TryAdd(""activityId"", activity?.Id);
            }};
        }});

        serviceCollection.ConfigureOptions<ConfigureSwaggerGenOptions>();
        serviceCollection.ConfigureSwaggerGen();
    }}

    #endregion
}}";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hasCommandResults"></param>
    /// <returns></returns>
    private static string AddCommandDatabaseService(bool hasCommandResults) => hasCommandResults ? "serviceCollection.AddSingleton<ICommandDatabaseService, CommandDatabaseService>();" : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hasQueryResults"></param>
    /// <returns></returns>
    private static string AddQueryDatabaseService(bool hasQueryResults) => hasQueryResults ? "serviceCollection.AddSingleton<IQueryDatabaseService, QueryDatabaseService>();" : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="withPagination"></param>
    /// <returns></returns>
    private static string AddPagination(bool withPagination) => withPagination ? "serviceCollection.AddPagination(); //needs to be before exception handlers" : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="withCaching"></param>
    /// <returns></returns>
    private static string AddCaching(bool withCaching) => withCaching ? "serviceCollection.AddOutputCache();" : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="withJwtAuthentication"></param>
    /// <returns></returns>
    private static string AddAuthorization(bool withJwtAuthentication) => withJwtAuthentication ? "builder.AddMinimalApiAuthorization();" : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="withMappingServices"></param>
    /// <returns></returns>
    private static string AddMappingServices(bool withMappingServices) => withMappingServices ? "builder.AddMinimalApiFramewokMappingServices();" : string.Empty;

    #endregion
}