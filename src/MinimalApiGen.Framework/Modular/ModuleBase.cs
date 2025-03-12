using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiGen.Framework.Modular;

/// <summary>
/// 
/// </summary>
public abstract class ModuleBase : IModule
{
    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    protected ModuleBase()
    {
    }

    #endregion

    #region Public Method Declarations  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    public abstract void RegisterDependencies(IServiceCollection serviceCollection);

    #endregion
}