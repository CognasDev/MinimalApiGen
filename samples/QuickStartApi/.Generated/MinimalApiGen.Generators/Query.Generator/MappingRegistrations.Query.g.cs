using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class QueryMappingRegistrations
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void UseQueryMappingServices(this WebApplicationBuilder builder)
    {
		builder.Services.AddSingleton<IMappingService<QuickStartApi.V1.Model.SampleModel, QuickStartApi.V1.Model.SampleModelResponse>, QuickStartApi.V1.Query.GetSampleModelToSampleModelResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<QuickStartApi.V1.Model.SampleModel, QuickStartApi.V1.Model.SampleModelResponse>, QuickStartApi.V1.Query.GetByIdSampleModelToSampleModelResponseMappingServiceV1>();

    }
}