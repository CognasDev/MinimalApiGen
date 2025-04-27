namespace MinimalApiGen.Generators.Abstractions.Command.Put;

/// <summary>
/// 
/// </summary>
public interface IWithPutWithJwtAuthentication : IPutServices, IPutKeyedServices, IPutRequest, IPutResponse, IPutAddEndpointFilter
{
}