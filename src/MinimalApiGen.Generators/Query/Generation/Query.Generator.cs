using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Query.Fluent;
using MinimalApiGen.Generators.Query.Generation;
using MinimalApiGen.Generators.Query.Results;
using System.Collections.Immutable;
using System.Linq;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Query;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Generates Query API code based on provided scaffolding attributes.
/// </summary>
[Generator]
public sealed class Generator : IIncrementalGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public Generator()
    {
        //#if DEBUG
        //        if (!System.Diagnostics.Debugger.IsAttached)
        //        {
        //            System.Diagnostics.Debugger.Launch();
        //        }
        //#endif
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<ImmutableArray<QueryResult>> queryResultsValueProvider = context.SyntaxProvider.ForAttributeWithMetadataName
        (
            "MinimalApiGen.Framework.Generation.QueryGeneratorAttribute",
            predicate: static (syntaxNode, _) => syntaxNode is ClassDeclarationSyntax,
            transform: static (context, _) => FluentProcessor.GetQueryResults(context)
        ).SelectMany(static (results, _) => results).Collect();
        context.RegisterSourceOutput(queryResultsValueProvider, static (context, queryResults) => SourceOutputExecutor.Execute(context, queryResults));
    }

    #endregion
}