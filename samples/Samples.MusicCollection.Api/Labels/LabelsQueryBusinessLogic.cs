using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class LabelsQueryBusinessLogic(ILogger<LabelsQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Label>(logger, databaseService), ILabelsQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Label>> SelectLabelsAsync() => await SelectModelsAsync().ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Label?> SelectLabelAsync(int id)
    {
        ModelParameter<Label> parameter = new(label => label.LabelId, id);
        Label? label = await SelectModelAsync(parameter).ConfigureAwait(false);
        return label;
    }

    #endregion
}