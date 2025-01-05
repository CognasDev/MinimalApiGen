using FluentAssertions;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace MinimalApiGen.Generators.IntegrationTests.Helpers;

/// <summary>
/// 
/// </summary>
[UsesVerify]
public abstract class IntegrationTestBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected abstract string Source { get; }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public abstract Task VerifySnapshot();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected async Task VerifySnapshotAsync(string name) => await SnapshotHelper.VerifyAsync(Source, name);

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void IsCached()
    {
        (ImmutableArray<Diagnostic> diagnostics, _) = CacheableHelper.GetGeneratedTrees([Source]);
        diagnostics.Should().BeEmpty();
    }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    protected IntegrationTestBase()
    {
    }

    #endregion
}