using MinimalApiGen.Generators.Abstractions.Get;

namespace MinimalApiGen.Generators.Abstractions.Common;

/// <summary>
/// 
/// </summary>
public interface IPagination
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithGetWithPagination WithPagination();

    #endregion
}