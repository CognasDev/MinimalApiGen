using Dapper;
using FluentAssertions;
using MinimalApiGen.Framework.Data;
using Moq;

namespace MinimalApiGen.Framework.Tests.Data;

/// <summary>
/// 
/// </summary>
public sealed class DynamicParameterFactoryTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Create_Single()
    {
        string name = Guid.NewGuid().ToString();
        string value = Guid.NewGuid().ToString();

        DynamicParameterFactory dynamicParameterFactory = new();
        Mock<IParameter> mockParameter = new();

        mockParameter.SetupGet(parameter => parameter.Name).Returns(name);
        mockParameter.SetupGet(parameter => parameter.Value).Returns(value);

        List<IParameter> parameters = [mockParameter.Object];
        DynamicParameters? dynamicParameters = dynamicParameterFactory.Create(parameters);

        dynamicParameters.Should().NotBeNull();
        dynamicParameters!.ParameterNames.Count().Should().Be(1);
        dynamicParameters!.ParameterNames.Single().Should().Be(name);
        dynamicParameters!.Get<string>(name).Should().Be(value);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Create_Multiple()
    {
        string name1 = Guid.NewGuid().ToString();
        string value1 = Guid.NewGuid().ToString();
        string name2 = Guid.NewGuid().ToString();
        string value2 = Guid.NewGuid().ToString();

        DynamicParameterFactory dynamicParameterFactory = new();
        Mock<IParameter> mockParameter1 = new();
        Mock<IParameter> mockParameter2 = new();

        mockParameter1.SetupGet(parameter => parameter.Name).Returns(name1);
        mockParameter1.SetupGet(parameter => parameter.Value).Returns(value1);
        mockParameter2.SetupGet(parameter => parameter.Name).Returns(name2);
        mockParameter2.SetupGet(parameter => parameter.Value).Returns(value2);

        List<IParameter> parameters = [mockParameter1.Object, mockParameter2.Object];
        DynamicParameters? dynamicParameters = dynamicParameterFactory.Create(parameters);

        dynamicParameters.Should().NotBeNull();
        dynamicParameters!.ParameterNames.Count().Should().Be(2);
        dynamicParameters!.ParameterNames.ElementAt(0).Should().Be(name1);
        dynamicParameters!.ParameterNames.ElementAt(1).Should().Be(name2);
        dynamicParameters!.Get<string>(name1).Should().Be(value1);
        dynamicParameters!.Get<string>(name2).Should().Be(value2);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Create_None()
    {
        DynamicParameterFactory dynamicParameterFactory = new();

        List<IParameter> parameters = [];
        DynamicParameters? dynamicParameters = dynamicParameterFactory.Create(parameters);

        dynamicParameters.Should().BeNull();
    }

    #endregion
}