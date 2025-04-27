using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Generators.Abstractions.Command.Delete;

/// <summary>
/// 
/// </summary>
public interface IWithDeleteWithAddEndpointFilter : IDeleteServices, IDeleteKeyedServices, IDeleteRequest, IVersion
{
}