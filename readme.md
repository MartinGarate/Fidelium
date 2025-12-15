# 🎯 Fidelium - Sistema Integral de Fidelización de Clientes

![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)
![C#](https://img.shields.io/badge/C%23-12.0-purple.svg)
![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-green.svg)
![WinForms](https://img.shields.io/badge/WinForms-Desktop-orange.svg)
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
┌─────────────────┐    ┌─────────────────┐
│   WinForms      │    │   Blazor WASM   │
│  (Escritorio)   │    │     (Web)       │
│                 │    │                 │
│ • Administrador │    │ • Empleado      │
│ • CRUD Completo │    │ • Registro      │
│ • Reportes      │    │ • Feedback      │
│ • Papelera      │    │ • Notificaciones│
└─────────┬───────┘    └─────────┬───────┘
          │                      │
          │                      │
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
- **Swagger** - Documentación interactiva de API
- **MySQL** - Soporte adicional para bases de datos

### Frontend
- **WinForms** - Aplicación de escritorio (Administradores)
- **Blazor WebAssembly** - Aplicación web (Empleados)

### Servicios y Utilidades
- **Generic Services** - Servicios reutilizables para CRUD
- **Soft Delete Pattern** - Eliminación lógica de registros
- **Auto-calculated Notifications** - Notificaciones automáticas
- **Radzen.Blazor** - Componentes UI avanzados
- **SweetAlert2** - Alertas modernas

---

## 🏢 Estructura del Proyecto

```
Fidelium/
├── Backend/                    # API Backend (.NET 8)
│   ├── Controllers/           # Controladores REST
│   ├── DataContext/           # Entity Framework Context
│   └── Program.cs             # Configuración de la API
│
├── Service/                   # Modelos y Servicios Compartidos
│   ├── Models/               # Modelos de datos
│   ├── Enums/                # Enumeraciones
│   ├── Services/             # Servicios genéricos
│   └── Utils/                # Utilidades y endpoints
│
├── Desktop/                  # Aplicación WinForms
│   ├── Views/               # Formularios Windows
│   └── Utils/               # Utilidades de escritorio
│
├── webBlazor/               # Aplicación Web Blazor
│   ├── Pages/              # Páginas Blazor
│   ├── Services/           # Servicios específicos de Blazor
│   └── wwwroot/           # Archivos estáticos
│
├── TestFidelium/           # Proyecto de pruebas
└── README.md              # Este archivo
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
```

---

<div align="center">

**Fidelium - Transformando la gestión de clientes** 🎯

[![Made with ❤️](https://img.shields.io/badge/Made%20with-❤️-red.svg)]()
[![.NET 8](https://img.shields.io/badge/Built%20with-.NET%208-blue.svg)]()

</div>
