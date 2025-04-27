using MinimalApiGen.Generators.Generation.Shared.Results;

namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
internal sealed record CommandIntermediateResult : IntermediateResultBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public WithRequestResult RequestResult { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithRequestMappingService { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithFluentValidation { get; set; }

    #endregion
}