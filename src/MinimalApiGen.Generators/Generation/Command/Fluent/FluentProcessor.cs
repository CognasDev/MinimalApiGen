using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.FluentHandlers;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Fluent;
using MinimalApiGen.Generators.Generation.Shared.FluentHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        ConstructorDeclarationSyntax constructor = GetConstructor(context);
        ReadOnlySpan<StatementSyntax> statements = constructor.Body!.Statements.ToArray();
        SemanticModel semanticModel = context.SemanticModel;
        List<CommandIntermediateResult> intermediateResults = [];

        foreach (StatementSyntax statement in statements)
        {
            ImmutableArray<InvocationInfo> CommandInvocations = GetCommandInvocations(statement, semanticModel);
            if (CommandInvocations.Length > 0)
            {
                InvocationResult invocationResult = CommandInvocations.ToInvocationResult();
                ReadOnlySpan<FluentMethodInfo> fluentMethods = CommandInvocations.ToFluentMethodInfos();

                CommandIntermediateResult? intermediateResult = null;
                string commandNamespace = string.Empty;

                foreach (FluentMethodInfo fluentMethod in fluentMethods)
                {
                    InvocationInfo invocationInfo = fluentMethod.Invocation;
                    switch (fluentMethod.FullyQualifiedName)
                    {
                        case string name when name == FullyQualifiedMethodNames.WithNamespace:
                            commandNamespace = invocationInfo.ToNamespace(semanticModel);
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithNamespaceOf:
                            commandNamespace = invocationInfo.ToNamespace();
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithPostBusinessLogic && fluentMethod.IsGeneric:
                            intermediateResult!.BusinessLogicResult = invocationInfo.ToBusinessLogic();
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithPost:
                            intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, commandNamespace);
                            intermediateResult = invocationResult.InitialiseCommandIntermediateResult(CommandType.Post);
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithPostServices && fluentMethod.IsGeneric:
                            IReadOnlyList<string> services = invocationInfo.ToServices();
                            intermediateResult!.Services.AddRange(services);
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithPostKeyedServices && fluentMethod.IsGeneric:
                            Dictionary<string, string> keyedServices = invocationInfo.ToKeyedServices(semanticModel);
                            intermediateResult!.KeyedServices.AddRange(keyedServices);
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithPostRequest && fluentMethod.IsGeneric:
                            intermediateResult!.RequestResult = invocationInfo.ToRequest();
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithPostResponse && fluentMethod.IsGeneric:
                            intermediateResult!.ResponseResult = invocationInfo.ToResponse();
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithRequestMappingService:
                            intermediateResult!.WithRequestMappingService = true;
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithResponseMappingService:
                            intermediateResult!.WithResponseMappingService = true;
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithVersion:
                            int version = invocationInfo.ToVersion(semanticModel);
                            intermediateResult!.Version = version;
                            break;
                    }
                }

                intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, commandNamespace);
            }
        }

        return BuildCommandResults(intermediateResults);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="statement"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    private static ImmutableArray<InvocationInfo> GetCommandInvocations(StatementSyntax statement, SemanticModel semanticModel)
    {
        IReadOnlyList<InvocationExpressionSyntax> expressions = statement.DescendantNodes().OfType<InvocationExpressionSyntax>().ToList();
        bool hasCommand = expressions.Any(expression => expression.GetMethodSymbol(semanticModel)?.ConstructedFrom?.ToDisplayString() == FullyQualifiedMethodNames.Command);

        return hasCommand ?
               expressions.Select(invocationExpressionSyntax => invocationExpressionSyntax.ToInvocationInfo(semanticModel))
                          .Reverse()
                          .ToImmutableArray()
              : [];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandIntermediateResults"></param>
    /// <returns></returns>
    private static EquatableArray<CommandResult> BuildCommandResults(List<CommandIntermediateResult> commandIntermediateResults)
    {
        List<CommandResult> commandResultsBuilder = [];
        ReadOnlySpan<CommandIntermediateResult> span = [.. commandIntermediateResults];
        foreach (CommandIntermediateResult intermediateResult in span)
        {
            CommandResult commandResult = new(intermediateResult);
            commandResultsBuilder.Add(commandResult);
        }
        return new(commandResultsBuilder);
    }

    #endregion
}