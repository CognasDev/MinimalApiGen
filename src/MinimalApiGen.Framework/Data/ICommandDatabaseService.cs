namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public interface ICommandDatabaseService
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<TModel?> InsertModelAsync<TModel>(string storedProcedure, TModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<TModel?> UpdateModelAsync<TModel>(string storedProcedure, TModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<int> DeleteModelAsync(string storedProcedure, params IParameter[] parameters);

    #endregion
}