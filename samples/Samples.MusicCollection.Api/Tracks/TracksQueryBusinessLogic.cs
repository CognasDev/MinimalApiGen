using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public sealed class TracksQueryBusinessLogic : ITracksQueryBusinessLogic
{
    #region Field Declarations

    private readonly ILogger<TracksQueryBusinessLogic> _logger;
    private readonly IQueryDatabaseService _databaseService;
    private readonly string _selectStoredProcedure;
    private readonly string _selectByIdStoredProcedure;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="TracksQueryBusinessLogic"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    public TracksQueryBusinessLogic(ILogger<TracksQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        _logger = logger;
        _databaseService = databaseService;

        _selectStoredProcedure = $"[dbo].[{nameof(Track)}s_Select]";
        _selectByIdStoredProcedure = $"[dbo].[{nameof(Track)}s_SelectById]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<Track>> SelectTracksAsync()
    {
        IEnumerable<Track>? selectedModels = await _databaseService.SelectModelsAsync<Track>(_selectStoredProcedure).ConfigureAwait(false);
        return selectedModels ?? throw new NullReferenceException($"Model: {nameof(Track)}, {nameof(_selectStoredProcedure)}: {_selectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Track?> SelectTrackAsync(int id)
    {
        Parameter parameter = new(nameof(Track.TrackId), id);
        Track? selectedModel = await _databaseService.SelectModelAsync<Track>(_selectByIdStoredProcedure, parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}