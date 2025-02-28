using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinimalApiGen.Shared.Collections;

/// <summary>
/// 
/// </summary>
public static class CollectionExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// Requires the <c>System.Linq.Async</c> package in anything referencing this shared project.
    /// </remarks>
    public static async Task<FrozenSet<TItem>> ToFrozenSetAsync<TItem>(this IAsyncEnumerable<TItem> collection, CancellationToken cancellationToken = default)
    {
        List<TItem> list = await collection.ToListAsync(cancellationToken).ConfigureAwait(false);
        FrozenSet<TItem> frozenSet = list.ToFrozenSet();
        return frozenSet;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="source"></param>
    /// <param name="dictionary"></param>
    /// <returns></returns>
    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> dictionary)
    {
        foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionary)
        {
            source[keyValuePair.Key] = keyValuePair.Value;
        }
    }

    #endregion

    #region Public Method Declarations - FastForEach

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="action"></param>
    public static void FastForEach<TItem>(this IEnumerable<TItem> collection, Action<TItem> action)
    {
        TItem[] arrayToIterate = GetArrayToIterate(collection);
        ref TItem currentItem = ref MemoryMarshal.GetArrayDataReference(arrayToIterate);
        ref TItem lastItem = ref Unsafe.Add(ref currentItem, arrayToIterate.Length);

        while (Unsafe.IsAddressLessThan(ref currentItem, ref lastItem))
        {
            action(currentItem);
            currentItem = ref Unsafe.Add(ref currentItem, 1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <param name="action"></param>
    public static void FastForEach<TItem>(this IEnumerable<TItem> collection, Func<TItem, bool> predicate, Action<TItem> action)
    {
        TItem[] arrayToIterate = GetArrayToIterate(collection); ;
        ref TItem currentItem = ref MemoryMarshal.GetArrayDataReference(arrayToIterate);
        ref TItem lastItem = ref Unsafe.Add(ref currentItem, arrayToIterate.Length);

        while (Unsafe.IsAddressLessThan(ref currentItem, ref lastItem))
        {
            if (predicate(currentItem))
            {
                action(currentItem);
            }
            currentItem = ref Unsafe.Add(ref currentItem, 1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="task"></param>
    public static async Task FastForEachAsync<TItem>(this IEnumerable<TItem> collection, Func<TItem, Task> task)
    {
        ReadOnlyMemory<TItem> memory = collection.ToImmutableArray().AsMemory();
        int length = memory.Length;
        for (int index = 0; index < length; index++)
        {
            TItem currentItem = memory.Span[index];
            await task(currentItem).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <param name="task"></param>
    /// <returns></returns>
    public static async Task FastForEachAsync<TItem>(this IEnumerable<TItem> collection, Func<TItem, Task<bool>> predicate, Func<TItem, Task> task)
    {
        ReadOnlyMemory<TItem> memory = GetReadOnlyMemory(collection);
        int length = memory.Length;
        for (int index = 0; index < length; index++)
        {
            TItem currentItem = memory.Span[index];
            if (await predicate(currentItem).ConfigureAwait(false))
            {
                await task(currentItem).ConfigureAwait(false);
            }
        }
    }

    #endregion

    #region Public Method Declarations - FastFirst

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static TItem FastFirst<TItem>(this IEnumerable<TItem> collection, Func<TItem, bool> predicate)
    {
        TItem[] arrayToIterate = GetArrayToIterate(collection);
        ref TItem currentItem = ref MemoryMarshal.GetArrayDataReference(arrayToIterate);
        ref TItem lastItem = ref Unsafe.Add(ref currentItem, arrayToIterate.Length);

        while (Unsafe.IsAddressLessThan(ref currentItem, ref lastItem))
        {
            bool success = predicate(currentItem);
            if (success)
            {
                return currentItem;
            }
            currentItem = ref Unsafe.Add(ref currentItem, 1);
        }
        throw new InvalidOperationException("Sequence contains no matching element");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<TItem> FastFirstAsync<TItem>(this IEnumerable<TItem> collection, Func<TItem, Task<bool>> predicate)
    {
        ReadOnlyMemory<TItem> memory = GetReadOnlyMemory(collection);
        int length = memory.Length;
        for (int index = 0; index < length; index++)
        {
            TItem currentItem = memory.Span[index];
            bool success = await predicate(currentItem).ConfigureAwait(false);
            if (success)
            {
                return currentItem;
            }
        }
        throw new InvalidOperationException("Sequence contains no matching element");
    }

    #endregion

    #region Public Method Declarations - FastFirstOrDefault

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    public static TItem? FastFirstOrDefault<TItem>(this IEnumerable<TItem> collection, Func<TItem, bool> predicate)
    {
        TItem[] arrayToIterate = GetArrayToIterate(collection);
        ref TItem currentItem = ref MemoryMarshal.GetArrayDataReference(arrayToIterate);
        ref TItem lastItem = ref Unsafe.Add(ref currentItem, arrayToIterate.Length);

        while (Unsafe.IsAddressLessThan(ref currentItem, ref lastItem))
        {
            bool success = predicate(currentItem);
            if (success)
            {
                return currentItem;
            }
            currentItem = ref Unsafe.Add(ref currentItem, 1);
        }
        return default;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    public static async Task<TItem?> FastFirstOrDefaultAsync<TItem>(this IEnumerable<TItem> collection, Func<TItem, Task<bool>> predicate)
    {
        ReadOnlyMemory<TItem> memory = GetReadOnlyMemory(collection);
        int length = memory.Length;
        for (int index = 0; index < length; index++)
        {
            TItem currentItem = memory.Span[index];
            bool success = await predicate(currentItem).ConfigureAwait(false);
            if (success)
            {
                return currentItem;
            }
        }
        return default;
    }

    #endregion

    #region Public Method Declarations - FastSingle

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static TItem FastSingle<TItem>(this IEnumerable<TItem> collection, Func<TItem, bool> predicate)
    {
        TItem[] arrayToIterate = GetArrayToIterate(collection);
        ref TItem currentItem = ref MemoryMarshal.GetArrayDataReference(arrayToIterate);
        ref TItem lastItem = ref Unsafe.Add(ref currentItem, arrayToIterate.Length);
        TItem? result = default;
        bool matchFound = false;
        while (Unsafe.IsAddressLessThan(ref currentItem, ref lastItem))
        {
            bool success = predicate(currentItem);
            if (success)
            {
                if (matchFound)
                {
                    throw new InvalidOperationException("Sequence contains more than one matching element");
                }
                result = currentItem;
                matchFound = true;
            }
            currentItem = ref Unsafe.Add(ref currentItem, 1);
        }
        return matchFound ? result! : throw new InvalidOperationException("Sequence contains no matching element");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<TItem?> FastSingleAsync<TItem>(this IEnumerable<TItem> collection, Func<TItem, Task<bool>> predicate)
    {
        ReadOnlyMemory<TItem> memory = GetReadOnlyMemory(collection);
        int length = memory.Length;
        TItem? result = default;
        bool matchFound = false;
        for (int index = 0; index < length; index++)
        {
            TItem currentItem = memory.Span[index];
            bool success = await predicate(currentItem).ConfigureAwait(false);
            if (success)
            {
                if (matchFound)
                {
                    throw new InvalidOperationException("Sequence contains more than one matching element");
                }
                result = currentItem;
                matchFound = true;
            }
        }
        return matchFound ? result! : throw new InvalidOperationException("Sequence contains no matching element");
    }

    #endregion

    #region Public Method Declarations - FastSingleOrDefault

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static TItem? FastSingleOrDefault<TItem>(this IEnumerable<TItem> collection, Func<TItem, bool> predicate)
    {
        TItem[] arrayToIterate = GetArrayToIterate(collection);
        ref TItem currentItem = ref MemoryMarshal.GetArrayDataReference(arrayToIterate);
        ref TItem lastItem = ref Unsafe.Add(ref currentItem, arrayToIterate.Length);
        TItem? result = default;
        bool matchFound = false;
        while (Unsafe.IsAddressLessThan(ref currentItem, ref lastItem))
        {
            bool success = predicate(currentItem);
            if (success)
            {
                if (matchFound)
                {
                    throw new InvalidOperationException("Sequence contains more than one matching element");
                }
                result = currentItem;
                matchFound = true;
            }
            currentItem = ref Unsafe.Add(ref currentItem, 1);
        }
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<TItem?> FastSingleOrDefaultAsync<TItem>(this IEnumerable<TItem> collection, Func<TItem, Task<bool>> predicate)
    {
        ReadOnlyMemory<TItem> memory = GetReadOnlyMemory(collection);
        int length = memory.Length;
        TItem? result = default;
        bool matchFound = false;
        for (int index = 0; index < length; index++)
        {
            TItem currentItem = memory.Span[index];
            bool success = await predicate(currentItem).ConfigureAwait(false);
            if (success)
            {
                if (matchFound)
                {
                    throw new InvalidOperationException("Sequence contains more than one matching element");
                }
                result = currentItem;
                matchFound = true;
            }
        }
        return result;
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    private static TItem[] GetArrayToIterate<TItem>(IEnumerable<TItem> collection)
    {
        ImmutableArray<TItem> immutableArray = [.. collection];
        TItem[] arrayToIterate = [.. immutableArray];
        return arrayToIterate;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    private static ReadOnlyMemory<TItem> GetReadOnlyMemory<TItem>(IEnumerable<TItem> collection)
    {
        ReadOnlyMemory<TItem> memory = collection.ToImmutableArray().AsMemory();
        return memory;
    }

    #endregion
}