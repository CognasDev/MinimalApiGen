namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public interface IIdsParameterFactory
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="parameterName"></param>
    /// <returns></returns>
    IParameter Create(IEnumerable<int> ids, string parameterName = "Ids");

    #endregion
}