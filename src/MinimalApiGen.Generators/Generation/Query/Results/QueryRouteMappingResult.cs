using MinimalApiGen.Generators.Generation.Shared;

namespace MinimalApiGen.Generators.Generation.Query.Results;

/// <summary>
/// 
/// </summary>
/// <param name="ClassNamespace"></param>
/// <param name="ClassName"></param>
/// <param name="Version"></param>
/// <param name="OperationType"></param>
internal readonly record struct QueryRouteMappingResult(string ClassNamespace, string ClassName, int Version, OperationType OperationType);