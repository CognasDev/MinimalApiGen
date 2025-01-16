namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
/// <param name="ClassNamespace"></param>
/// <param name="ClassName"></param>
/// <param name="Version"></param>
/// <param name="CommandType"></param>
internal readonly record struct CommandRouteMappingResult(string ClassNamespace, string ClassName, int Version, CommandType CommandType);