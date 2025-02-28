using FluentAssertions;
using MinimalApiGen.Shared.Collections;
using System;
using System.Collections.Frozen;

namespace MinimalApiGen.Shared.Tests.Collections;

/// <summary>
/// 
/// </summary>
public sealed class CollectionExtensionsTests
{
    #region Unit Test Declarations - ToFrozenSetAsync

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

    #endregion

    #region Unit Test Declarations - FastForEach

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
        collection.FastForEach(item => item < 3, item => result.Add(item));

        // Assert
        result.Should().Equal([1, 2]);
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
            return item < 3;
        }, async item =>
        {
            await Task.CompletedTask;
            result.Add(item);
        });

        // Assert
        result.Should().Equal([1, 2]);
    }

    #endregion

    #region Unit Test Declarations - FastFirst

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastFirst_ShouldReturnFirstMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int result = collection.FastFirst(item => item == 2);

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastFirst_ShouldThrowInvalidOperationException()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        Action action = () => collection.FastFirst(item => item == 0);

        // Assert
        action.Should().Throw<InvalidOperationException>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastFirstAsync_ShouldReturnFirstMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int? result = await collection.FastFirstAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 2;
        });

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastFirstAsync_ShouldThrowInvalidOperationExceptionl()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        Func<Task> action = async () => await collection.FastFirstAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 0;
        });

        // Assert
        await action.Should().ThrowAsync<InvalidOperationException>();
    }

    #endregion

    #region Unit Test Declarations - FastFirstOrDefault

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastFirstOrDefault_ShouldReturnFirstMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int result = collection.FastFirstOrDefault(item => item == 2);

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastFirstOrDefault_ShouldReturnNull()
    {
        // Arrange
        List<int?> collection = [1, 2, 3, 4];

        // Act
        int? result = collection.FastFirstOrDefault(item => item == 0);

        // Assert
        result.Should().BeNull();
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
            return item == 2;
        });

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastFirstOrDefaultAsync_ShouldReturnNull()
    {
        // Arrange
        List<int?> collection = [1, 2, 3, 4];

        // Act
        int? result = await collection.FastFirstOrDefaultAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 0;
        });

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region Unit Test Declarations - FastSingle

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastSingle_ShouldReturnSingleMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int result = collection.FastSingle(item => item == 2);

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastSingle_ShouldThrowInvalidOperationException_WhenNoMatch()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        Action action = () => collection.FastSingle(item => item == 0);

        // Assert
        action.Should().Throw<InvalidOperationException>();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastSingle_ShouldReturnInvalidOperationException_WhenMultipleMatches()
    {
        // Arrange
        List<int> collection = [2, 2];

        // Act
        Action action = () => collection.FastSingle(item => item == 2);

        //Assert
        action.Should().Throw<InvalidOperationException>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastSingleAsync_ShouldReturnSingleMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int? result = await collection.FastSingleAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 2;
        });

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastSingleAsync_ShouldThrowInvalidOperationException_WhenNoMatch()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        Func<Task> action = async () => await collection.FastSingleAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 0;
        });

        // Assert
        await action.Should().ThrowAsync<InvalidOperationException>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastSingleAsync_ShouldThrowInvalidOperationException_WhenMultipleMatches()
    {
        // Arrange
        List<int> collection = [2, 2];

        // Act
        Func<Task> action = async () => await collection.FastSingleAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 2;
        });

        // Assert
        await action.Should().ThrowAsync<InvalidOperationException>();
    }

    #endregion

    #region Unit Test Declarations - FastSingleOrDefault

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastSingleOrDefault_ShouldReturnFirstMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int? result = collection.FastSingleOrDefault(item => item == 2);

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastSingleOrDefault_ShouldReturnNull()
    {
        // Arrange
        List<int?> collection = [1, 2, 3, 4];

        // Act
        int? result = collection.FastSingleOrDefault(item => item == 0);

        // Assert
        result.Should().BeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastSingleOrDefaultAsync_ShouldReturnFirstMatchingItem()
    {
        // Arrange
        List<int> collection = [1, 2, 3, 4];

        // Act
        int? result = await collection.FastSingleOrDefaultAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 2;
        });

        // Assert
        result.Should().Be(2);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void FastSingleOrDefault_ShouldReturnInvalidOperationException_WhenMultipleMatches()
    {
        // Arrange
        List<int> collection = [2, 2];

        // Act
        Action action = () => collection.FastSingleOrDefault(item => item == 2);

        //Assert
        action.Should().Throw<InvalidOperationException>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastSingleOrDefaultAsync_ShouldReturnNull()
    {
        // Arrange
        List<int?> collection = [1, 2, 3, 4];

        // Act
        int? result = await collection.FastSingleOrDefaultAsync(async item =>
        {
            await Task.CompletedTask;
            return item == 0;
        });

        // Assert
        result.Should().BeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task FastSingleOrDefaultAsync_ShouldReturnInvalidOperationException_WhenMutipleMatches()
    {
        // Arrange
        List<int> collection = [2, 2];

        // Act
        Func<Task> action = async () => await collection.FastSingleOrDefaultAsync(async item =>
         {
             await Task.CompletedTask;
             return item == 2;
         });

        // Assert
        await action.Should().ThrowAsync<InvalidOperationException>();
    }

    #endregion

    #region Unit Test Declarations - AddRange

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