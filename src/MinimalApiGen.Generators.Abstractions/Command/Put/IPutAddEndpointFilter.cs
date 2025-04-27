namespace MinimalApiGen.Generators.Abstractions.Command.Put;

/// <summary>
/// 
/// </summary>
public interface IPutAddEndpointFilter
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEndpointFilter"></typeparam>
    /// <returns></returns>
    IWithPutWithAddEndpointFilter WithAddEndpointFilter<TEndpointFilter>();

    #endregion
}