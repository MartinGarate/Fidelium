# Fidelium — README v2

Este README v2 resume y contextualiza los 3 proyectos clave del repositorio: `Backend`, `Service` y `Desktop`. Se centra en la base de datos (infraestructura y flujo con EF Core / Pomelo MySQL) y en el software de escritorio (WinForms .NET 8) como módulos separados y, finalmente, explica su integración.

---

## Resumen de la arquitectura

- `Backend` (API): aplicación Web API en `.NET 8` que expone la lógica de acceso a datos. Usa Entity Framework Core 8 y el proveedor `Pomelo.EntityFrameworkCore.MySql` — por tanto la base de datos objetivo es MySQL/MariaDB.
- `Service` (biblioteca compartida): proyecto de tipo librería con modelos y servicios compartidos por `Backend` y `Desktop`. Centraliza tipos, DTOs y utilidades reutilizables.
- `Desktop` (cliente WinForms): aplicación de escritorio WinForms en `.NET 8 (net8.0-windows)` que consume el `Backend` mediante clases de servicio HTTP (`GenericService<T>`). Incluye un reporte RDLC embebido y un `DataSet` fuertemente tipado.

Esta separación permite desarrollar, desplegar y escalar el API (Backend) de forma independiente del cliente de escritorio.

---

## Detalle: Base de datos (importancia y configuración)

1. Elección tecnológica
   - El `Backend` usa `Microsoft.EntityFrameworkCore` (v8.x) y `Pomelo.EntityFrameworkCore.MySql`.
   - Esto indica diseño para MySQL/MariaDB como motor relacional.

2. Conexión y configuración
   - Espera una `ConnectionString` tipo MySQL (ejemplo):
     `Server=localhost;Port=3306;Database=fidelium;User=root;Password=TuPassword;`.
   - Dicha cadena normalmente se coloca en `appsettings.json` o variables de entorno del proyecto `Backend`.

3. Migrations y mantenimiento del esquema
   - Para crear y aplicar migraciones (desde la raíz del repositorio o la carpeta `Backend`):
     - Instala/usa la CLI de EF (si no está instalada): `dotnet tool install --global dotnet-ef`.
     - Crear una migración: `dotnet ef migrations add NombreMigracion -p Backend -s Backend`.
     - Aplicar migraciones a la base de datos: `dotnet ef database update -p Backend -s Backend`.
   - Alternativa desde dentro del directorio `Backend`:
     - `cd Backend`
     - `dotnet ef migrations add NombreMigracion`
     - `dotnet ef database update`

4. Buenas prácticas para producción
   - Mantener las credenciales fuera del control de versiones (usar secrets, variables de entorno o Azure Key Vault).
   - Probar migraciones en una BD de staging antes de aplicarlas en producción.
   - Hacer backups antes de aplicar cambios en esquemas críticos.

5. Observaciones desde el código existente
   - El uso de EF Core 8 y Pomelo sugiere modelos con atributos/Fluent API en `Backend` (no incluidos aquí). Si el `Service` contiene las entidades compartidas, mantener los tipos sincronizados entre `Service` y `Backend`.

---

## Detalle: Software de escritorio (WinForms) — importancia y particularidades

1. Plataforma y Target
   - `Desktop` tiene `TargetFramework` `net8.0-windows` y la propiedad `UseWindowsForms` habilitada: la app es específica para Windows.
   - Requiere .NET 8 runtime en las máquinas cliente.

2. Paquetes NuGet clave
   - `FirebaseAuthentication.net`: autenticación con Firebase (si se usa en la app).
   - `FontAwesome.Sharp`: iconos vectoriales para controles.
   - `ReportViewerCore.WinForms`: visualización de `RDLC` embebidos.

3. Recursos y datasets
   - Hay un `RDLC` (`Reports/FeedbackPendientesReport.rdlc`) embebido como `EmbeddedResource`. Esto permite imprimir/exportar reportes desde la app sin archivos externos.
   - Existe un `DataSet` fuertemente tipado (`Dataset/FideliumDataset.xsd`) con un `Designer` generado (`FideliumDataset.Designer.cs`). Si cambias el `.xsd`, regenera el diseñador (Visual Studio suele hacerlo automáticamente al abrir el `.xsd` y guardarlo).

4. Dependencia del `Service`
   - `Desktop` referencia `Service.csproj` — usa modelos y servicios compartidos (por ejemplo `GenericService<T>`). Esto asegura que los tipos utilizados por el cliente y el servidor sean compatibles.

