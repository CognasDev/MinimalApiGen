namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IGetServices
{
    #region Method Declarations 

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <returns></returns>
    IWithGetWithServices WithServices<TService1>();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <returns></returns>
    IWithGetWithServices WithServices<TService1, TService2>();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <returns></returns>
    IWithGetWithServices WithServices<TService1, TService2, TService3>();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    /// <returns></returns>
    IWithGetWithServices WithServices<TService1, TService2, TService3, TService4>();

    #endregion
}