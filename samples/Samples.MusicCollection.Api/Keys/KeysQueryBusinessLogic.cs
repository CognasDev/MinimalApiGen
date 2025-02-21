using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
public sealed class KeysQueryBusinessLogic : IKeysQueryBusinessLogic
{
    #region Field Declarations

    private readonly ILogger<KeysQueryBusinessLogic> _logger;
    private readonly IQueryDatabaseService _databaseService;
    private readonly string _selectStoredProcedure;
    private readonly string _selectByIdStoredProcedure;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="KeysQueryBusinessLogic"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    public KeysQueryBusinessLogic(ILogger<KeysQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        _logger = logger;
        _databaseService = databaseService;

        _selectStoredProcedure = $"[dbo].[{nameof(Key)}s_Select]";
        _selectByIdStoredProcedure = $"[dbo].[{nameof(Key)}s_SelectById]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<Key>> SelectKeysAsync()
    {
        IEnumerable<Key>? selectedModels = await _databaseService.SelectModelsAsync<Key>(_selectStoredProcedure).ConfigureAwait(false);
        return selectedModels ?? throw new NullReferenceException($"Model: {nameof(Key)}, {nameof(_selectStoredProcedure)}: {_selectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Key?> SelectKeyAsync(int id)
    {
        Parameter parameter = new(nameof(Key.KeyId), id);
        Key? selectedModel = await _databaseService.SelectModelAsync<Key>(_selectByIdStoredProcedure, parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}