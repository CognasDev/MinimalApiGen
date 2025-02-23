using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Generators.Abstractions.Command.Put;

/// <summary>
/// 
/// </summary>
public interface IWithPutWithFluentValidation : IRequestMappingService, IResponseMappingService, IPutResponse, IVersion
{
}