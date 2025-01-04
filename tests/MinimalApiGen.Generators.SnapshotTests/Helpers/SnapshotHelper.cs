using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.SnapshotTests.Fixtures;
using System.Linq.Expressions;
using System.Text.Json;
using Generator = global::Query.Generator;

namespace MinimalApiGen.Generators.SnapshotTests.Helpers;

/// <summary>
/// 
/// </summary>
public static class SnapshotHelper
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static async Task VerifyAsync(string source, string outputFolder)
    {
        IEnumerable<PortableExecutableReference> references = BuildReferences();
        CSharpCompilation compilation = CreateCompilation(source, references);
        Generator generator = new();
        CSharpGeneratorDriver csharpDriver = CSharpGeneratorDriver.Create(generator);
        GeneratorDriver driver = csharpDriver.RunGenerators(compilation);

        await Verifier.Verify(driver).UseDirectory($"../Snapshots/{outputFolder}");
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<PortableExecutableReference> BuildReferences()
    {
        return
        [
            MetadataReference.CreateFromFile(typeof(Expression<>).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Attribute).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(QueryGeneratorAttribute).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(JsonSerializer).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(SampleModel).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
        ];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="references"></param>
    /// <returns></returns>
    private static CSharpCompilation CreateCompilation(string source, IEnumerable<PortableExecutableReference> references)
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);
        return CSharpCompilation.Create
        (
            assemblyName: "Tests",
            syntaxTrees: [syntaxTree],
            references: references
        );
    }

    #endregion
}