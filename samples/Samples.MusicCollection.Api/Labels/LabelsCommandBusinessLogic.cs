﻿using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class LabelsCommandBusinessLogic(ILogger<LabelsCommandBusinessLogic> logger, ICommandDatabaseService databaseService)
    : CommandBusinessLogicBase<Label>(logger, databaseService), ILabelsCommandBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Label> InsertLabelAsync(Label album) => await InsertModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Label> UpdateLabelAsync(Label album) => await UpdateModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteLabelAsync(int id)
    {
        ModelParameter<Label> parameter = new(label => label.LabelId, id);
        await DeleteModelAsync(parameter).ConfigureAwait(false);
    }

    #endregion
}