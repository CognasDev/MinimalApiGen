using FluentValidation;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed class ArtistRequestValidator : AbstractValidator<ArtistRequest>
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistRequestValidator"/>
    /// </summary>
    public ArtistRequestValidator()
    {
        RuleFor(artistRequest => artistRequest.Name).NotEmpty().MaximumLength(250);
    }

    #endregion
}