using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed class ArtistsQueryBusinessLogic : IArtistsQueryBusinessLogic
{
    #region Field Declarations

    private readonly ILogger<ArtistsQueryBusinessLogic> _logger;
    private readonly IQueryDatabaseService _databaseService;
    private readonly string _selectStoredProcedure;
    private readonly string _selectByIdStoredProcedure;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistsQueryBusinessLogic"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    public ArtistsQueryBusinessLogic(ILogger<ArtistsQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        _logger = logger;
        _databaseService = databaseService;

        _selectStoredProcedure = $"[dbo].[{nameof(Artist)}s_Select]";
        _selectByIdStoredProcedure = $"[dbo].[{nameof(Artist)}s_SelectById]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<Artist>> SelectArtistsAsync()
    {
        IEnumerable<Artist>? selectedModels = await _databaseService.SelectModelsAsync<Artist>(_selectStoredProcedure).ConfigureAwait(false);
        return selectedModels ?? throw new NullReferenceException($"Model: {nameof(Artist)}, {nameof(_selectStoredProcedure)}: {_selectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Artist?> SelectArtistAsync(int id)
    {
        Parameter parameter = new(nameof(Artist.ArtistId), id);
        Artist? selectedModel = await _databaseService.SelectModelAsync<Artist>(_selectByIdStoredProcedure, parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}