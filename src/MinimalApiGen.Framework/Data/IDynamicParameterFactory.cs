using Dapper;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public interface IDynamicParameterFactory
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    DynamicParameters? Create(IReadOnlyList<IParameter> parameters);

    #endregion
}