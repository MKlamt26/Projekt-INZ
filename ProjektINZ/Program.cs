using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjektINZ;
using ProjektINZ.Services;
using ProjektINZ.Services.Contracts;
using ProjektKalorie.Services;
using ProjektKalorie.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7237/") });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDayCartService, DayCartService>();
await builder.Build().RunAsync();
