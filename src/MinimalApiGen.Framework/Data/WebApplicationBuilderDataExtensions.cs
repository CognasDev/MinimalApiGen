using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
        builder.Services.AddSingleton<ICommandDatabaseService, CommandDatabaseService>();
        builder.Services.AddSingleton<IQueryDatabaseService, QueryDatabaseService>();
    }

    #endregion
}