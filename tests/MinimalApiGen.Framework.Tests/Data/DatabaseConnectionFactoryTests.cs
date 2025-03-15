using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MinimalApiGen.Framework.Data;
using Moq;
using System.Data;

namespace MinimalApiGen.Framework.Tests.Data;

/// <summary>
/// 
/// </summary>
public sealed class DatabaseConnectionFactoryTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenConfigurationIsNull()
    {
        Action act = static () => _ = new DatabaseConnectionFactory(It.IsAny<IConfiguration>());
        act.Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// 
    /// </summaryz
    [Fact]
    public void Constructor_ShouldThrowNullReferenceException_WhenNoConnectionStringsFound()
    {
        Mock<IConfiguration> mockConfiguration = new();
        Mock<IConfigurationSection> mockConfigurationSection = new();
        mockConfiguration.Setup(config => config.GetSection("ConnectionStrings")).Returns(mockConfigurationSection.Object);
        mockConfigurationSection.Setup(config => config.GetChildren()).Returns([]);

        Action act = () => _ = new DatabaseConnectionFactory(mockConfiguration.Object);
        act.Should().Throw<NullReferenceException>().WithMessage("No connection strings found in configuration.");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Constructor_ShouldThrowNullReferenceException_WhenConnectionStringIsEmpty()
    {
        Mock<IConfigurationSection> mockConfigurationSection = new Mock<IConfigurationSection>();
        mockConfigurationSection.Setup(config => config.Value).Returns(string.Empty);

        Mock<IConfiguration> mockConfiguration = new();
        mockConfiguration.Setup(config => config.GetSection("ConnectionStrings")).Returns(mockConfigurationSection.Object);
        mockConfigurationSection.Setup(config => config.GetChildren()).Returns(new[] { mockConfigurationSection.Object });

        Action act = () => _ = new DatabaseConnectionFactory(mockConfiguration.Object);
        act.Should().Throw<NullReferenceException>();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Constructor_ShouldInitialize_WhenValidConnectionStringIsProvided()
    {
        Mock<IConfigurationSection> mockConfigurationSection = new();
        mockConfigurationSection.Setup(config => config.Value).Returns("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");

        Mock<IConfiguration> mockConfiguration = new();
        mockConfiguration.Setup(config => config.GetSection("ConnectionStrings")).Returns(mockConfigurationSection.Object);
        mockConfigurationSection.Setup(config => config.GetChildren()).Returns(new[] { mockConfigurationSection.Object });

        DatabaseConnectionFactory factory = new(mockConfiguration.Object);
        factory.Should().NotBeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Create_ShouldReturnSqlConnection_WhenCalled()
    {
        Mock<IConfigurationSection> mockConfigurationSection = new();
        mockConfigurationSection.Setup(config => config.Value).Returns("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");

        Mock<IConfiguration> mockConfiguration = new();
        mockConfiguration.Setup(config => config.GetSection("ConnectionStrings")).Returns(mockConfigurationSection.Object);
        mockConfigurationSection.Setup(config => config.GetChildren()).Returns([mockConfigurationSection.Object]);

        DatabaseConnectionFactory factory = new(mockConfiguration.Object);

        IDbConnection connection = factory.Create();

        connection.Should().NotBeNull();
        connection.Should().BeOfType<SqlConnection>();
    }

    #endregion
}