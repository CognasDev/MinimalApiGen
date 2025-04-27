namespace MinimalApiGen.Generators.Abstractions.Query.GetById;

/// <summary>
/// 
/// </summary>
public interface IGetByIdAddEndpointFilter
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEndpointFilter"></typeparam>
    /// <returns></returns>
    IWithGetByIdWithAddEndpointFilter WithAddEndpointFilter<TEndpointFilter>();

    #endregion
}