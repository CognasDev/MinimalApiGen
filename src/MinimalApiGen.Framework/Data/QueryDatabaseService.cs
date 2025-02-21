using Dapper;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
[ExcludeFromCodeCoverage(Justification = "Mainly uses Dapper (https://github.com/DapperLib/Dapper) which itself has unit-tests.")]
public sealed class QueryDatabaseService : IQueryDatabaseService
{
    #region Field Declarations

    private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
    private readonly IDynamicParameterFactory _dynamicParameterFactory;
    private readonly IIdsParameterFactory _idsParameterFactory;

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="QueryDatabaseService"/>
    /// </summary>
    /// <param name="databaseConnectionFactory"></param>
    /// <param name="dynamicParameterFactory"></param>
    /// <param name="idsParameterFactory"></param>
    public QueryDatabaseService(IDatabaseConnectionFactory databaseConnectionFactory,
                                IDynamicParameterFactory dynamicParameterFactory,
                                IIdsParameterFactory idsParameterFactory)
    {
        ArgumentNullException.ThrowIfNull(databaseConnectionFactory, nameof(databaseConnectionFactory));
        ArgumentNullException.ThrowIfNull(dynamicParameterFactory, nameof(dynamicParameterFactory));
        ArgumentNullException.ThrowIfNull(idsParameterFactory, nameof(idsParameterFactory));

        _databaseConnectionFactory = databaseConnectionFactory;
        _dynamicParameterFactory = dynamicParameterFactory;
        _idsParameterFactory = idsParameterFactory;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TModel>> SelectModelsAsync<TModel>(string storedProcedure, params IParameter[] parameters)
    {
        DynamicParameters? dynamicParameters = _dynamicParameterFactory.Create(parameters);
        using IDbConnection dbConnection = _databaseConnectionFactory.Create();
        return await dbConnection.QueryAsync<TModel>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="ids"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TModel>> SelectModelsByIdsAsync<TModel>(string storedProcedure,
                                                                          IEnumerable<int> ids,
                                                                          params IParameter[] parameters)
    {
        IParameter parameter = _idsParameterFactory.Create(ids);
        List<IParameter> parameterList = [parameter];
        parameterList.AddRange(parameters);
        DynamicParameters? dynamicParameters = _dynamicParameterFactory.Create(parameterList);
        using IDbConnection dbConnection = _databaseConnectionFactory.Create();
        return await dbConnection.QueryAsync<TModel>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<TModel?> SelectModelAsync<TModel>(string storedProcedure, params IParameter[] parameters)
    {
        DynamicParameters? dynamicParameters = _dynamicParameterFactory.Create(parameters);
        using IDbConnection dbConnection = _databaseConnectionFactory.Create();
        return await dbConnection.QuerySingleOrDefaultAsync<TModel>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    #endregion
}