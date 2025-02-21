using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Swagger;
using Samples.QuickStartApi.V1.Command;
using Samples.QuickStartApi.V1.Query;
using Samples.QuickStartApi.V1.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddMinimalApiGenFramework();
builder.AddMappingServices();

builder.Services.AddScoped<ICommandBusinessLogicV1, CommandBusinessLogicV1>();
builder.Services.AddScoped<IQueryBusinessLogicV1, QueryBusinessLogicV1>();
builder.Services.AddScoped<SampleService1>();
builder.Services.AddScoped<SampleService2>();

WebApplication webApplication = builder.Build();
webApplication.UseRouteMaps();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.AddSwagger();
}

webApplication.UseMinimalApiGenFramework();
webApplication.UseHttpsRedirection();
webApplication.Run();