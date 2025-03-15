using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public sealed class DatabaseConnectionFactory : IDatabaseConnectionFactory
{
    #region Field Declarations

    private readonly string _connectionString;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="DatabaseConnectionFactory"/>
    /// </summary>
    /// <param name="configuration"></param>
    /// <exception cref="NullReferenceException"></exception>
    public DatabaseConnectionFactory(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        IConfigurationSection connectionStringsSection = configuration.GetSection("ConnectionStrings");

        IConfigurationSection section = connectionStringsSection.GetChildren().SingleOrDefault() ?? throw new NullReferenceException("No connection strings found in configuration.");
        if (string.IsNullOrWhiteSpace(section.Value))
        {
            throw new NullReferenceException();
        }

        _connectionString = section.Value;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IDbConnection Create() => new SqlConnection(_connectionString);

    #endregion
}