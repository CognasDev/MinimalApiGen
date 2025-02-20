using FluentAssertions;
using MinimalApiGen.Framework.Collections;
using System.Collections.Frozen;

namespace MinimalApiGen.Framework.Tests.Collections;

/// <summary>
/// 
/// </summary>
public sealed class CollectionExtensionsTests
{
    #region Unit Test Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ToFrozenSetAsync_ShouldReturnFrozenSet()
    {
        // Arrange
        List<int> list = [1, 2, 3];
        IAsyncEnumerable<int> collection = list.ToAsyncEnumerable();

        // Act
        FrozenSet<int> result = await collection.ToFrozenSetAsync(TestContext.Current.CancellationToken);

        // Assert
        result.Should().BeAssignableTo<FrozenSet<int>>();
        result.Count.Should().Be(3);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastForEach_ShouldIterateOverCollection()
    {
        // Arrange
        List<int> collection = [1, 2, 3];
        List<int> result = [];

        // Act
        collection.FastForEach(item => result.Add(item));

        // Assert
        result.Should().Equal(collection);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastForEach_WithPredicate_ShouldIterateOverFilteredCollection()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];
        List<int> result = [];

        // Act
        collection.FastForEach(item => item % 2 == 0, item => result.Add(item));

        // Assert
        result.Should().Equal([2, 4]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastForEachAsync_ShouldIterateOverCollection()
    {
        // Arrange
        List<int> collection = [1, 2, 3];
        List<int> result = [];

        // Act
        await collection.FastForEachAsync(async item =>
        {
            await Task.CompletedTask;
            result.Add(item);
        });

        // Assert
        result.Should().Equal(collection);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastForEachAsync_WithPredicate_ShouldIterateOverFilteredCollection()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];
        List<int> result = [];

        // Act
        await collection.FastForEachAsync(async item =>
        {
            await Task.CompletedTask;
            return item % 2 == 0;
        }, async item =>
        {
            await Task.CompletedTask;
            result.Add(item);
        });

        // Assert
        result.Should().Equal([2, 4]);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastFirstOrDefault_ShouldReturnFirstMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int? result = collection.FastFirstOrDefault(item => item % 2 == 0);

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastFirstOrDefaultAsync_ShouldReturnFirstMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int? result = await collection.FastFirstOrDefaultAsync(async item =>
        {
            await Task.CompletedTask;
            return item % 2 == 0;
        });

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void AddRange_ShouldAddItemsToDictionary()
    {
        // Arrange
        Dictionary<int, string> source = new() { [1] = "one" };
        Dictionary<int, string> dictionary = new() { [2] = "two", [3] = "three" };

        // Act
        source.AddRange(dictionary);

        // Assert
        source.Should().HaveCount(3);
        source[1].Should().Be("one");
        source[2].Should().Be("two");
        source[3].Should().Be("three");
    }

    #endregion
}