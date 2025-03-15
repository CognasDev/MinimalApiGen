using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using Samples.QuickStartApi.V1.Command;
using Samples.QuickStartApi.V1.Query;
using Samples.QuickStartApi.V1.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddMinimalApiFramework();

builder.Services.AddScoped<ICommandHandlerV1, CommandHandlerV1>();
builder.Services.AddScoped<IQueryHandlerV1, QueryHandlerV1>();
builder.Services.AddScoped<SampleService1>();
builder.Services.AddScoped<SampleService2>();

WebApplication webApplication = builder.Build();
webApplication.UseMinimalApiFramework();
webApplication.Run();