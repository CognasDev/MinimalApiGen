using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="pluralizer"></param>
/// <param name="databaseService"></param>
public sealed class TracksQueryBusinessLogic(ILogger<TracksQueryBusinessLogic> logger, IPluralizer pluralizer, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Track>(logger, pluralizer, databaseService), ITracksQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Track>> SelectTracksAsync() => await SelectModelsAsync().ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Track?> SelectTrackAsync(int id)
    {
        ModelParameter<Track> parameter = new(track => track.TrackId, id);
        Track? selectedModel = await SelectModelAsync(parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}