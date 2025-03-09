using FluentAssertions;
using MinimalApiGen.Framework.Pluralize;

namespace MinimalApiGen.Generators.Tests.Pluralize;

/// <summary>
/// 
/// </summary>
public sealed class PluralizerTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void InputData()
    {
        IPluralizer pluralizer = Pluralizer.Instance;
        string[] input = ResourceReader.InputData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in input)
        {
            string singular = line.Split(',')[0];
            string plural = line.Split(',')[1];

            pluralizer.Pluralize(singular).Should().Be(plural, $"Failed to pluralize {singular}");
            pluralizer.Pluralize(plural).Should().Be(plural, $"Failed to pluralize {plural}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ExceptionSingularToPluralException()
    {
        IPluralizer pluralizer = Pluralizer.Instance;
        string[] input = ResourceReader.SingularToPluralExceptions.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in input)
        {
            string singular = line.Split(',')[0];
            string plural = line.Split(',')[1];

            pluralizer.Pluralize(singular).Should().Be(plural);
            pluralizer.Pluralize(plural).Should().Be(plural);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void PluralizeEmptyString_ReturnsEmptyString()
    {
        IPluralizer pluralizer = Pluralizer.Instance;
        pluralizer.Pluralize(string.Empty).Should().BeEmpty();
    }

    #endregion
}