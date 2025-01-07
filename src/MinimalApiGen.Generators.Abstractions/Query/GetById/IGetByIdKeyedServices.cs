namespace MinimalApiGen.Generators.Abstractions.Query.GetById;

/// <summary>
/// 
/// </summary>
public interface IGetByIdKeyedServices
{
    #region Method Declarations 

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <param name="key1"></param>
    /// <returns></returns>
    IWithGetByIdWithKeyedServices WithKeyedServices<TService1>(string key1);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    IWithGetByIdWithKeyedServices WithKeyedServices<TService1, TService2>(string key1, string key2);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <param name="key3"></param>
    /// <returns></returns>
    IWithGetByIdWithKeyedServices WithKeyedServices<TService1, TService2, TService3>(string key1, string key2, string key3);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <param name="key3"></param>
    /// <param name="key4"></param>
    /// <returns></returns>
    IWithGetByIdWithKeyedServices WithKeyedServices<TService1, TService2, TService3, TService4>(string key1, string key2, string key3, string key4);

    #endregion
}