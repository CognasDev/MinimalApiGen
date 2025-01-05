namespace MinimalApiGen.Generators.Query.Results;

/// <summary>
/// 
/// </summary>
/// <param name="ClassNamespace"></param>
/// <param name="ClassName"></param>
/// <param name="Version"></param>
internal readonly record struct EndpointRouteMappingResult(string ClassNamespace, string ClassName, int Version);