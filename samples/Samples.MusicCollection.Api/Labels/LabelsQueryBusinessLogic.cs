using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
public sealed class LabelsQueryBusinessLogic : ILabelsQueryBusinessLogic
{
    #region Field Declarations

    private readonly ILogger<LabelsQueryBusinessLogic> _logger;
    private readonly IQueryDatabaseService _databaseService;
    private readonly string _selectStoredProcedure;
    private readonly string _selectByIdStoredProcedure;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="LabelsQueryBusinessLogic"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    public LabelsQueryBusinessLogic(ILogger<LabelsQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        _logger = logger;
        _databaseService = databaseService;

        _selectStoredProcedure = $"[dbo].[{nameof(Label)}s_Select]";
        _selectByIdStoredProcedure = $"[dbo].[{nameof(Label)}s_SelectById]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<Label>> SelectLabelsAsync()
    {
        IEnumerable<Label>? selectedModels = await _databaseService.SelectModelsAsync<Label>(_selectStoredProcedure).ConfigureAwait(false);
        return selectedModels ?? throw new NullReferenceException($"Model: {nameof(Label)}, {nameof(_selectStoredProcedure)}: {_selectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Label?> SelectLabelAsync(int id)
    {
        Parameter parameter = new(nameof(Label.LabelId), id);
        Label? selectedModel = await _databaseService.SelectModelAsync<Label>(_selectByIdStoredProcedure, parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}