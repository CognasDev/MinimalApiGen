using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Common;

namespace MinimalApiGen.Generators.Generation.Query.FluentHandlers;

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