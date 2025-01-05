using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace MinimalApiGen.Generators.IntegrationTests.Helpers;

/// <summary>
/// 
/// </summary>
internal static class CompilationBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="references"></param>
    /// <returns></returns>
    public static CSharpCompilation Build(string source, IEnumerable<PortableExecutableReference> references) => Build([source], references);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sources"></param>
    /// <param name="references"></param>
    /// <returns></returns>
    public static CSharpCompilation Build(string[] sources, IEnumerable<PortableExecutableReference> references)
    {
        IEnumerable<SyntaxTree> syntaxTrees = sources.Select(static source => CSharpSyntaxTree.ParseText(source));
        CSharpCompilationOptions options = new(OutputKind.DynamicallyLinkedLibrary);
        return CSharpCompilation.Create
        (
            "Test",
            syntaxTrees,
            references,
            options
        );
    }

    #endregion
}