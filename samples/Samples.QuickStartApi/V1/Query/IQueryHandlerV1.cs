﻿using Samples.QuickStartApi.V1.Model;

namespace Samples.QuickStartApi.V1.Query;

/// <summary>
/// 
/// </summary>
public interface IQueryHandlerV1
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SampleModel>> GetModelsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SampleModel> GetModelByIdAsync(int id, CancellationToken cancellationToken);

    #endregion
}