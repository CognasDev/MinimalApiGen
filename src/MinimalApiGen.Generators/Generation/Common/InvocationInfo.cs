using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MinimalApiGen.Generators.Generation.Common;

/// <summary>
/// 
/// </summary>
/// <param name="InvocationExpressionSyntax"></param>
/// <param name="MethodSymbol"></param>
internal readonly record struct InvocationInfo(InvocationExpressionSyntax InvocationExpressionSyntax, IMethodSymbol MethodSymbol);