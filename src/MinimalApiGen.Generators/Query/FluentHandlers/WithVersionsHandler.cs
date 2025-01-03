using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Query.Invocation;

namespace MinimalApiGen.Generators.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithVersionsHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    public static int ToVersion(this InvocationInfo fluentInvocation, SemanticModel semanticModel) =>
        fluentInvocation.GetSingleArgumentValue<int>(semanticModel);

    #endregion
}