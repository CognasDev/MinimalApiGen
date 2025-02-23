using Samples.MusicCollection.Web.Albums;
using Samples.MusicCollection.Web.Artists;
using Samples.MusicCollection.Web.Components;
using Samples.MusicCollection.Web.Sorting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<IAlbumsApi, AlbumsApi>();
builder.Services.AddSingleton<IArtistsApi, ArtistsApi>();

builder.Services.AddSingleton(typeof(ISortingService<>), typeof(SortingService<>));

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