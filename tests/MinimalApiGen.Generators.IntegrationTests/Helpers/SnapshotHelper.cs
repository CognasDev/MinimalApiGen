﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Generator = global::Query.Generator;

namespace MinimalApiGen.Generators.IntegrationTests.Helpers;

/// <summary>
/// 
/// </summary>
public static class SnapshotHelper
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="generatorType"></param>
    /// <param name="source"></param>
    /// <param name="outputFolder"></param>
    /// <returns></returns>
    public static async Task VerifyAsync(GeneratorType generatorType, string source, string outputFolder)
    {
        IEnumerable<PortableExecutableReference> references = ReferencesBuilder.Build();
        CSharpCompilation compilation = CompilationBuilder.Build(source, references);
        IIncrementalGenerator generator = generatorType switch
        {
            GeneratorType.Command => new Command.Generator(),
            GeneratorType.Query => new Query.Generator(),
            _ => throw new NotSupportedException()
        };
        CSharpGeneratorDriver csharpDriver = CSharpGeneratorDriver.Create(generator);
        GeneratorDriver driver = csharpDriver.RunGenerators(compilation);

        await Verifier.Verify(driver).UseDirectory($"../Snapshots/{outputFolder}").UseMethodName("Output");
    }

    #endregion
}