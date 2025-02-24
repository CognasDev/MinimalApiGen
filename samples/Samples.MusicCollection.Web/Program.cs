using Radzen;
using Samples.MusicCollection.Web.Albums;
using Samples.MusicCollection.Web.Components;
using Samples.MusicCollection.Web.Config;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddRadzenComponents();

builder.BindConfigSection<ApiDetails>();

builder.Services.AddSingleton<IAlbumRepository, AlbumRepository>();

WebApplication webApplication = builder.Build();

// Configure the HTTP request pipeline.
if (!webApplication.Environment.IsDevelopment())
{
    webApplication.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    webApplication.UseHsts();
}

webApplication.UseHttpsRedirection();
webApplication.UseAntiforgery();
webApplication.MapStaticAssets();
webApplication.MapRazorComponents<App>().AddInteractiveServerRenderMode();
webApplication.Run();