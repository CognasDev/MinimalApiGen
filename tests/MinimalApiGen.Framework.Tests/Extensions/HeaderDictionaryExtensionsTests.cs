using FluentAssertions;
using Microsoft.AspNetCore.Http;
using MinimalApiGen.Framework.Extensions;

namespace MinimalApiGen.Framework.Tests.Extensions;

/// <summary>
/// 
/// </summary>
public sealed class HeaderDictionaryExtensionsTests
{
    #region Unit Test Method Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void AppendSanitised_ShouldAppendSanitisedIntValue()
    {
        // Arrange
        HeaderDictionary headers = [];
        string key = "Test-Int";
        int value = 123;

        // Act
        headers.AppendSanitised(key, value);

        // Assert
        headers[key].Should().Equal("123");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void AppendSanitised_ShouldAppendSanitisedBoolValue()
    {
        // Arrange
        HeaderDictionary headers = [];
        string key = "Test-Bool";
        bool value = true;

        // Act
        headers.AppendSanitised(key, value);

        // Assert
        headers[key].Should().Equal("true");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void AppendSanitised_ShouldAppendSanitisedStringValue()
    {
        // Arrange
        HeaderDictionary headers = [];
        string key = "Test-String";
        string value = "Hello\r\nWorld%0d%0A";

        // Act
        headers.AppendSanitised(key, value);

        // Assert
        headers[key].Should().Equal("HelloWorld");
    }

    #endregion
}