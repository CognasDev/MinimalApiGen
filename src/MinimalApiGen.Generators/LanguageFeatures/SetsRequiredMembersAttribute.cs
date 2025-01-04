#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Diagnostics.CodeAnalysis;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
[ExcludeFromCodeCoverage]
internal sealed class SetsRequiredMembersAttribute : Attribute
{
}