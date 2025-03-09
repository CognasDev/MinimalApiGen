using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class KeysQueryBusinessLogic(ILogger<KeysQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Key>(logger, databaseService), IKeysQueryBusinessLogic
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
        ModelParameter<Key> parameter = new(key => key.KeyId, id);
        Key? key = await SelectModelAsync(parameter).ConfigureAwait(false);
        return key;
    }

    #endregion
}