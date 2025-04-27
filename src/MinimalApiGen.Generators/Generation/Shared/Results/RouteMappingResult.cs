namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
/// <param name="Namespace"></param>
/// <param name="ClassName"></param>
/// <param name="Version"></param>
/// <param name="OperationType"></param>
internal readonly record struct RouteMappingResult(string Namespace, string ClassName, int Version, OperationType OperationType);