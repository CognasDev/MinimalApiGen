using FluentAssertions;
using MinimalApiGen.Generators.Pluralize;

namespace MinimalApiGen.Generators.Tests.Pluralize;

/// <summary>
/// 
/// </summary>
public sealed class PluralizerTests
{
    #region Unit Test Method Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void InputData()
    {
        Pluralizer pluralizer = new();
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
        Pluralizer pluralizer = new();
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
        Pluralizer pluralizer = new();
        pluralizer.Pluralize(string.Empty).Should().BeEmpty();
    }

    #endregion
}