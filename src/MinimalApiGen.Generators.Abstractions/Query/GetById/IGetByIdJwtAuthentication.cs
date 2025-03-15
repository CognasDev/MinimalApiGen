namespace MinimalApiGen.Generators.Abstractions.Query.GetById;

/// <summary>
/// 
/// </summary>
public interface IGetByIdJwtAuthentication
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    IWithGetByIdWithJwtAuthentication WithJwtAuthentication(string role = "");

    #endregion
}