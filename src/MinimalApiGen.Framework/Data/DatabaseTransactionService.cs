using MinimalApiGen.Framework.Collections;
using System.Transactions;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public sealed class DatabaseTransactionService : IDatabaseTransactionService
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="asyncDatabaseTasks"></param>
    /// <returns></returns>
    public async Task ExecuteTransactionAsync(params Func<Task>[] asyncDatabaseTasks)
    {
        using TransactionScope transactionScope = CreateTransactionScope();
        await asyncDatabaseTasks.FastForEachAsync(asyncDatabaseTask => asyncDatabaseTask()).ConfigureAwait(false);
        transactionScope.Complete();
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static TransactionScope CreateTransactionScope()
    {
        TransactionOptions transactionOptions = new()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TransactionManager.MaximumTimeout
        };
        return new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
    }

    #endregion
}