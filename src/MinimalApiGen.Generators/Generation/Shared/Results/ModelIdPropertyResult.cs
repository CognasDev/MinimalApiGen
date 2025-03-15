namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
/// <param name="PropertyName"></param>
/// <param name="PropertyType"></param>
/// <param name="UnderlyingType"></param>
internal readonly record struct ModelIdPropertyResult(string PropertyName, string PropertyType, string? UnderlyingType);