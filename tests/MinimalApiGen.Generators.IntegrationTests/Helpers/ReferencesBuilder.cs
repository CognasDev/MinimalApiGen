using Microsoft.CodeAnalysis;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.IntegrationTests.Fixtures;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

namespace MinimalApiGen.Generators.IntegrationTests.Helpers;

/// <summary>
/// 
/// </summary>
internal static class ReferencesBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<PortableExecutableReference> Build()
    {
        Assembly runtimeAssembly = Assembly.Load(new AssemblyName("System.Runtime"));
        return
        [
            MetadataReference.CreateFromFile(runtimeAssembly.Location),
            MetadataReference.CreateFromFile(typeof(Expression<>).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(QueryGeneratorAttribute).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(JsonSerializer).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(SampleModel).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
        ];
    }

    #endregion
}