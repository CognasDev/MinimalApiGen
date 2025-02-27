﻿using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public sealed class AlbumsQueryBusinessLogic : QueryBusinessLogicBase<Album>, IAlbumsQueryBusinessLogic
{
    #region Field Declarations

    private readonly string _selectByArtistIdStoredProcedure;
    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="pluralizer"></param>
    /// <param name="databaseService"></param>
    public AlbumsQueryBusinessLogic(ILogger<AlbumsQueryBusinessLogic> logger, IPluralizer pluralizer, IQueryDatabaseService databaseService)
        : base(logger, pluralizer, databaseService)
        => _selectByArtistIdStoredProcedure = $"[dbo].[{PluralModelName}_SelectByArtistId]";

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Album>> SelectAlbumsAsync(int? artistId)
    {
        IEnumerable<Album> selectedModels;
        if (artistId.HasValue)
        {
            ModelParameter<Album> artistIdParameter = new(album => album.ArtistId, artistId);
            selectedModels = await SelectModelsAsync(_selectByArtistIdStoredProcedure, artistIdParameter).ConfigureAwait(false);
        }
        else
        {
            selectedModels = await SelectModelsAsync().ConfigureAwait(false);
        }
        return selectedModels;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Album?> SelectAlbumAsync(int id)
    {
        ModelParameter<Album> parameter = new(album => album.AlbumId, id);
        Album? selectedModel = await SelectModelAsync(parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}