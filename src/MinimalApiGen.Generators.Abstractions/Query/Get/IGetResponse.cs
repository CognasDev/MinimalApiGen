namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IGetResponse
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    IWithGetWithResponse WithResponse<TResponse>();

    #endregion
}