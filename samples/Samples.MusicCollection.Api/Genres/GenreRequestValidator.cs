using FluentValidation;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public sealed class GenreRequestValidator : AbstractValidator<GenreRequest>
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="GenreRequestValidator"/>
    /// </summary>
    public GenreRequestValidator()
    {
        RuleFor(genreRequest => genreRequest.Name).NotEmpty().MaximumLength(250);
    }

    #endregion
}