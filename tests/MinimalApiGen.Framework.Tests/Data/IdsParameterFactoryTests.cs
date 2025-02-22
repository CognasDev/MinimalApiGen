using FluentAssertions;
using MinimalApiGen.Framework.Data;
using static Dapper.SqlMapper;

namespace MinimalApiGen.Framework.Tests.Data;

/// <summary>
/// 
/// </summary>
public sealed class IdsParameterFactoryTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Create()
    {
        IdsParameterFactory idsParameterFactory = new();
        List<int> ids = [1];
        IParameter idsParameter = idsParameterFactory.Create(ids);
        idsParameter.Value.Should().BeAssignableTo<ICustomQueryParameter>();
        idsParameter.Value.Should().NotBeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Create_NoIdsProvided()
    {
        IdsParameterFactory idsParameterFactory = new();
        List<int> ids = [];
        Action action = () => idsParameterFactory.Create(ids);
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion
}