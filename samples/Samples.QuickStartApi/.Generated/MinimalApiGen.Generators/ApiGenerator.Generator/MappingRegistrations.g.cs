using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class MappingRegistrations
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMappingServices(this WebApplicationBuilder builder)
    {
		builder.Services.AddSingleton<IMappingService<Samples.QuickStartApi.V1.Model.SampleModel, Samples.QuickStartApi.V1.Model.SampleModelResponse>, Samples.QuickStartApi.V1.Command.PostSampleModelToSampleModelResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<Samples.QuickStartApi.V1.Model.SampleModelRequest, Samples.QuickStartApi.V1.Model.SampleModel>, Samples.QuickStartApi.V1.Command.PostSampleModelRequestToSampleModelMappingServiceV1>();

    }
}