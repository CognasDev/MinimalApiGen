using Microsoft.CodeAnalysis;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.IntegrationTests.Fixtures;
using System.Linq.Expressions;
using System.Text.Json;

namespace MinimalApiGen.Generators.IntegrationTests.Helpers;

/// <summary>
/// 
/// </summary>
internal static class ReferencesHelper
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<PortableExecutableReference> BuildReferences()
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

    #endregion
}