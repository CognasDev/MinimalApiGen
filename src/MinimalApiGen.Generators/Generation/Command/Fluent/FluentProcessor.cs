using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.Results;
using System;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Command.Fluent;

/// <summary>
/// 
/// </summary>
internal static class FluentProcessor
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static EquatableArray<CommandResult> GetCommandResults(GeneratorAttributeSyntaxContext context)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private static ConstructorDeclarationSyntax GetConstructor(GeneratorAttributeSyntaxContext context)
    {
        ClassDeclarationSyntax classDeclarationSyntax = (ClassDeclarationSyntax)context.TargetNode;
        return classDeclarationSyntax.Members.OfType<ConstructorDeclarationSyntax>().Single();
    }

    #endregion
}