5. Consideraciones de UI/UX y robustez
   - La app ya implementa defensas contra fechas inválidas de SQL Server/WinForms (p. ej. límites mínimos de `DateTime`), manejo de estados eliminados (soft delete), y refresco/caché en memoria para mostrar datos offline temporales.
   - RDLC embebido y DataSet: para actualizar un reporte, editar `.rdlc` y/o `.xsd` y confirmar que `EmbeddedResource` está configurado (como está actualmente).

---

## Integración: Cómo trabajan juntos Backend + Service + Desktop

- `Service` actúa como contrato (modelos y servicios comunes). `Backend` implementa acceso a datos con EF Core y expone endpoints REST (o controladores) que devuelven datos con las formas definidas en `Service`.
- `Desktop` consume esos endpoints a través de clientes HTTP genéricos (`GenericService<T>`), usando los tipos del `Service` para serializar/deserializar.
- Flujo típico:
  1. Usuario en `Desktop` inicia acción (listar compras / registrar feedback).
  2. `Desktop` usa `GenericService<CompraServicio>` para llamar al `Backend`.
  3. `Backend` realiza CRUD contra MySQL usando EF Core y devuelve el resultado.
  4. `Desktop` refresca su caché local y actualiza la UI y/o genera reportes RDLC.

---

## Instrucciones rápidas: preparar entorno y ejecutar

1. Requisitos
   - .NET 8 SDK
   - MySQL o MariaDB
   - Visual Studio 2022/2023 o VS Code (para WinForms, Visual Studio es recomendado en Windows)

2. Configurar la base de datos
   - Crear la base de datos destino en el servidor MySQL.
   - Configurar la `ConnectionString` en `Backend/appsettings.json` (o usar variables de entorno). Ejemplo:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Port=3306;Database=fidelium;User=root;Password=MiPass;"
       }
     }
     ```

3. Ejecutar migraciones
   - Desde la raíz o desde `Backend`:
     - `dotnet ef migrations add Inicial` (o nombre que prefieras)
     - `dotnet ef database update`

4. Compilar y ejecutar
   - Backend (API): `dotnet run --project Backend` (o ejecutar desde Visual Studio). Asegúrate que el API quede corriendo y accesible desde el cliente.
   - Desktop (WinForms): abrir la solución en Visual Studio y ejecutar `Desktop` como proyecto de inicio. Alternativamente `dotnet build Desktop` y publicar para una máquina Windows (`dotnet publish -c Release -r win-x64 --self-contained false` si se desea sin runtime embebido).

5. Notas sobre reportes y dataset
   - Si editas el `.xsd`, regenera el `.Designer.cs` en Visual Studio.
   - El `.rdlc` está embebido: al modificarlo, confirmar `Build Action = EmbeddedResource`.

---

## Tareas comunes y comandos de referencia

- Instalar dotnet-ef (si falta): `dotnet tool install --global dotnet-ef`
- Crear migración: `dotnet ef migrations add NombreMigracion -p Backend -s Backend`
- Aplicar migraciones: `dotnet ef database update -p Backend -s Backend`
- Ejecutar Backend: `dotnet run --project Backend`
- Ejecutar Desktop (desde Visual Studio): configurar `Desktop` como proyecto de inicio y Debug/Run.
- Publicar Desktop para distribución (ejemplo de publicación net8 para Windows x64):
  `dotnet publish Desktop -c Release -r win-x64 --self-contained false -o ./publish/desktop`.

---

## Recomendaciones y buenas prácticas

- Mantener `Service` libre de dependencias pesadas: solo modelos, DTOs y contratos. Evita lógica de EF Core dentro del proyecto compartido si `Backend` es responsable del acceso a datos.
- Versionado de API: mantener control de versiones de endpoints en `Backend` si hay múltiples clientes (Desktop, Blazor, móvil).
- Pruebas de integración: crear un entorno de pruebas con MySQL para validar migraciones antes de producción.
- Seguridad: no incluir secretos en el control de versiones; usar `user-secrets`, variables de entorno o servicios de secretos.

---

Si necesitas, puedo:
- Añadir ejemplos concretos de `appsettings.json` y `DbContext` básico compatible con Pomelo/MySQL.
- Generar scripts de migración de ejemplo o un `README` adicional en inglés.

