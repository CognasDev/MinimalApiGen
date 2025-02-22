using MinimalApiGen.Generators.Abstractions.Command.Delete;

namespace MinimalApiGen.Framework.Generation.Command.Delete;

/// <summary>
/// 
/// </summary>
public sealed class WithDeleteWithKeyedServices : IWithDeleteWithKeyedServices
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
}