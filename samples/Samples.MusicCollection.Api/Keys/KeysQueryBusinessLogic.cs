using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="pluralizer"></param>
/// <param name="databaseService"></param>
public sealed class KeysQueryBusinessLogic(ILogger<KeysQueryBusinessLogic> logger, IPluralizer pluralizer, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Key>(logger, pluralizer, databaseService), IKeysQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Key>> SelectKeysAsync() => await SelectModelsAsync().ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Key?> SelectKeyAsync(int id)
    {
        Parameter parameter = new(nameof(Key.KeyId), id);
        Key? selectedModel = await SelectModelAsync(parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}