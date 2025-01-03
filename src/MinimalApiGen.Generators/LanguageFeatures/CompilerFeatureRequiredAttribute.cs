using System.Diagnostics.CodeAnalysis;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Runtime.CompilerServices;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
[ExcludeFromCodeCoverage]
internal sealed class CompilerFeatureRequiredAttribute(string featureName) : Attribute
{
    #region Field Declarations

    public const string RefStructs = nameof(RefStructs);
    public const string RequiredMembers = nameof(RequiredMembers);

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string FeatureName { get; } = featureName;

    /// <summary>
    /// 
    /// </summary>
    public bool IsOptional { get; init; }

    #endregion
}