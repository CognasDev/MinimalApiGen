using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IWithPostWithRequest : IRequestMappingService, IResponseMappingService, IPostResponse, IVersion
{
}