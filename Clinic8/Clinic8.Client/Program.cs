using Clinic.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using MudBlazor.Services;




var builder = WebAssemblyHostBuilder.CreateDefault(args);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjgwNTQ1N0AzMjMzMmUzMDJlMzBTVEYwanFHZVFuOHo4UmhvSDl6V3p3RU9LWVFONU5tbmlpOFNpODZqNnNZPQ==");
builder.Services.AddSyncfusionBlazor();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddMudServices();


await builder.Build().RunAsync();
