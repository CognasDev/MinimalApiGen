using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

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
        IIncrementalGenerator generator = new ApiGenerator.Generator();
        CSharpGeneratorDriver csharpDriver = CSharpGeneratorDriver.Create(generator);
        GeneratorDriver driver = csharpDriver.RunGenerators(compilation);

        await Verifier.Verify(driver).UseDirectory($"../Snapshots/{outputFolder}").UseMethodName("Output");
    }

    #endregion
}