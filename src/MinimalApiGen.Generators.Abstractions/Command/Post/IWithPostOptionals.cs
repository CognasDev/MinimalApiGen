namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IWithPostOptionals : IPostJwtAuthentication, IPostServices, IPostKeyedServices, IPostRequest, IPostResponse
{
}