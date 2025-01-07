using MinimalApiGen.Generators.Abstractions.Query.Get;
using MinimalApiGen.Generators.Abstractions.Query.GetById;

namespace MinimalApiGen.Generators.Abstractions.Query;

/// <summary>
/// 
/// </summary>
public interface IQueryOperations
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithGetOperation WithGet();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithGetByIdOperation WithGetById();

    #endregion
}