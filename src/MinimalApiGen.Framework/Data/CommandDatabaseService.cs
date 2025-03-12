using Dapper;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
[ExcludeFromCodeCoverage(Justification = "Mainly uses Dapper (https://github.com/DapperLib/Dapper) which itself has unit-tests.")]
public sealed class CommandDatabaseService : ICommandDatabaseService
{
    #region Field Declarations

    private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
    private readonly IDynamicParameterFactory _dynamicParameterFactory;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="CommandDatabaseService"/>
    /// </summary>
    /// <param name="databaseConnectionFactory"></param>
    /// <param name="dynamicParameterFactory"></param>
    public CommandDatabaseService(IDatabaseConnectionFactory databaseConnectionFactory, IDynamicParameterFactory dynamicParameterFactory)
    {
        ArgumentNullException.ThrowIfNull(databaseConnectionFactory, nameof(databaseConnectionFactory));
        ArgumentNullException.ThrowIfNull(dynamicParameterFactory, nameof(dynamicParameterFactory));
        _databaseConnectionFactory = databaseConnectionFactory;
        _dynamicParameterFactory = dynamicParameterFactory;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<TModel?> InsertModelAsync<TModel>(string storedProcedure, TModel model)
    {
        using IDbConnection dbConnection = _databaseConnectionFactory.Create();
        TModel? insertedModel = await dbConnection.QuerySingleOrDefaultAsync<TModel>(storedProcedure, model, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        return insertedModel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<TModel?> UpdateModelAsync<TModel>(string storedProcedure, TModel model)
    {
        using IDbConnection dbConnection = _databaseConnectionFactory.Create();
        TModel? updatedModel = await dbConnection.QuerySingleOrDefaultAsync<TModel>(storedProcedure, model, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        return updatedModel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<int> DeleteModelAsync(string storedProcedure, params IParameter[] parameters)
    {
        DynamicParameters? dynamicParameters = _dynamicParameterFactory.Create(parameters);
        using IDbConnection dbConnection = _databaseConnectionFactory.Create();
        int deleteCount = await dbConnection.ExecuteScalarAsync<int>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        return deleteCount;
    }

    #endregion
}