namespace MinimalApiGen.Generators.Abstractions.Command.Delete;

/// <summary>
/// 
/// </summary>
public interface IDeleteAddEndpointFilter
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEndpointFilter"></typeparam>
    /// <returns></returns>
    IWithDeleteWithAddEndpointFilter WithAddEndpointFilter<TEndpointFilter>();

    #endregion
}