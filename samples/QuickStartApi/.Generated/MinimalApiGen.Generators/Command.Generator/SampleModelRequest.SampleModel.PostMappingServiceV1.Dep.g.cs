using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public partial class MappingServicesDependencies
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    partial void UseMappingServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMappingService<QuickStartApi.V1.Model.SampleModelRequest, QuickStartApi.V1.Model.SampleModel>, QuickStartApi.V1.Command.PostSampleModelRequestToSampleModelMappingServiceV1>();
    }
}