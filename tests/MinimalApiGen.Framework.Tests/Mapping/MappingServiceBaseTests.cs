﻿using FluentAssertions;

namespace MinimalApiGen.Framework.Tests.Mapping;

/// <summary>
/// 
/// </summary>
public sealed class MappingServiceBaseTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Map_SingleItem_ReturnsMappedItem()
    {
        // Arrange
        MappingServiceFixture service = new();
        int source = 1;

        // Act
        string result = service.Map(source);

        // Assert
        result.Should().Be("1");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Map_Collection_ReturnsMappedCollection()
    {
        // Arrange
        MappingServiceFixture service = new();
        List<int> sourceCollection = [1, 2, 3];

        // Act
        IEnumerable<string> result = service.Map(sourceCollection);

        // Assert
        List<string> expected = ["1", "2", "3"];
        result.Should().Equal(expected);
    }

    #endregion
}