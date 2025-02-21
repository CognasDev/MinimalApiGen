using FluentValidation;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public sealed class TrackRequestValidator : AbstractValidator<TrackRequest>
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="TrackRequestValidator"/>
    /// </summary>
    public TrackRequestValidator()
    {
        RuleFor(trackRequest => trackRequest.AlbumId).NotEmpty();
        RuleFor(trackRequest => trackRequest.GenreId).NotEmpty();
        RuleFor(trackRequest => trackRequest.TrackNumber).NotEmpty();
        RuleFor(trackRequest => trackRequest.Name).NotEmpty().MaximumLength(250);
        RuleFor(trackRequest => trackRequest.Bpm).NotEmpty().GreaterThan(1);
    }

    #endregion
}