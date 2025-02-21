using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace MinimalApiGen.Framework.BusinessLogic;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public abstract class QueryBusinessLogicBase<TModel>  where TModel : class
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IQueryDatabaseService DatabaseService { get; }

    /// <summary>
    /// 
    /// </summary>
    public virtual string SelectStoredProcedure { get; }

    /// <summary>
    /// 
    /// </summary>
    public virtual string SelectByIdStoredProcedure { get; }

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="QueryBusinessLogicBase{TModel}"/>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="pluralizer"></param>
    /// <param name="databaseService"></param>
    protected QueryBusinessLogicBase(ILogger logger, IPluralizer pluralizer, IQueryDatabaseService databaseService)
    {
        ArgumentNullException.ThrowIfNull(pluralizer, nameof(pluralizer));
        ArgumentNullException.ThrowIfNull(databaseService, nameof(databaseService));

        DatabaseService = databaseService;

        string pluralModelName = pluralizer.Pluralize(typeof(TModel).Name);
        SelectStoredProcedure = $"[dbo].[{pluralModelName}_Select]";
        SelectByIdStoredProcedure = $"[dbo].[{pluralModelName}_SelectById]";
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<TModel>> SelectModelsAsync()
    {
        IEnumerable<TModel>? selectedModels = await DatabaseService.SelectModelsAsync<TModel>(SelectStoredProcedure).ConfigureAwait(false);
        return selectedModels ?? throw new NullReferenceException($"Model: {typeof(TModel).Name}, {nameof(SelectStoredProcedure)}: {SelectStoredProcedure}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idParameter"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<TModel?> SelectModelAsync(IParameter idParameter)
    {
        TModel? selectedModel = await DatabaseService.SelectModelAsync<TModel>(SelectByIdStoredProcedure, idParameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}