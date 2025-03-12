using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Shared.Collections;
using System.Collections.Frozen;
using System.Reflection;

namespace MinimalApiGen.Framework.Modular;

/// <summary>
/// 
/// </summary>
public static class ModuleLoader
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="name"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void AddModules(this IServiceCollection serviceCollection, string name)
    {
        Type abstraction = typeof(IModule);
        FrozenSet<Assembly> assemblies = GetDomainAssemblies(name);
        ReadOnlySpan<Type> moduleTypes = assemblies.SelectMany(assembly => assembly.GetTypes())
                                                   .Where(type => abstraction.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                                                   .ToArray();

        foreach (Type moduleType in moduleTypes)
        {
            object instance = Activator.CreateInstance(moduleType) ?? throw new InvalidOperationException($"{moduleType.FullName} - Module instance could not be created.");
            IModule module = (IModule)instance;
            module.RegisterDependencies(serviceCollection);
        }
    }

    #endregion


    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static FrozenSet<Assembly> GetDomainAssemblies(string name)
    {
        IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies();
        List<Assembly> moduleAssemblies = [];

        assemblies.FastForEach(assembly =>
        {
            if (assembly.FullName!.Contains(name))
            {
                moduleAssemblies.Add(assembly);
            }
        });

        FrozenSet<Assembly> frozenSet = moduleAssemblies.ToFrozenSet();
        return frozenSet;
    }

    #endregion
}