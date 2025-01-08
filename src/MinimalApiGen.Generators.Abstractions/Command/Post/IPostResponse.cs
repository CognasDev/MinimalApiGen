namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IPostResponse
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    IWithPostWithResponse WithResponse<TResponse>();

    #endregion
}