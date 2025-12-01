using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Service.Interfaces;
using Service.Services;
using System.Net.NetworkInformation;
using webBlazor;
using webBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configurar componentes ra�z
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); // Configurar HttpClient
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<FirebaseAuthService>(); // Servicio de autenticación Firebase
builder.Services.AddScoped<LoadingService>(); // Servicio global de loading
builder.Services.AddSweetAlert2();
await builder.Build().RunAsync();
