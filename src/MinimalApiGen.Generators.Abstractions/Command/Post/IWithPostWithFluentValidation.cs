using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IWithPostWithFluentValidation : IRequestMappingService, IResponseMappingService, IPostResponse, IVersion
{
}