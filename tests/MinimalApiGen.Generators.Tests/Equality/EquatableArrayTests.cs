using FluentAssertions;
using MinimalApiGen.Generators.Equality;

namespace MinimalApiGen.Generators.Tests.Equality;

/// <summary>
/// 
/// </summary>
public sealed class EquatableArrayTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Empty_ShouldBeEmpty()
    {
        EquatableArray<int> emptyArray = EquatableArray<int>.Empty;
        emptyArray.Count.Should().Be(0);
        emptyArray.GetArray().Should().BeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Count_ShouldReturnCorrectCount()
    {
        EquatableArray<int> array = new([1, 2, 3]);
        array.Count.Should().Be(3);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_ShouldReturnTrueForEqualArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        EquatableArray<int> array2 = new([1, 2, 3]);
        array1.Equals(array2).Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_ShouldReturnFalseForDifferentArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        EquatableArray<int> array2 = new([4, 5, 6]);
        array1.Equals(array2).Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_Object_ShouldReturnTrueForEqualArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        object array2 = new EquatableArray<int>([1, 2, 3]);
        array1.Equals(array2).Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_Object_ShouldReturnFalseForDifferentArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        object array2 = new EquatableArray<int>([4, 5, 6]);
        array1.Equals(array2).Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        EquatableArray<int> array2 = new([1, 2, 3]);
        array1.GetHashCode().Should().Be(array2.GetHashCode());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetHashCode_ShouldReturnDifferentHashCodeForDifferentArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        EquatableArray<int> array2 = new([4, 5, 6]);
        array1.GetHashCode().Should().NotBe(array2.GetHashCode());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void AsSpan_ShouldReturnCorrectSpan()
    {
        EquatableArray<int> array = new([1, 2, 3]);
        array.AsSpan().ToArray().Should().Equal([1, 2, 3]);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetArray_ShouldReturnCorrectArray()
    {
        EquatableArray<int> array = new([1, 2, 3]);
        array.GetArray().Should().Equal([1, 2, 3]);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Enumerator_ShouldEnumerateCorrectly()
    {
        EquatableArray<int> array = new([1, 2, 3]);
        List<int> result = [];
        foreach (int item in array)
        {
            result.Add(item);
        }
        result.Should().Equal([1, 2, 3]);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void OperatorEquals_ShouldReturnTrueForEqualArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        EquatableArray<int> array2 = new([1, 2, 3]);
        (array1 == array2).Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void OperatorNotEquals_ShouldReturnTrueForDifferentArrays()
    {
        EquatableArray<int> array1 = new([1, 2, 3]);
        EquatableArray<int> array2 = new([4, 5, 6]);
        (array1 != array2).Should().BeTrue();
    }

    #endregion
}