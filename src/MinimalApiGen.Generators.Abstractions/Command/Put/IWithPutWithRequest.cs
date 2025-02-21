using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Generators.Abstractions.Command.Put;

/// <summary>
/// 
/// </summary>
public interface IWithPutWithRequest : IRequestMappingService, IResponseMappingService, IPutResponse, IVersion
{
}