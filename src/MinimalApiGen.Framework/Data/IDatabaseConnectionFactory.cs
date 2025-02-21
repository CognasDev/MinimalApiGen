using System.Data;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public interface IDatabaseConnectionFactory
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IDbConnection Create();

    #endregion
}