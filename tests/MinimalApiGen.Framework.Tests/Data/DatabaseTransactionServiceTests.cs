using FluentAssertions;
using MinimalApiGen.Framework.Data;

namespace MinimalApiGen.Framework.Tests.Data;

/// <summary>
/// 
/// </summary>
public sealed class DatabaseTransactionServiceTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ExecuteTransaction()
    {
        DatabaseTransactionService databaseTransactionService = new();
        Func<Task> action = async () =>
        {
            await databaseTransactionService.ExecuteTransactionAsync(() => Task.CompletedTask);
        };
        action.Should().NotThrowAsync();
    }

    #endregion
}