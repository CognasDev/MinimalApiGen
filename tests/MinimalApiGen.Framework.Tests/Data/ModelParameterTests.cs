using FluentAssertions;
using MinimalApiGen.Framework.Data;

namespace MinimalApiGen.Framework.Tests.Data;

/// <summary>
/// 
/// </summary>
public sealed class ModelParameterTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Ctor_Valid()
    {
        const int valueToTestAgainst = 1;
        ModelParameter<TestModel> modelParameter = new(testModel => testModel.Id, valueToTestAgainst);

        modelParameter.Name.Should().Be(nameof(TestModel.Id));
        modelParameter.Value.Should().Be(valueToTestAgainst);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetFunction()
    {
        const int valueToTestAgainst = 1;
        ModelParameter<TestModel> modelParameter = new(testModel => testModel.Id, valueToTestAgainst);
        TestModel testModel = new() { Id = valueToTestAgainst };
        modelParameter.GetFunction().Invoke(testModel);
        testModel.Id.Should().Be(valueToTestAgainst);
    }

    #endregion

    #region Fixtures

    /// <summary>
    /// 
    /// </summary>
    private sealed record TestModel
    {
        #region Property Declarations

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        #endregion
    }

    #endregion
}