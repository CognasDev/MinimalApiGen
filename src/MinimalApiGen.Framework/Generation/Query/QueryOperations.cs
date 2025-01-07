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
    public IWithGetOperation WithGet() => new WithGetOperation();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetByIdOperation WithGetById() => new WithGetByIdOperation();

    #endregion
}