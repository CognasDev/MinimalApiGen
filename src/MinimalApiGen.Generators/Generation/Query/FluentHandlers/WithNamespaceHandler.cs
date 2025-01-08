using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Common;

namespace MinimalApiGen.Generators.Generation.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithNamespaceHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    public static string ToNamespace(this InvocationInfo fluentInvocation, SemanticModel semanticModel) =>
        fluentInvocation.GetSingleArgumentValue<string>(semanticModel);

    #endregion
}