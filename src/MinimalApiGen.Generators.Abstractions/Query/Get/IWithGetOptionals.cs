namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IWithGetOptionals : IGetJwtAuthentication, IGetQueryParameters, IGetServices, IGetKeyedServices, IGetResponse
{
}