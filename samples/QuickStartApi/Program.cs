using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Mapping;
using MinimalApiGen.Framework.Swagger;
using QuickStartApi.Model;
using QuickStartApi.Services;
using QuickStartApi.V1;
using QuickStartApi.V2;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddMinimalApiGenFramework();
builder.Services.AddSingleton<IMappingService<SampleModel, SampleModelResponse>, SampleModelToSampleModelResponseMappingService>();
builder.Services.AddScoped<IBusinessLogicV1, BusinessLogicV1>();
builder.Services.AddScoped<IBusinessLogicV2, BusinessLogicV2>();
builder.Services.AddScoped<SampleService1>();
builder.Services.AddScoped<SampleService2>();

WebApplication webApplication = builder.Build();
webApplication.UseMinimalApiGenEndpointRouteMaps();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.AddSwagger();
}

webApplication.UseMinimalApiGenFramework();
webApplication.UseHttpsRedirection();
webApplication.Run();