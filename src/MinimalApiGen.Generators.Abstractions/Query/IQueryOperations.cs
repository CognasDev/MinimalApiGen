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
    IWithGet WithGet();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithGetById WithGetById();

    #endregion
}