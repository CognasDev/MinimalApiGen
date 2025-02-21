using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared;

/// <summary>
/// 
/// </summary>
internal static class SymbolExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeSymbol"></param>
    /// <returns></returns>
    public static IEnumerable<ISymbol> GetAllMembers(this ITypeSymbol? typeSymbol)
    {
        HashSet<ISymbol> allMembers = new(SymbolEqualityComparer.Default);

        while (typeSymbol is not null)
        {
            foreach (ISymbol member in typeSymbol.GetMembers())
            {
                if (allMembers.Add(member))
                {
                    yield return member;
                }
            }
            typeSymbol = typeSymbol.BaseType;
        }
    }

    #endregion
}