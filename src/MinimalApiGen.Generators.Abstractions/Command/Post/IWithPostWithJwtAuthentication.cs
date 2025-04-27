namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IWithPostWithJwtAuthentication : IPostServices, IPostKeyedServices, IPostRequest, IPostResponse, IPostAddEndpointFilter
{
}