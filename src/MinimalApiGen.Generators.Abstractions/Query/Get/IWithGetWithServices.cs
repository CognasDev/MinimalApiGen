using MinimalApiGen.Generators.Abstractions.Query.Shared;

namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IWithGetWithServices : ICache, IGetKeyedServices, IGetResponse
{
}