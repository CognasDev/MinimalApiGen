namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IGetAddEndpointFilter
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEndpointFilter"></typeparam>
    /// <returns></returns>
    IWithGetWithAddEndpointFilter WithAddEndpointFilter<TEndpointFilter>();

    #endregion
}