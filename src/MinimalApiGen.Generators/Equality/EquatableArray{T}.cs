using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MinimalApiGen.Generators.Equality;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="collection"></param>
public readonly struct EquatableArray<T>(IEnumerable<T> collection) : IEquatable<EquatableArray<T>>, IEnumerable<T> where T : IEquatable<T>
{
    #region Field Declarations

    /// <summary>
    /// 
    /// </summary>
    public static readonly EquatableArray<T> Empty = [];

    /// <summary>
    /// 
    /// </summary>
    private readonly T[]? _array = collection is not null ? [.. collection] : [];

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
    /// <param name="array"></param>
    /// <returns></returns>
    public bool Equals(EquatableArray<T> array) => AsSpan().SequenceEqual(array.AsSpan());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is EquatableArray<T> array && this.Equals(array);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        if (_array is not T[] array)
        {
            return 0;
        }

        HashCode hashCode = default;

        foreach (T item in array)
        {
            hashCode.Add(item);
        }

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<T> AsSpan() => _array.AsSpan();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public T[]? GetArray() => _array;

    #endregion

    #region Method Declarations - IEnumerator

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)(_array ?? [])).GetEnumerator();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)(_array ?? [])).GetEnumerator();

    #endregion

    #region Operator Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(EquatableArray<T> left, EquatableArray<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(EquatableArray<T> left, EquatableArray<T> right) => !left.Equals(right);

    #endregion
}