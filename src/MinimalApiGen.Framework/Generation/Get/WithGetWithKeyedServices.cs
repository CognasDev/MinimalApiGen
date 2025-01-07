namespace MinimalApiGen.Framework.Generation.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithKeyedServices
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public WithGetWithResponse WithResponse<TResponse>() => new();

    #endregion

    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public WithGetWithServices WithServices<TService1>() => new();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public WithGetWithServices WithServices<TService1, TService2>() => new();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public WithGetWithServices WithServices<TService1, TService2, TService3>() => new();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public WithGetWithServices WithServices<TService1, TService2, TService3, TService4>() => new();

    #endregion

}