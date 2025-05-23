using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace MinimalApiGen.Framework.ApiHandlers;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public abstract class CommandHandlerBase<TModel> where TModel : class
{
    #region Field Declarations

    private readonly ICommandDatabaseService _databaseService;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// 
    /// </summary>
    protected virtual string InsertStoredProcedure { get; }

    /// <summary>
    /// 
    /// </summary>
    protected virtual string UpdateStoredProcedure { get; }

    /// <summary>
    /// 
    /// </summary>
    protected virtual string DeleteStoredProcedure { get; }

    /// <summary>
    /// 
    /// </summary>
    protected string PluralModelName { get; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="CommandHandlerBase{TModel}"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    protected CommandHandlerBase(ILogger logger, ICommandDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        Logger = logger;
        _databaseService = databaseService;

        PluralModelName = Pluralizer.Instance.Pluralize<TModel>();
        InsertStoredProcedure = $"[dbo].[{PluralModelName}_Insert]";
        UpdateStoredProcedure = $"[dbo].[{PluralModelName}_Update]";
        DeleteStoredProcedure = $"[dbo].[{PluralModelName}_Delete]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    protected async Task<TModel> InsertModelAsync(TModel model)
    {
        TModel? insertedModel = await _databaseService.InsertModelAsync(InsertStoredProcedure, model);
        return insertedModel ?? throw new NullReferenceException($"Model: {typeof(TModel).Name}, {nameof(InsertStoredProcedure)}: {InsertStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<TModel> UpdateModelAsync(TModel model)
    {
        TModel? updatedModel = await _databaseService.UpdateModelAsync(UpdateStoredProcedure, model);
        return updatedModel ?? throw new NullReferenceException($"Model: {typeof(TModel).Name}, {nameof(UpdateStoredProcedure)}: {UpdateStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<bool> DeleteModelAsync(params IParameter[] parameters)
    {
        int deleteCount = await _databaseService.DeleteModelAsync(DeleteStoredProcedure, parameters);
        bool result = deleteCount == 1;
        return result;
    }

    #endregion
}