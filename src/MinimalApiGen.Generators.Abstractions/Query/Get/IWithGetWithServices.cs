using MinimalApiGen.Generators.Abstractions.Query.Common;

namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IWithGetWithServices : ICache, IGetKeyedServices, IGetResponse
{
}