using FluentAssertions;
using MinimalApiGen.Framework.Data;

namespace MinimalApiGen.Framework.Tests.Data;

/// <summary>
/// 
/// </summary>
public sealed class ParameterTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Ctor_Valid()
    {
        string name = Guid.NewGuid().ToString();
        string value = Guid.NewGuid().ToString();
        Parameter parameter = new(name, value);

        parameter.Name.Should().Be(name);
        parameter.Value.Should().Be(value);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Ctor_Invalid_EmptyName()
    {
        string name = string.Empty;
        string value = Guid.NewGuid().ToString();

        Action action = () => _ = new Parameter(name, value);

        action.Should().Throw<ArgumentException>().WithParameterName(nameof(IParameter.Name).ToLower());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Ctor_Invalid_WhiteSpaceName()
    {
        string name = " ";
        string value = Guid.NewGuid().ToString();

        Action action = () => _ = new Parameter(name, value);

        action.Should().Throw<ArgumentException>().WithParameterName(nameof(IParameter.Name).ToLower());
    }

    #endregion
}