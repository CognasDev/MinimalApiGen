using MinimalApiGen.Generators.Abstractions.Query;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Query;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public sealed class QueryWithModelId<TModel> : IQueryWithModelId<TModel>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    public IQueryOperations WithModelId(Expression<Func<TModel, object?>> property) => new QueryOperations();

    #endregion
}