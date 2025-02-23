using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Shared.Results;

namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
internal interface ICommandResult : IResult
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    string RequestName { get; }

    /// <summary>
    /// 
    /// </summary>
    string RequestFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    bool WithRequestMappingService { get; }

    /// <summary>
    /// 
    /// </summary>
    bool WithResponseMappingService { get; }

    /// <summary>
    /// 
    /// </summary>
    EquatableArray<string> RequestProperties { get; }

    /// <summary>
    /// 
    /// </summary>
    bool WithFluentValidation { get; }

    #endregion
}