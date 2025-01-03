using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MinimalApiGen.Generators.Equality;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
/// <param name="dictionary"></param>
public readonly struct EquatableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary) : IEquatable<EquatableDictionary<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
    where TKey : IEquatable<TKey>
    where TValue : IEquatable<TValue>
{
    #region Field Declarations

    /// <summary>
    /// 
    /// </summary>
    public static readonly EquatableDictionary<TKey, TValue> Empty = new(new Dictionary<TKey, TValue>());

    /// <summary>
    /// 
    /// </summary>
    private readonly KeyValuePair<TKey, TValue>[]? _array = dictionary?.ToArray();

    /// <summary>
    /// 
    /// </summary>
    private readonly TKey[]? _keysArray = [.. dictionary?.Keys];

    /// <summary>
    /// 
    /// </summary>
    private readonly TValue[]? _valuesArray = [.. dictionary?.Values];

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int Count => _array?.Length ?? 0;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dictionary"></param>
    /// <returns></returns>
    public bool Equals(EquatableDictionary<TKey, TValue> dictionary) => KeysAsSpan().SequenceEqual(dictionary.KeysAsSpan()) &&
                                                                        ValuesAsSpan().SequenceEqual(dictionary.ValuesAsSpan());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is EquatableDictionary<TKey, TValue> array && this.Equals(array);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        if (_array is not KeyValuePair<TKey, TValue>[] array)
        {
            return 0;
        }

        HashCode hashCode = default;

        foreach (KeyValuePair<TKey, TValue> item in array)
        {
            hashCode.Add(item.Key);
            hashCode.Add(item.Value);
        }

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<KeyValuePair<TKey, TValue>> AsSpan() => _array.AsSpan();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<TKey> KeysAsSpan() => _keysArray.AsSpan();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<TValue> ValuesAsSpan() => _valuesArray.AsSpan();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public KeyValuePair<TKey, TValue>[]? GetArray() => _array;

    #endregion

    #region Method Declarations - IEnumerator

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => ((IEnumerable<KeyValuePair<TKey, TValue>>)(_array ?? [])).GetEnumerator();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<KeyValuePair<TKey, TValue>>)(_array ?? [])).GetEnumerator();

    #endregion

    #region Operator Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(EquatableDictionary<TKey, TValue> left, EquatableDictionary<TKey, TValue> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(EquatableDictionary<TKey, TValue> left, EquatableDictionary<TKey, TValue> right) => !left.Equals(right);

    #endregion
}