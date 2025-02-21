using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public sealed class GenresQueryBusinessLogic : IGenresQueryBusinessLogic
{
    #region Field Declarations

    private readonly ILogger<GenresQueryBusinessLogic> _logger;
    private readonly IQueryDatabaseService _databaseService;
    private readonly string _selectStoredProcedure;
    private readonly string _selectByIdStoredProcedure;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="GenresQueryBusinessLogic"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    public GenresQueryBusinessLogic(ILogger<GenresQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        _logger = logger;
        _databaseService = databaseService;

        _selectStoredProcedure = $"[dbo].[{nameof(Genre)}s_Select]";
        _selectByIdStoredProcedure = $"[dbo].[{nameof(Genre)}s_SelectById]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<Genre>> SelectGenresAsync()
    {
        IEnumerable<Genre>? selectedModels = await _databaseService.SelectModelsAsync<Genre>(_selectStoredProcedure).ConfigureAwait(false);
        return selectedModels ?? throw new NullReferenceException($"Model: {nameof(Genre)}, {nameof(_selectStoredProcedure)}: {_selectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Genre?> SelectGenreAsync(int id)
    {
        Parameter parameter = new(nameof(Genre.GenreId), id);
        Genre? selectedModel = await _databaseService.SelectModelAsync<Genre>(_selectByIdStoredProcedure, parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}