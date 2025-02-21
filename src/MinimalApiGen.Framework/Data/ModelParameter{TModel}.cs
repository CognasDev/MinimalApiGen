using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public sealed class ModelParameter<TModel> : IModelParameter<TModel> where TModel : class
{
    #region Field Declarations

    private static readonly ConcurrentDictionary<string, Delegate> _delegateCache = new();
    private readonly string _cacheKey;
    private object? _value;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public Expression<Func<TModel, object?>> PropertyExpression { get; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 
    /// </summary>
    public object? Value
    {
        get => _value;
        set => _value = value is string ? value.ToString()?.ToLowerInvariant() : value;
    }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="ModelParameter{TModel}"/>
    /// </summary>
    /// <param name="propertyExpression"></param>
    /// <param name="value"></param>
    public ModelParameter(Expression<Func<TModel, object?>> propertyExpression, object? value)
    {
        PropertyExpression = propertyExpression;
        Name = GetPropertyName();
        Value = value;
        _cacheKey = $"{typeof(TModel).Name}.{Name}";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Func<TModel, object?> GetFunction()
    {
        Delegate cachedDelegate = _delegateCache.GetOrAdd(_cacheKey, key => PropertyExpression.Compile());
        Func<TModel, object?> func = (Func<TModel, object?>)cachedDelegate;
        return func;
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string GetPropertyName()
    {
        LambdaExpression lambdaExpression = PropertyExpression;
        MemberExpression memberExpression = lambdaExpression.Body is UnaryExpression unaryExpression ?
                                                (MemberExpression)unaryExpression.Operand :
                                                (MemberExpression)lambdaExpression.Body;
        return memberExpression.Member.Name;
    }

    #endregion
}