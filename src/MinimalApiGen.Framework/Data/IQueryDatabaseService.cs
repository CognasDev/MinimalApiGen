namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public interface IQueryDatabaseService
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<IEnumerable<TModel>> SelectModelsAsync<TModel>(string storedProcedure, params IParameter[] parameters);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="ids"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<IEnumerable<TModel>> SelectModelsByIdsAsync<TModel>(string storedProcedure, IEnumerable<int> ids, params IParameter[] parameters);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<TModel?> SelectModelAsync<TModel>(string storedProcedure, params IParameter[] parameters);

    #endregion
}