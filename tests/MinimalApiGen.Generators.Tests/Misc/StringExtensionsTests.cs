using FluentAssertions;
using MinimalApiGen.Generators.Generation.Shared;

namespace MinimalApiGen.Generators.Tests.Misc;

/// <summary>
/// 
/// </summary>
public sealed class StringExtensionsTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Theory]
    [InlineData("note")]
    [InlineData("user")]
    public void WithIndefiniteArticle_A(string input)
    {
        string result = input.WithIndefiniteArticle();
        result.Should().Be($"a {input}");
    }

    /// <summary>
    /// 
    /// </summary>
    [Theory]
    [InlineData("elephant")]
    [InlineData("hour")]
    [InlineData("input")]
    [InlineData("umbrella")]
    [InlineData("understanding")]
    public void WithIndefiniteArticle_An(string input)
    {
        string result = input.WithIndefiniteArticle();
        result.Should().Be($"an {input}");
    }

    #endregion
}