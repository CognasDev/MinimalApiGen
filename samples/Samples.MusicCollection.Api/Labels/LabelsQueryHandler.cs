using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class LabelsQueryHandler(ILogger<LabelsQueryHandler> logger, IQueryDatabaseService databaseService)
    : QueryHandlerBase<Label>(logger, databaseService), ILabelsQueryHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Label>> SelectLabelsAsync() => await SelectModelsAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Label?> SelectLabelAsync(int id)
    {
        ModelParameter<Label> parameter = new(label => label.LabelId, id);
        Label? label = await SelectModelAsync(parameter);
        return label;
    }

    #endregion
}