namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public interface IDatabaseTransactionService
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="databaseTasks"></param>
    /// <returns></returns>
    Task ExecuteTransactionAsync(params Func<Task>[] databaseTasks);

    #endregion
}