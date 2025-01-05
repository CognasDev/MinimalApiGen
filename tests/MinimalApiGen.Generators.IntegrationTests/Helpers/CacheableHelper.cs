﻿using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using MinimalApiGen.Generators.Query.Generation;
using System.Collections;
using System.Collections.Immutable;
using System.Reflection;
using Generator = global::Query.Generator;

namespace MinimalApiGen.Generators.IntegrationTests.Helpers;

/// <summary>
/// 
/// </summary>
internal static class CacheableHelper
{
    #region Pubic Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sources"></param>
    /// <param name="stages"></param>
    /// <returns></returns>
    public static (ImmutableArray<Diagnostic> Diagnostics, string[] Output) GetGeneratedTrees(string[] sources, string[] stages)
    {
        CSharpCompilation compilation = CreateCompilation(sources);
        GeneratorDriverRunResult runResult = RunGeneratorAndAssertOutput(compilation, stages);
        return (runResult.Diagnostics, runResult.GeneratedTrees.Select(syntaxTree => syntaxTree.ToString()).ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sources"></param>
    /// <returns></returns>
    public static (ImmutableArray<Diagnostic> Diagnostics, string[] Output) GetGeneratedTrees(params string[] sources)
    {
        string[] trackingNames = typeof(TrackingNames)
                                    .GetFields()
                                    .Where(static fieldInfo => fieldInfo.IsLiteral && !fieldInfo.IsInitOnly && fieldInfo.FieldType == typeof(string))
                                    .Select(static fieldInfo => fieldInfo.GetRawConstantValue()?.ToString())
                                    .Where(value => !string.IsNullOrEmpty(value))
                                    .Select(value => value!)
                                    .ToArray();

        return GetGeneratedTrees(sources, trackingNames);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="references"></param>
    /// <returns></returns>
    private static CSharpCompilation CreateCompilation(string[] sources)
    {
        IEnumerable<SyntaxTree> syntaxTrees = sources.Select(static source => CSharpSyntaxTree.ParseText(source));
        IEnumerable<PortableExecutableReference> references = ReferencesHelper.BuildReferences();

        return CSharpCompilation.Create
        (
            "Test",
            syntaxTrees,
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="compilation"></param>
    /// <param name="trackingNames"></param>
    /// <returns></returns>
    private static GeneratorDriverRunResult RunGeneratorAndAssertOutput(CSharpCompilation compilation, string[] trackingNames)
    {
        ISourceGenerator generator = new Generator().AsSourceGenerator();

        GeneratorDriverOptions driverOptions = new(disabledOutputs: IncrementalGeneratorOutputKind.None, trackIncrementalGeneratorSteps: true);
        GeneratorDriver driver = CSharpGeneratorDriver.Create([generator], driverOptions: driverOptions);
        CSharpCompilation clone = compilation.Clone();

        driver = driver.RunGenerators(compilation);

        GeneratorDriverRunResult runResult = driver.GetRunResult();
        GeneratorDriverRunResult runResult2 = driver.RunGenerators(clone).GetRunResult();

        AssertRunsEqual(runResult, runResult2, trackingNames);

        runResult2.Results[0]
                    .TrackedOutputSteps
                    .SelectMany(keyValuePair => keyValuePair.Value) // step executions
                    .SelectMany(runStep => runStep.Outputs) // execution results
                    .Should()
                    .OnlyContain(runStep => runStep.Reason == IncrementalStepRunReason.Cached);

        return runResult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="runResult1"></param>
    /// <param name="runResult2"></param>
    /// <param name="trackingNames"></param>
    private static void AssertRunsEqual(GeneratorDriverRunResult runResult1, GeneratorDriverRunResult runResult2, string[] trackingNames)
    {
        Dictionary<string, ImmutableArray<IncrementalGeneratorRunStep>> trackedSteps1 = GetTrackedSteps(runResult1, trackingNames);
        Dictionary<string, ImmutableArray<IncrementalGeneratorRunStep>> trackedSteps2 = GetTrackedSteps(runResult2, trackingNames);

        trackedSteps1.Should().NotBeEmpty().And.HaveSameCount(trackedSteps2).And.ContainKeys(trackedSteps2.Keys);

        foreach ((string trackingName, ImmutableArray<IncrementalGeneratorRunStep> runSteps1) in trackedSteps1)
        {
            ImmutableArray<IncrementalGeneratorRunStep> runSteps2 = trackedSteps2[trackingName];
            AssertEqual(runSteps1, runSteps2, trackingName);
        }

        return;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="runResult"></param>
    /// <param name="trackingNames"></param>
    /// <returns></returns>
    private static Dictionary<string, ImmutableArray<IncrementalGeneratorRunStep>> GetTrackedSteps(GeneratorDriverRunResult runResult, string[] trackingNames)
    {
        return runResult.Results[0]
                        .TrackedSteps
                        .Where(step => trackingNames.Contains(step.Key))
                        .ToDictionary(trackingName => trackingName.Key, step => step.Value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="runSteps1"></param>
    /// <param name="runSteps2"></param>
    /// <param name="stepName"></param>
    private static void AssertEqual(ImmutableArray<IncrementalGeneratorRunStep> runSteps1,
                                    ImmutableArray<IncrementalGeneratorRunStep> runSteps2,
                                    string stepName)
    {
        runSteps1.Should().HaveSameCount(runSteps2);

        int length = runSteps1.Length;
        for (int index = 0; index < length; index++)
        {
            IncrementalGeneratorRunStep runStep1 = runSteps1[index];
            IncrementalGeneratorRunStep runStep2 = runSteps2[index];

            // The outputs should be equal between different runs
            IEnumerable<object> outputs1 = runStep1.Outputs.Select(x => x.Value);
            IEnumerable<object> outputs2 = runStep2.Outputs.Select(x => x.Value);

            outputs1.Should().Equal(outputs2, $"because {stepName} should produce cacheable outputs");

            runStep2.Outputs.Should()
                            .OnlyContain
                             (
                                runStep => runStep.Reason == IncrementalStepRunReason.Cached || runStep.Reason == IncrementalStepRunReason.Unchanged,
                                $"{stepName} expected to have reason {IncrementalStepRunReason.Cached} or {IncrementalStepRunReason.Unchanged}"
                             );

            AssertObjectGraph(runStep1, stepName);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="runStep"></param>
    /// <param name="stepName"></param>
    private static void AssertObjectGraph(IncrementalGeneratorRunStep runStep, string stepName)
    {
        HashSet<object> visited = [];
        foreach ((object obj, IncrementalStepRunReason _) in runStep.Outputs)
        {
            Visit(obj, stepName, visited);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="stepName"></param>
    /// <param name="visited"></param>
    private static void Visit(object? node, string stepName, HashSet<object> visited)
    {
        string validationReason = $"{stepName} shouldn't contain banned symbols";

        if (node is null || !visited.Add(node))
        {
            return;
        }

        node.Should().NotBeOfType<Compilation>(validationReason)
                     .And.NotBeOfType<ISymbol>(validationReason)
                     .And.NotBeOfType<SyntaxNode>(validationReason);

        Type type = node.GetType();
        if (type.IsPrimitive || type.IsEnum || type == typeof(string))
        {
            return;
        }

        if (node is IEnumerable collection and not string)
        {
            foreach (object element in collection)
            {
                Visit(element, stepName, visited);
            }
            return;
        }

        foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            object? fieldValue = field.GetValue(node);
            Visit(fieldValue, stepName, visited);
        }
    }

    #endregion
}