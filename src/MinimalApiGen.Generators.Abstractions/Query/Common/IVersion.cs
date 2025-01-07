using MinimalApiGen.Generators.Abstractions.Query.Get;

namespace MinimalApiGen.Generators.Abstractions.Query.Common;

/// <summary>
/// 
/// </summary>
public interface IVersion
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    IWithGetWithVersion WithVersion(int version);

    #endregion
}