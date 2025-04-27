using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Xunit;

namespace MinimalApiGen.Framework.Testing;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntryPoint"></typeparam>
public abstract class ApiTestBase<TEntryPoint> : IAsyncLifetime, IClassFixture<TestServer<TEntryPoint>> where TEntryPoint : class
{
    #region Field Declarations

    private readonly TestServer<TEntryPoint> _testServer;
    private AsyncServiceScope _scope;
    private bool _disposed = false;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public static JsonSerializerOptions CaseInsensitiveSerializer { get; } = new() { PropertyNameCaseInsensitive = true };

    /// <summary>
    /// 
    /// </summary>
    public IConfiguration Configuration { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public IServiceProvider ServiceProvider { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public HttpClient HttpClient { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    protected string BaseAddress { get; set; } = "https://localhost/";

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="testServer"></param>
    protected ApiTestBase(TestServer<TEntryPoint> testServer) => _testServer = testServer;

    /// <summary>
    /// 
    /// </summary>
    ~ApiTestBase() => DisposeAsyncCore().AsTask().GetAwaiter().GetResult();

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async ValueTask InitializeAsync()
    {
        WebApplicationFactoryClientOptions options = new()
        {
            BaseAddress = new Uri(BaseAddress)
        };
        HttpClient = _testServer.CreateClient(options);
        Configuration = _testServer.Configuration;
        _scope = _testServer.Services.CreateAsyncScope();
        ServiceProvider = _scope.ServiceProvider;
        await Task.CompletedTask;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (!_disposed)
        {
            HttpClient?.Dispose();
            await _scope.DisposeAsync();
            _disposed = true;
        }
    }

    #endregion
}