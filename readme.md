# 🎯 Fidelium - Sistema Integral de Fidelización de Clientes

![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)
![C#](https://img.shields.io/badge/C%23-12.0-purple.svg)
![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-green.svg)
![WinForms](https://img.shields.io/badge/WinForms-Desktop-orange.svg)
![MAUI](https://img.shields.io/badge/MAUI-Mobile-red.svg)
![Firebase](https://img.shields.io/badge/Firebase-Auth-yellow.svg)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-lightblue.svg)

## 📋 Descripción

**Fidelium** es un sistema empresarial multiplataforma diseñado para optimizar la gestión de clientes, automatizar seguimientos post-venta y centralizar la información de servicios mediante notificaciones inteligentes. El sistema permite mejorar la fidelización del cliente a través de recordatorios automatizados y feedback estructurado.

### 🎯 Objetivos del Sistema

- **Fidelización Inteligente**: Automatización de seguimientos mediante notificaciones programables
- **Centralización de Datos**: Un único punto de verdad para toda la información de clientes
- **Multiplataforma**: Acceso desde Desktop, Web y Mobile según el rol del usuario
- **Auditoría Completa**: Sistema de soft delete para preservar el historial
- **Feedback Estructurado**: Recolección y análisis de experiencias del cliente

---

## 🏗️ Arquitectura del Sistema

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   WinForms      │    │   Blazor WASM   │    │   .NET MAUI     │
│  (Escritorio)   │    │     (Web)       │    │   (Mobile)      │
│                 │    │                 │    │                 │
│ • Administrador │    │ • Empleado      │    │ • Empleado      │
│ • CRUD Completo │    │ • Registro      │    │ • Consulta      │
│ • Reportes      │    │ • Feedback      │    │ • Feedback      │
│ • Papelera      │    │ • Notificaciones│    │ • Móvil         │
└─────────┬───────┘    └─────────┬───────┘    └─────────┬───────┘
          │                      │                      │
          │                      │                      │
          └──────────────────────┼──────────────────────┘
                                 │
                         ┌───────▼───────┐
                         │   Backend API  │
                         │   (.NET 8)     │
                         │                │
                         │ • Controllers  │
                         │ • Services     │
                         │ • Entity FW    │
                         └───────┬───────┘
                                 │
                    ┌────────────▼────────────┐
                    │      Bases de Datos     │
                    │                         │
                    │ ┌─────────────────────┐ │
                    │ │   SQL Server        │ │
                    │ │ • Usuarios          │ │
                    │ │ • Clientes          │ │
                    │ │ • ComprasServicios  │ │
                    │ │ • Notificaciones    │ │
                    │ └─────────────────────┘ │
                    │                         │
                    │ ┌─────────────────────┐ │
                    │ │   Firebase Auth     │ │
                    │ │ • Autenticación     │ │
                    │ │ • JWT Tokens        │ │
                    │ │ • OAuth Google      │ │
                    │ └─────────────────────┘ │
                    └─────────────────────────┘
```

---

## 🚀 Tecnologías y Stack Tecnológico

### Backend
- **.NET 8** - Framework principal
- **Entity Framework Core** - ORM para base de datos
- **SQL Server** - Base de datos principal
- **ASP.NET Core Web API** - API RESTful
- **Firebase Authentication** - Sistema de autenticación

### Frontend
- **WinForms** - Aplicación de escritorio (Administradores)
- **Blazor WebAssembly** - Aplicación web (Empleados)
- **MAUI** - Aplicación móvil multiplataforma (Empleados móviles)

### Servicios y Utilidades
- **Generic Services** - Servicios reutilizables para CRUD
- **Soft Delete Pattern** - Eliminación lógica de registros
- **Auto-calculated Notifications** - Notificaciones automáticas

---

## 🏢 Estructura del Proyecto

```
Fidelium/
├── Backend/                    # API Backend (.NET 8)
│   ├── Controllers/           # Controladores REST
│   │   ├── ClientesController.cs
│   │   ├── ComprasServiciosController.cs
│   │   ├── NotificacionesController.cs
│   │   └── UsuariosController.cs
│   ├── DataContext/           # Entity Framework Context
│   │   └── FideliumContext.cs
│   └── Program.cs             # Configuración de la API
│
├── Service/                   # Modelos y Servicios Compartidos
│   ├── Models/               # Modelos de datos
│   │   ├── Cliente.cs
│   │   ├── CompraServicio.cs
│   │   ├── Notificacion.cs
│   │   ├── Usuario.cs
│   │   └── Login/
│   │       └── FirebaseUser.cs
│   ├── Enums/               # Enumeraciones
│   │   ├── EstadoNotificacion.cs
│   │   └── TipoUsuarioEnum.cs
│   ├── Services/            # Servicios genéricos
│   └── Utils/               # Utilidades y endpoints
│       └── ApiEndpoints.cs
│
├── Desktop/                  # Aplicación WinForms
│   ├── Views/               # Formularios Windows
│   │   ├── LoginView.cs
│   │   ├── MenuPrincipalView.cs
│   │   ├── UsuariosView.cs
│   │   └── SeguimientoVentasView.cs
│   └── Utils/               # Utilidades de escritorio
│
├── webBlazor/               # Aplicación Web Blazor
│   ├── Pages/              # Páginas Blazor
│   │   ├── Login/
│   │   ├── Compras/
│   │   └── Reviews/
│   ├── Services/           # Servicios específicos de Blazor
│   └── wwwroot/           # Archivos estáticos
│
├── TestFidelium/           # Proyecto de pruebas
└── README.md              # Este archivo
```

---

## 📊 Modelo de Datos

### Entidades Principales

#### 👤 Usuario
```csharp
public class Usuario
{
    public int ID { get; set; }
    public string? DNI { get; set; }
    public string Nombre { get; set; }
    public string? Email { get; set; }
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeleteDate { get; set; }
}
```

#### 🤝 Cliente
```csharp
public class Cliente
{
    public int ID { get; set; }
    public int UsuarioID { get; set; }
    public Usuario? Usuario { get; set; }
    public string? Telefono { get; set; }
    public string? Instagram { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeleteDate { get; set; }
}
```

#### 🛍️ CompraServicio
```csharp
public class CompraServicio
{
    public int ID { get; set; }
    public int ClienteID { get; set; }
    public Cliente? Cliente { get; set; }
    public string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string NotasVentaInternas { get; set; }
    public DateTime FechaCompra { get; set; }
    public DateTime FechaRecordatorio { get; set; }
    public bool FeedbackRecibido { get; set; }
    public string ComentarioFeedback { get; set; }
    public int EmpleadoID { get; set; }
    public Usuario? Empleado { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

#### 🔔 Notificación
```csharp
public class Notificacion
{
    public int ID { get; set; }
    public int CompraServicioID { get; set; }
    public CompraServicio? CompraServicio { get; set; }
    public EstadoNotificacion Estado { get; set; }
    public DateTime FechaGenerada { get; set; }
    public bool IsDeleted { get; set; }
}
```

### Diagrama de Relaciones

```
                 ┌─────────────┐
                 │   Usuario   │
                 │ ----------- │
                 │ + ID (PK)   │
                 │ + DNI       │
                 │ + Nombre    │
                 │ + Email     │
                 │ + Tipo      │
                 └──────┬──────┘
                        │
                        │ 1:1
                        ▼
                 ┌─────────────┐
                 │   Cliente   │
                 │ ----------- │
                 │ + ID (PK)   │
                 │ + UsuarioID │◄──┐
                 │ + Telefono  │   │
                 │ + Instagram │   │ 1:N
                 └──────┬──────┘   │
                        │          │
                        │ 1:N      │
                        ▼          │
              ┌──────────────────┐ │
              │  CompraServicio  │ │
              │ ---------------- │ │
              │ + ID (PK)        │ │
              │ + ClienteID (FK) │─┘
              │ + EmpleadoID(FK) │─┐
              │ + Nombre         │ │ N:1
              │ + Descripcion    │ │
              │ + FechaCompra    │ │
              │ + Feedback...    │ │
              └─────────┬────────┘ │
                        │          │
                        │ 1:1      │
                        ▼          │
                ┌─────────────┐    │
                │Notificacion │    │
                │ ----------- │    │
                │ + ID (PK)   │    │
                │ + CompraID  │    │
                │ + Estado    │    │
                │ + Fecha...  │    │
                └─────────────┘    │
                                   │
                            ┌──────▼──────┐
                            │   Usuario   │
                            │ (Empleado)  │
                            │ ----------- │
                            │ + ID (PK)   │
                            │ + Nombre    │
                            │ + Tipo =    │
                            │   Empleado/ │
                            │   Admin     │
                            └─────────────┘
```

---

## 🔐 Sistema de Autenticación

### Tipos de Usuario

| Tipo | Descripción | Plataforma Principal | Permisos |
|------|-------------|---------------------|----------|
| **Administrador** | Control total del sistema | Desktop (WinForms) | CRUD completo, reportes, papelera |
| **Empleado** | Gestión operativa | Web (Blazor) | Registro de ventas, feedback, consultas |
| **Cliente** | Usuario final | Web (Blazor) | Consulta de compras propias, feedback |

### Autenticación Firebase

- **Email + Password**: Registro y login tradicional
- **OAuth Google**: Autenticación social
- **Email Verification**: Verificación obligatoria de correo
- **Password Reset**: Recuperación de contraseña

---

## 🎨 Interfaces de Usuario

### 💻 Desktop (WinForms) - Administradores
- **Vista Principal**: Dashboard con resumen de datos
- **Gestión de Usuarios**: CRUD completo de usuarios y roles
- **Seguimiento de Ventas**: Gestión completa de compras/servicios
- **Notificaciones**: Sistema de seguimiento automatizado
- **Papelera**: Recuperación de registros eliminados
- **Reportes**: Análisis y métricas del negocio

### 🌐 Web (Blazor) - Empleados y Clientes
- **Sistema de Login**: Autenticación moderna con Firebase
- **Dashboard**: Vista personalizada según el rol
- **Registro de Compras**: Formularios intuitivos para ventas
- **Gestión de Feedback**: Recolección de opiniones del cliente
- **Historial**: Consulta de transacciones anteriores

### 📱 Mobile (MAUI) - Empleados Móviles
- **Consulta Rápida**: Acceso a datos desde el teléfono
- **Registro de Feedback**: Captura inmediata de opiniones
- **Notificaciones Push**: Alertas automáticas de seguimiento

---

## 🔔 Sistema de Notificaciones

### Funcionalidad Automatizada
1. **Generación Automática**: Al registrar una compra/servicio
2. **Cálculo de Recordatorios**: Basado en `DiasParaRecordatorio`
3. **Estados de Seguimiento**: Pendiente → Atendida
4. **Alertas Programadas**: Notificaciones por fecha

### Flujo de Notificaciones

```
Registro Compra → Cálculo Automático → Notificación Generada
      ↓                    ↓                    ↓
 FechaCompra      +DiasRecordatorio      FechaRecordatorio
      ↓                    ↓                    ↓
  2025-01-15         +7 días              2025-01-22
                                               ↓
                                    Estado: Pendiente
                                               ↓
                              Empleado atiende al cliente
                                               ↓
                                     Estado: Atendida
```

---

## 📊 Características Técnicas Avanzadas

### 🗑️ Soft Delete Pattern
- **Preservación de Datos**: Los registros no se eliminan físicamente
- **Auditoría Completa**: Histórico de cambios y eliminaciones
- **Recuperación**: Posibilidad de restaurar registros eliminados
- **Filtros Automáticos**: Los registros eliminados se ocultan por defecto

### 🔄 Servicios Genéricos
```csharp
public class GenericService<T> where T : class
{
    Task<List<T>> GetAllAsync(string filter);
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<List<T>> GetAllDeletedsAsync(string filter);
}
```

### 🏗️ Arquitectura API REST

| Endpoint | Método | Descripción |
|----------|--------|-------------|
| `/api/clientes` | GET | Listar clientes activos |
| `/api/clientes/{id}` | GET | Obtener cliente específico |
| `/api/clientes` | POST | Crear nuevo cliente |
| `/api/clientes/{id}` | PUT | Actualizar cliente |
| `/api/clientes/{id}` | DELETE | Eliminar cliente (soft) |
| `/api/clientes/restore/{id}` | PUT | Restaurar cliente |
| `/api/clientes/deleteds` | GET | Listar clientes eliminados |

---

## 🚀 Instrucciones de Instalación

### Requisitos Previos
- **.NET 8 SDK** o superior
- **SQL Server** (Express o completo)
- **Visual Studio 2022** o **VS Code**
- **Node.js** (para Blazor WebAssembly)

### Configuración del Proyecto

1. **Clonar el repositorio**
```bash
git clone https://github.com/MartinGarate/Fidelium.git
cd Fidelium
```

2. **Configurar Base de Datos**
```bash
# En la carpeta Backend
dotnet ef database update
```

3. **Configurar Firebase**
- Crear proyecto en Firebase Console
- Configurar Authentication
- Obtener configuración y agregar a `appsettings.json`

4. **Ejecutar el Backend**
```bash
cd Backend
dotnet run
```

5. **Ejecutar las Aplicaciones Frontend**
```bash
# Desktop
cd Desktop
dotnet run

# Web
cd webBlazor
dotnet run

# Mobile (requiere emulador o dispositivo)
cd Mobile
dotnet build -t:Run
```

---

## 📈 Roadmap y Funcionalidades Futuras

### Version 2.0 (Próximamente)
- [ ] **Dashboard Analytics**: Métricas avanzadas y KPIs
- [ ] **API Mobile**: Endpoints optimizados para móviles
- [ ] **Notificaciones Push**: Alertas en tiempo real
- [ ] **Integración WhatsApp**: Comunicación automatizada
- [ ] **Reportes Avanzados**: Análisis predictivo

### Version 3.0 (A largo plazo)
- [ ] **Machine Learning**: Predicción de satisfacción del cliente
- [ ] **Microservicios**: Arquitectura distribuida
- [ ] **Docker**: Contenedores para deployment
- [ ] **Cloud Native**: Migración completa a Azure
- [ ] **Multi-tenancy**: Soporte para múltiples empresas

---

## 🤝 Contribución

### Guías de Contribución
1. Fork el proyecto
2. Crear rama para feature (`git checkout -b feature/nueva-funcionalidad`)
3. Commit los cambios (`git commit -m 'Agregar nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abrir Pull Request

### Estándares de Código
- **C# Conventions**: Seguir las convenciones estándar de C#
- **Clean Code**: Código limpio y documentado
- **SOLID Principles**: Aplicar principios de diseño
- **Testing**: Incluir pruebas unitarias para nuevas funcionalidades

---

## 📝 Licencia

Este proyecto está bajo la licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

---

## 👥 Equipo de Desarrollo

| Nombre | Rol | Email | GitHub |
|--------|-----|-------|--------|
| **Martín Garate** | Lead Developer | martingarate0@gmail.com | [@MartinGarate](https://github.com/MartinGarate) |
| **Leonel Arrieta** | Backend Developer | leonelarrieta@gmail.com | - |
| **Valentino Machado** | Frontend Developer | valentinomachado@gmail.com | - |
| **Candela Corradi** | QA Engineer | corradicande@gmail.com | - |
| **Ximena Gorosito** | UI/UX Designer | ximenagorosito0@gmail.com | - |

---

## 📞 Contacto y Soporte

- **Email**: martingarate0@gmail.com
- **Issues**: [GitHub Issues](https://github.com/MartinGarate/Fidelium/issues)
- **Discussions**: [GitHub Discussions](https://github.com/MartinGarate/Fidelium/discussions)

---

## 🔄 Changelog

### Version 1.0.0 (Actual)
- ✅ Sistema base de autenticación
- ✅ CRUD completo de entidades
- ✅ Soft delete implementado
- ✅ Notificaciones automatizadas
- ✅ Interfaz WinForms para administradores
- ✅ Aplicación web Blazor
- ✅ API REST completa

---

<div align="center">

**Fidelium - Transformando la gestión de clientes** 🎯

[![Made with ❤️](https://img.shields.io/badge/Made%20with-❤️-red.svg)]()
[![.NET 8](https://img.shields.io/badge/Built%20with-.NET%208-blue.svg)]()

</div>
