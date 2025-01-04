using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Generators.Abstractions.Common;

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
    IQueryWithVersion WithVersion(int version);

    #endregion
}