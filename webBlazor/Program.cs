using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Service.Interfaces;
using Service.Services;
using webBlazor;
using webBlazor.Services;

try
{
    Console.WriteLine("?? Iniciando aplicación Blazor WebAssembly...");
    
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    
    // Configurar componentes raíz
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    // Configurar servicios
    Console.WriteLine("?? Configurando servicios...");
    
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
    builder.Services.AddScoped<FirebaseAuthService>();
    builder.Services.AddSingleton<AuthenticationStateService>();
    builder.Services.AddSweetAlert2();

    // Configurar logging
    builder.Logging.SetMinimumLevel(LogLevel.Information);
    
    Console.WriteLine("?? Construyendo aplicación...");
    var app = builder.Build();
    
    // Configurar manejo de errores globales
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    
    AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
    {
        logger.LogError(e.ExceptionObject as Exception, "Error no manejado en el dominio de aplicación");
    };

    TaskScheduler.UnobservedTaskException += (sender, e) =>
    {
        logger.LogError(e.Exception, "Excepción no observada en tarea");
        e.SetObserved(); // Marcar como observada para evitar crash
    };

    Console.WriteLine("? Iniciando aplicación...");
    await app.RunAsync();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"? Error crítico iniciando la aplicación: {ex.Message}");
    Console.Error.WriteLine($"Stack trace: {ex.StackTrace}");
    
    // En desarrollo, mostrar más detalles
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    {
        Console.Error.WriteLine($"Excepción completa: {ex}");
    }
    
    throw; // Re-lanzar para que se maneje apropiadamente
}