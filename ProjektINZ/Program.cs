using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjektINZ;
using ProjektINZ.Authorization;
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
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ITreningCartService, TreningCartService>();



await builder.Build().RunAsync();
