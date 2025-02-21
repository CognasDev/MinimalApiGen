using FluentValidation;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public sealed class AlbumRequestValidator : AbstractValidator<AlbumRequest>
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="AlbumRequestValidator"/>
    /// </summary>
    public AlbumRequestValidator()
    {
        RuleFor(albumRequest => albumRequest.ArtistId).NotEmpty();
        RuleFor(albumRequest => albumRequest.LabelId).NotEmpty();
        RuleFor(albumRequest => albumRequest.Name).NotEmpty().MaximumLength(250);
        RuleFor(albumRequest => albumRequest.ReleaseDate).NotEmpty();
    }

    #endregion
}