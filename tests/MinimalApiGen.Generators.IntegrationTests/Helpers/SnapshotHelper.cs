using Microsoft.CodeAnalysis;
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
    /// <param name="source"></param>
    /// <returns></returns>
    public static async Task VerifyAsync(string source, string outputFolder)
    {
        IEnumerable<PortableExecutableReference> references = ReferencesHelper.BuildReferences();
        CSharpCompilation compilation = CreateCompilation(source, references);
        Generator generator = new();
        CSharpGeneratorDriver csharpDriver = CSharpGeneratorDriver.Create(generator);
        GeneratorDriver driver = csharpDriver.RunGenerators(compilation);

        await Verifier.Verify(driver).UseDirectory($"../Snapshots/{outputFolder}").UseMethodName("Output");
    }

    #endregion

    #region Private Method Declarations

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
            references: references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );
    }

    #endregion
}