using FluentAssertions;
using Microsoft.AspNetCore.Http;
using MinimalApiGen.Framework.Pagination;
using Moq;
using System.ComponentModel;

namespace MinimalApiGen.Framework.Tests.Pagination;

/// <summary>
/// 
/// </summary>
public sealed class PaginationServiceTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void TakeQuantity_ShouldReturnPageSize()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);

        // Act
        int result = paginationService.TakeQuantity(paginationQueryMock.Object);

        // Assert
        result.Should().Be(10);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void SkipNumber_ShouldReturnCorrectSkipNumber()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(2);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);

        // Act
        int result = paginationService.SkipNumber(paginationQueryMock.Object);

        // Assert
        result.Should().Be(10);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void OrderByProperty_ShouldReturnCorrectPropertyDescriptor()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");

        // Act
        PropertyDescriptor result = paginationService.OrderByProperty<TestModel>(paginationQueryMock.Object);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Name");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void IsPaginationQueryValidOrNotRequested_ShouldReturnTrueForValidQuery()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(1);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");

        // Act
        bool? result = paginationService.IsPaginationQueryValidOrNotRequested<TestModel>(paginationQueryMock.Object);

        // Assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void IsPaginationQueryValidOrNotRequested_ShouldReturnNullForEmptyQuery()
    {
        // Arrange
        PaginationService paginationService = new();
        IPaginationQuery paginationQuery = Mock.Of<IPaginationQuery>();

        // Act
        bool? result = paginationService.IsPaginationQueryValidOrNotRequested<TestModel>(paginationQuery);

        // Assert
        result.Should().BeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void BuildPaginationResponseHeader_ShouldSetTotalHeader()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(1);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderByAscending).Returns(true);

        DefaultHttpContext httpContextMock = new();
        List<TestModel> models = [new() { Name = "Test" }];

        // Act
        paginationService.BuildPaginationResponseHeader(paginationQueryMock.Object, models, httpContextMock);

        // Assert
        httpContextMock.Response.Headers["x-total"].Should().Equal("1");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void BuildPaginationResponseHeader_ShouldSetPageCountHeader()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(1);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderByAscending).Returns(true);

        DefaultHttpContext httpContextMock = new();
        List<TestModel> models = [new() { Name = "Test" }];

        // Act
        paginationService.BuildPaginationResponseHeader(paginationQueryMock.Object, models, httpContextMock);

        // Assert
        httpContextMock.Response.Headers["x-page-count"].Should().Equal("1");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void BuildPaginationResponseHeader_ShouldSetPageSizeHeader()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(1);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderByAscending).Returns(true);

        DefaultHttpContext httpContextMock = new();
        List<TestModel> models = [new() { Name = "Test" }];

        // Act
        paginationService.BuildPaginationResponseHeader(paginationQueryMock.Object, models, httpContextMock);

        // Assert
        httpContextMock.Response.Headers["x-page-size"].Should().Equal("10");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void BuildPaginationResponseHeader_ShouldSetPageNumberHeader()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(1);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderByAscending).Returns(true);

        DefaultHttpContext httpContextMock = new();
        List<TestModel> models = [new() { Name = "Test" }];

        // Act
        paginationService.BuildPaginationResponseHeader(paginationQueryMock.Object, models, httpContextMock);

        // Assert
        httpContextMock.Response.Headers["x-page-number"].Should().Equal("1");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void BuildPaginationResponseHeader_ShouldSetOrderByHeader()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(1);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderByAscending).Returns(true);

        DefaultHttpContext httpContextMock = new();
        List<TestModel> models = [new() { Name = "Test" }];

        // Act
        paginationService.BuildPaginationResponseHeader(paginationQueryMock.Object, models, httpContextMock);

        // Assert
        httpContextMock.Response.Headers["x-page-orderby"].Should().Equal("Name");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void BuildPaginationResponseHeader_ShouldSetOrderByAscendingHeader()
    {
        // Arrange
        PaginationService paginationService = new();
        Mock<IPaginationQuery> paginationQueryMock = new();
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageNumber).Returns(1);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.PageSize).Returns(10);
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderBy).Returns("Name");
        paginationQueryMock.Setup(paginationQuery => paginationQuery.OrderByAscending).Returns(true);

        DefaultHttpContext httpContextMock = new();
        List<TestModel> models = [new() { Name = "Test" }];

        // Act
        paginationService.BuildPaginationResponseHeader(paginationQueryMock.Object, models, httpContextMock);

        // Assert
        httpContextMock.Response.Headers["x-page-orderbyascending"].Should().Equal("true");
    }

    #endregion

}