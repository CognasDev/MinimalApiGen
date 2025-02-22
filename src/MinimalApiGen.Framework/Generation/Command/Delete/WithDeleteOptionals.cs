using MinimalApiGen.Generators.Abstractions.Command.Delete;

namespace MinimalApiGen.Framework.Generation.Command.Delete;

/// <summary>
/// 
/// </summary>
public sealed class WithDeleteOptionals : IWithDeleteOptionals
{
    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public IWithDeleteWithServices WithServices<TService1>() => new WithDeleteWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public IWithDeleteWithServices WithServices<TService1, TService2>() => new WithDeleteWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public IWithDeleteWithServices WithServices<TService1, TService2, TService3>() => new WithDeleteWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public IWithDeleteWithServices WithServices<TService1, TService2, TService3, TService4>() => new WithDeleteWithServices();

    #endregion

    #region Public Method Declarations - KeyedServices

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <param name="key1"></param>
    /// <returns></returns>
    public IWithDeleteWithKeyedServices WithKeyedServices<TService1>(string key1) => new WithDeleteWithKeyedServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    public IWithDeleteWithKeyedServices WithKeyedServices<TService1, TService2>(string key1, string key2) => new WithDeleteWithKeyedServices();

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
    public IWithDeleteWithKeyedServices WithKeyedServices<TService1, TService2, TService3>(string key1, string key2, string key3) => new WithDeleteWithKeyedServices();

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
    public IWithDeleteWithKeyedServices WithKeyedServices<TService1, TService2, TService3, TService4>(string key1, string key2, string key3, string key4) => new WithDeleteWithKeyedServices();

    #endregion
}