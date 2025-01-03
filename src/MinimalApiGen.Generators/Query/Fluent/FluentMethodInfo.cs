using MinimalApiGen.Generators.Query.Invocation;

namespace MinimalApiGen.Generators.Query.Fluent;

/// <summary>
/// 
/// </summary>
/// <param name="fullyQualifiedName"></param>
/// <param name="invocation"></param>
/// <param name="isGeneric"></param>
internal readonly struct FluentMethodInfo(string fullyQualifiedName, InvocationInfo invocation, bool isGeneric)
{
    #region Field Declarations

    /// <summary>
    /// 
    /// </summary>
    public readonly string FullyQualifiedName = fullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public readonly InvocationInfo Invocation = invocation;

    /// <summary>
    /// 
    /// </summary>
    public readonly bool IsGeneric = isGeneric;

    #endregion
}