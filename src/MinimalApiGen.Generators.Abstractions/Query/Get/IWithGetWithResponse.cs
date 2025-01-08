using MinimalApiGen.Generators.Abstractions.Query.Shared;

namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IWithGetWithResponse : ICache, IMappingService, IVersion
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithGetPaginationService WithPagination();

    #endregion
}