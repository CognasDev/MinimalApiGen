namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
/// <param name="ClassNamespace"></param>
/// <param name="ClassName"></param>
/// <param name="Version"></param>
/// <param name="OperationType"></param>
internal readonly record struct RouteMappingResult(string ClassNamespace, string ClassName, int Version, OperationType OperationType);