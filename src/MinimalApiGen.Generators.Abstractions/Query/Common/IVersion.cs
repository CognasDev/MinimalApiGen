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
    IQueryOperations WithVersion(int version);

    #endregion
}