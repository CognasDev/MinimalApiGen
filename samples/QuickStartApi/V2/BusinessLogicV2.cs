﻿using QuickStartApi.Model;
using QuickStartApi.Services;

namespace QuickStartApi.V2;

/// <summary>
/// 
/// </summary>
public sealed class BusinessLogicV2 : IBusinessLogicV2
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService1"></param>
    /// <param name="sampleService2"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SampleModel>> GetModelsV2Async(SampleService1 sampleService1,
                                                                     SampleKeyedService sampleService2,
                                                                     CancellationToken cancellationToken)
    {
        SampleModel sampleModel1 = new() { Id = 1, Name = "SampleModel1 - BusinessLogicV2" };
        SampleModel sampleModel2 = new() { Id = 2, Name = "SampleModel2 - BusinessLogicV2" };
        List<SampleModel> sampleModels = [sampleModel1, sampleModel2];
        return await Task.FromResult<IEnumerable<SampleModel>>(sampleModels).ConfigureAwait(false);
    }

    #endregion
}