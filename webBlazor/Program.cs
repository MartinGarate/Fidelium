using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Service.Interfaces;
using Service.Services;
using webBlazor;
using webBlazor.Services;

    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    
    // Configurar componentes raíz
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
    builder.Services.AddScoped<FirebaseAuthService>();
    builder.Services.AddSingleton<AuthStateService>();
    builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
