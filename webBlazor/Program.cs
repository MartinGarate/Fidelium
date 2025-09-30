using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Service.Interfaces;
using Service.Services;
using webBlazor;
using webBlazor.Services;

    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    
    // Configurar componentes ra�z
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
    
    Console.WriteLine("?? Construyendo aplicaci�n...");
    var app = builder.Build();
    
    // Configurar manejo de errores globales
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    
    AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
    {
        logger.LogError(e.ExceptionObject as Exception, "Error no manejado en el dominio de aplicaci�n");
    };

    
    Console.WriteLine("? Iniciando aplicaci�n...");
    await app.RunAsync();


    // En desarrollo, mostrar m�s detalles
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    {
        Console.Error.WriteLine($"Excepci�n completa: {ex}");
    }
    

