using MinimalApiGen.Framework.Generation.Query.Get;
using MinimalApiGen.Framework.Generation.Query.GetById;
using MinimalApiGen.Generators.Abstractions.Query;
using MinimalApiGen.Generators.Abstractions.Query.Get;
using MinimalApiGen.Generators.Abstractions.Query.GetById;

namespace MinimalApiGen.Framework.Generation.Query;

/// <summary>
/// 
/// </summary>
public sealed class QueryOperations : IQueryOperations
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGet WithGet() => new WithGet();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetById WithGetById() => new WithGetById();

    #endregion
}