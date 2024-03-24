using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using wan24.Blazor;
using wan24.Blazor.Demo;
using wan24.Core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Translation.Current = Translation.Dummy;
Logging.Logger = new ConsoleLogger();

BuildTypes build = BuildTypes.Browser;
#if RELEASE
build |= BuildType.Release;
#else
build |= BuildTypes.Debug;
#endif
await BlazorStartup.StartAsync(GuiType.WASM, build, builder.Services).DynamicContext();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
