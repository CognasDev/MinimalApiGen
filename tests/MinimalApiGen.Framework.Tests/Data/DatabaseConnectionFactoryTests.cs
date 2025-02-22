using FluentAssertions;
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
    public void CreateDbConnection_ValidKey()
    {
        Mock<IConfiguration> mockConfiguration = new();
        Mock<IConfigurationSection> mockConfigurationSection = new();

        const string validConnectionStringKey = "localdb";
        string expectedConnectionString = "Data Source=ServerName;Initial Catalog=DataBaseName;Integrated Security=SSPI;";

        mockConfiguration.Setup(configuration => configuration.GetSection(It.Is<string>(sectionName => sectionName == "ConnectionStrings"))).Returns(mockConfigurationSection.Object);
        mockConfigurationSection.SetupGet(configurationSection => configurationSection[It.Is<string>(key => key == validConnectionStringKey)]).Returns(expectedConnectionString);

        DatabaseConnectionFactory databaseConnectionFactory = new(mockConfiguration.Object);
        IDbConnection databaseConnection = databaseConnectionFactory.Create();
        databaseConnection.ConnectionString.Should().Be(expectedConnectionString);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void CreateDbConnection_InvalidKey()
    {
        Mock<IConfiguration> mockConfiguration = new();
        Mock<IConfigurationSection> mockConfigurationSection = new();

        mockConfiguration.Setup(configuration => configuration.GetSection(It.Is<string>(sectionName => sectionName == "ConnectionStrings"))).Returns(mockConfigurationSection.Object);

        Action action = () =>
        {
            DatabaseConnectionFactory databaseConnectionFactory = new(mockConfiguration.Object);
        };

        action.Should().Throw<KeyNotFoundException>();
    }

    #endregion
}