using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.SnapshotTests.Fixtures;
using System.Text.Json;
using Generator = global::Query.Generator;

namespace MinimalApiGen.Generators.SnapshotTests.Helpers;

/// <summary>
/// 
/// </summary>
public static class DriverBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static GeneratorDriver Build(string source)
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

        IEnumerable<PortableExecutableReference> references =
        [
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(QueryGeneratorAttribute).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(JsonSerializer).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(SampleModel).Assembly.Location)
        ]; 
        CSharpCompilation compilation = CSharpCompilation.Create
        (
            assemblyName: "Tests",
            syntaxTrees: [syntaxTree],
            references: references
        );

        Generator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        return driver.RunGenerators(compilation);
    }

    #endregion
}