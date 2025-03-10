using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MinimalApiGen.Framework.Testing;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntryPoint"></typeparam>
public class TestServer<TEntryPoint>  : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IConfiguration Configuration { get; private set; } = default!;

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    protected virtual void ConfigureTestServices(IServiceCollection services)
    {
        return;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddLogging(loggingBuilder =>
            {
                LoggerConfiguration loggerConfiguration = new();
                loggerConfiguration.Enrich.FromLogContext().WriteTo
                                                           .File
                                                           (
                                                                "../../../testing.log",
                                                                rollingInterval: RollingInterval.Day
                                                           );
                Serilog.ILogger logger = loggerConfiguration.CreateLogger();
                loggingBuilder.ClearProviders().AddSerilog(logger);
            });
            services.RemoveAll<IHttpClientFactory>();
            services.AddSingleton<IHttpClientFactory>(new TestHttpClientFactory<TEntryPoint>(this));
            ConfigureTestServices(services);
        });

        builder.ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.integrationtests.json");
            Configuration = configurationBuilder.Build();
        });
    }

    #endregion

}