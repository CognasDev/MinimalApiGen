using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="pluralizer"></param>
/// <param name="databaseService"></param>
public sealed class LabelsQueryBusinessLogic(ILogger<LabelsQueryBusinessLogic> logger, IPluralizer pluralizer, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Label>(logger, pluralizer, databaseService), ILabelsQueryBusinessLogic
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
        Parameter parameter = new(nameof(Label.LabelId), id);
        Label? selectedModel = await SelectModelAsync(parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}