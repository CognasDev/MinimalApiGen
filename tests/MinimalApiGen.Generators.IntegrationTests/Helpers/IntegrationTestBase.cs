using FluentAssertions;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace MinimalApiGen.Generators.IntegrationTests.Helpers;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// 
/// </remarks>
[UsesVerify]
public abstract class IntegrationTestBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected abstract string Source { get; }

    /// <summary>
    /// 
    /// </summary>
    protected abstract GeneratorType GeneratorType { get; }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task VerifySnapshot()
    {
        string callingClassName = GetType().Name;
        await SnapshotHelper.VerifyAsync(GeneratorType, Source, callingClassName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="generatorType"></param>
    [Fact]
    public void IsCached()
    {
        (ImmutableArray<Diagnostic> diagnostics, _) = CacheableHelper.GetGeneratedTrees(GeneratorType, [Source]);
        diagnostics.Should().BeEmpty();
    }

    #endregion
}