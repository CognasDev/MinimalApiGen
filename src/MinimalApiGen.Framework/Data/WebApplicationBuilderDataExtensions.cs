using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.Pluralize;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public static class WebApplicationBuilderDataExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMinimalApiFrameworkData(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
        builder.Services.AddSingleton<IDatabaseTransactionService, DatabaseTransactionService>();
        builder.Services.AddSingleton<IDynamicParameterFactory, DynamicParameterFactory>();
        builder.Services.AddSingleton<IIdsParameterFactory, IdsParameterFactory>();
        builder.Services.AddSingleton<IQueryDatabaseService, QueryDatabaseService>();
        builder.Services.AddSingleton<IPluralizer, Pluralizer>();
    }

    #endregion
}