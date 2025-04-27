namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IPostAddEndpointFilter
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEndpointFilter"></typeparam>
    /// <returns></returns>
    IWithPostWithAddEndpointFilter WithAddEndpointFilter<TEndpointFilter>();

    #endregion
}