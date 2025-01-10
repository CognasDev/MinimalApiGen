using Microsoft.CodeAnalysis;

namespace MinimalApiGen.Generators.Generation.Shared.FluentHandlers;

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