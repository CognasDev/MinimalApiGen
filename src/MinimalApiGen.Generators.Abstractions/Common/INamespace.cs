using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Generators.Abstractions.Common;

/// <summary>
/// 
/// </summary>
public interface INamespace
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryNamespace"></param>
    /// <returns></returns>
    IQuery WithNamespace(string queryNamespace);

    #endregion
}