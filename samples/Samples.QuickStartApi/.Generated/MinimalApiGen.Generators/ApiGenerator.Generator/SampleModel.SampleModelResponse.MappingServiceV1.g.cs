﻿using MinimalApiGen.Framework.Mapping;
using SampleModel = Samples.QuickStartApi.V1.Model.SampleModel;
using SampleModelResponse = Samples.QuickStartApi.V1.Model.SampleModelResponse;

namespace Samples.QuickStartApi.V1.Command;

/// <summary>
/// 
/// </summary>
public sealed class PostSampleModelToSampleModelResponseMappingServiceV1 : MappingServiceBase<SampleModel, SampleModelResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override SampleModelResponse Map(SampleModel model)
    {
        SampleModelResponse response = new()
        {
			Id = model.Id,
			Name = model.Name,

        };
        return response;
    }

    #endregion
}