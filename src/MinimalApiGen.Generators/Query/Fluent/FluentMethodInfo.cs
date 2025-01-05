using MinimalApiGen.Generators.Query.Invocation;

namespace MinimalApiGen.Generators.Query.Fluent;

/// <summary>
/// 
/// </summary>
/// <param name="FullyQualifiedName"></param>
/// <param name="Invocation"></param>
/// <param name="IsGeneric"></param>
internal readonly record struct FluentMethodInfo(string FullyQualifiedName, InvocationInfo Invocation, bool IsGeneric);