namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
/// <param name="PropertyName"></param>
/// <param name="PropertyType"></param>
/// <param name="IsNullable"></param>
internal readonly record struct ModelIdPropertyResult(string PropertyName, string PropertyType, bool IsNullable);