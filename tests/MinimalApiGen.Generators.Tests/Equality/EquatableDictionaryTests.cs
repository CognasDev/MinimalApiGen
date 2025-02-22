using FluentAssertions;
using MinimalApiGen.Generators.Equality;

namespace MinimalApiGen.Generators.Tests.Equality;

/// <summary>
/// 
/// </summary>
public sealed class EquatableDictionaryTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Empty_ShouldBeEmpty()
    {
        EquatableDictionary<int, string> emptyDictionary = EquatableDictionary<int, string>.Empty;
        emptyDictionary.Should().BeEmpty();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_ShouldReturnTrueForEqualDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        Dictionary<int, string> dictionary2 = new() { [1] = "one", [2] = "two" };

        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        EquatableDictionary<int, string> equatableDictionary2 = new(dictionary2);

        equatableDictionary1.Equals(equatableDictionary2).Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_ShouldReturnFalseForDifferentDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        Dictionary<int, string> dictionary2 = new() { [1] = "one", [3] = "three" };

        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        EquatableDictionary<int, string> equatableDictionary2 = new(dictionary2);

        equatableDictionary1.Equals(equatableDictionary2).Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_Object_ShouldReturnTrueForEqualDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        object equatableDictionary2 = new EquatableDictionary<int, string>(dictionary1);

        equatableDictionary1.Equals(equatableDictionary2).Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Equals_Object_ShouldReturnFalseForDifferentDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        Dictionary<int, string> dictionary2 = new() { [1] = "one", [3] = "three" };

        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        object equatableDictionary2 = new EquatableDictionary<int, string>(dictionary2);

        equatableDictionary1.Equals(equatableDictionary2).Should().BeFalse();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetHashCode_ShouldReturnSameHashCodeForEqualDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        Dictionary<int, string> dictionary2 = new() { [1] = "one", [2] = "two" };

        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        EquatableDictionary<int, string> equatableDictionary2 = new(dictionary2);

        equatableDictionary1.GetHashCode().Should().Be(equatableDictionary2.GetHashCode());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetHashCode_ShouldReturnDifferentHashCodeForDifferentDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        Dictionary<int, string> dictionary2 = new() { [1] = "one", [3] = "three" };

        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        EquatableDictionary<int, string> equatableDictionary2 = new(dictionary2);

        equatableDictionary1.GetHashCode().Should().NotBe(equatableDictionary2.GetHashCode());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void AsSpan_ShouldReturnCorrectSpan()
    {
        Dictionary<int, string> dictionary = new() { [1] = "one", [2] = "two" };
        EquatableDictionary<int, string> equatableDictionary = new(dictionary);

        equatableDictionary.AsSpan().ToArray().Should().BeEquivalentTo(dictionary.ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void KeysAsSpan_ShouldReturnCorrectSpan()
    {
        Dictionary<int, string> dictionary = new() { [1] = "one", [2] = "two" };
        EquatableDictionary<int, string> equatableDictionary = new(dictionary);

        equatableDictionary.KeysAsSpan().ToArray().Should().BeEquivalentTo(dictionary.Keys.ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ValuesAsSpan_ShouldReturnCorrectSpan()
    {
        Dictionary<int, string> dictionary = new() { [1] = "one", [2] = "two" };
        EquatableDictionary<int, string> equatableDictionary = new(dictionary);

        equatableDictionary.ValuesAsSpan().ToArray().Should().BeEquivalentTo(dictionary.Values.ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetArray_ShouldReturnCorrectArray()
    {
        Dictionary<int, string> dictionary = new() { [1] = "one", [2] = "two" };
        EquatableDictionary<int, string> equatableDictionary = new(dictionary);

        equatableDictionary.GetArray().Should().BeEquivalentTo(dictionary.ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Enumerator_ShouldEnumerateCorrectly()
    {
        Dictionary<int, string> dictionary = new() { [1] = "one", [2] = "two" };
        EquatableDictionary<int, string> equatableDictionary = new(dictionary);

        List<KeyValuePair<int, string>> enumeratedList = new();
        foreach (KeyValuePair<int, string> kvp in equatableDictionary)
        {
            enumeratedList.Add(kvp);
        }

        enumeratedList.Should().BeEquivalentTo(dictionary.ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void OperatorEquals_ShouldReturnTrueForEqualDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        Dictionary<int, string> dictionary2 = new() { [1] = "one", [2] = "two" };

        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        EquatableDictionary<int, string> equatableDictionary2 = new(dictionary2);

        (equatableDictionary1 == equatableDictionary2).Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void OperatorNotEquals_ShouldReturnTrueForDifferentDictionaries()
    {
        Dictionary<int, string> dictionary1 = new() { [1] = "one", [2] = "two" };
        Dictionary<int, string> dictionary2 = new() { [1] = "one", [3] = "three" };

        EquatableDictionary<int, string> equatableDictionary1 = new(dictionary1);
        EquatableDictionary<int, string> equatableDictionary2 = new(dictionary2);

        (equatableDictionary1 != equatableDictionary2).Should().BeTrue();
    }

    #endregion
}