using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Command;
using MinimalApiGen.Generators.Generation.Command.Fluent;
using MinimalApiGen.Generators.Generation.Command.Results;
using System.Collections.Immutable;
using System.Linq;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Command;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Generates Command API code based on provided scaffolding attributes.
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
        IncrementalValueProvider<ImmutableArray<CommandResult>> CommandResultsValueProvider = context.SyntaxProvider.ForAttributeWithMetadataName
        (
            "MinimalApiGen.Framework.Generation.CommandGeneratorAttribute",
            predicate: static (syntaxNode, _) => syntaxNode is ClassDeclarationSyntax,
            transform: static (context, _) => FluentProcessor.GetCommandResults(context)
        )
        .WithTrackingName(TrackingNames.GetCommandResults)
        .SelectMany(static (results, _) => results)
        .WithTrackingName(TrackingNames.SelectMany)
        .Collect()
        .WithTrackingName(TrackingNames.CollectToValueProvider);

        // context.RegisterSourceOutput(CommandResultsValueProvider, static (context, CommandResults) => SourceOutputExecutor.Execute(context, CommandResults));
    }

    #endregion
}