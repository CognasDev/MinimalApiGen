using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class KeysQueryHandler(ILogger<KeysQueryHandler> logger, IQueryDatabaseService databaseService)
    : QueryHandlerBase<Key>(logger, databaseService), IKeysQueryHandler
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