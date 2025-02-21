using FluentValidation;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
public sealed class LabelRequestValidator : AbstractValidator<LabelRequest>
{
    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="LabelRequestValidator"/>
    /// </summary>
    public LabelRequestValidator()
    {
        RuleFor(labelRequest => labelRequest.Name).NotEmpty().MaximumLength(250);
    }

    #endregion
}