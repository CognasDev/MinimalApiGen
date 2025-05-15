using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace MinimalApiGen.Framework.ApiHandlers;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public abstract class QueryHandlerBase<TModel> where TModel : class
{
    #region Field Declarations

    private readonly IQueryDatabaseService _databaseService;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// 
    /// </summary>
    protected virtual string SelectStoredProcedure { get; }

    /// <summary>
    /// 
    /// </summary>
    protected virtual string SelectByIdStoredProcedure { get; }

    /// <summary>
    /// 
    /// </summary>
    protected string PluralModelName { get; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="QueryHandlerBase{TModel}"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    protected QueryHandlerBase(ILogger logger, IQueryDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        Logger = logger;
        _databaseService = databaseService;

        PluralModelName = Pluralizer.Instance.Pluralize<TModel>();
        SelectStoredProcedure = $"[dbo].[{PluralModelName}_Select]";
        SelectByIdStoredProcedure = $"[dbo].[{PluralModelName}_SelectById]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    protected async Task<IEnumerable<TModel>> SelectModelsAsync(params IParameter[] parameters)
    {
        IEnumerable<TModel>? selectedModels = await _databaseService.SelectModelsAsync<TModel>(SelectStoredProcedure, parameters);
        return selectedModels ?? throw new NullReferenceException($"Model: {typeof(TModel).Name}, {nameof(SelectStoredProcedure)}: {SelectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storedProceduereName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    protected async Task<IEnumerable<TModel>> SelectModelsAsync(string storedProceduereName, params IParameter[] parameters)
    {
        IEnumerable<TModel>? selectedModels = await _databaseService.SelectModelsAsync<TModel>(storedProceduereName, parameters);
        return selectedModels ?? throw new NullReferenceException($"Model: {typeof(TModel).Name}, {nameof(SelectStoredProcedure)}: {SelectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idParameter"></param>
    /// <returns></returns>
    protected async Task<TModel?> SelectModelAsync(IParameter idParameter)
    {
        TModel? selectedModel = await _databaseService.SelectModelAsync<TModel>(SelectByIdStoredProcedure, idParameter);
        return selectedModel;
    }

    #endregion
}