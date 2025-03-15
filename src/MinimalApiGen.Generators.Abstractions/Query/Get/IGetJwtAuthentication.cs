namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IGetJwtAuthentication
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    IWithGetWithJwtAuthentication WithJwtAuthentication(string role = "");

    #endregion
}