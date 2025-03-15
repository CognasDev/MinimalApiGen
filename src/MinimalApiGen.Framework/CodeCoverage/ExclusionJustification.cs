using System.Diagnostics.CodeAnalysis;

namespace MinimalApiGen.Framework.CodeCoverage;

/// <summary>
/// 
/// </summary>
[ExcludeFromCodeCoverage(Justification = ExclusionJustification.NoLogic)]
public static class ExclusionJustification
{
    #region Field Declarations

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public const string Model = "Model has no logic to test";
    public const string NoLogic = "Class has no logic to test";
    public const string Request = "Request has no logic to test";
    public const string Response = "Response has no logic to test";

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    #endregion
}