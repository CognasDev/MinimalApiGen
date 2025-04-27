using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Shared.Results;

namespace MinimalApiGen.Generators.Generation.Shared.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithAddEndpointFilterHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <returns></returns>
    public static AddEndpointFilterResult ToEndpointFilter(this InvocationInfo fluentInvocation)
    {
        ITypeSymbol filterTypeSymbol = fluentInvocation.GetSingleGenericArgument();

        AddEndpointFilterResult result = new()
        {
            FilterFullyQualifiedName = filterTypeSymbol.ToDisplayString(),
            FilterName = filterTypeSymbol.Name
        };
        return result;
    }

    #endregion
}