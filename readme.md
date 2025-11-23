# 📋 **Fidelium | Sistema Integral de Fidelización y Seguimiento de Clientes**

**Fidelium** es un sistema multiplataforma diseñado para gestionar clientes, registrar servicios, recolectar feedback y automatizar seguimientos mediante notificaciones inteligentes.  
Su objetivo es centralizar la información del negocio y mejorar la relación con los clientes a través de insights reales y recordatorios automáticos.

---

## 🔹 **Descripción General**

El sistema permite:

- Registrar y gestionar clientes.  
- Registrar compras o servicios, con feedback del cliente.  
- Generar **notificaciones automáticas** para seguimiento.  
- Consultar historiales y actividad por cliente.  
- Obtener reportes simples por período o cliente.  
- Operar desde **Desktop, Web y Mobile**, según el rol del usuario.

---

## 🎯 **Objetivo del Proyecto**

El propósito de Fidelium es proporcionar una herramienta simple, rápida y efectiva que permita:

- Aumentar la fidelización del cliente mediante recordatorios automatizados.  
- Mejorar la calidad del servicio con feedback estructurado.  
- Facilitar el trabajo del personal centralizando toda la información en un único sistema.  
- Mantener datos históricos sin perder información gracias al **soft delete**.

---

## 🧩 **Funcionalidades Principales**

### 👤 **Gestión de Clientes**
- Alta, edición y baja lógica (soft delete).
- Registro de:
  - Nombre y Apellido  
  - Teléfono  
  - Correo electrónico  
  - Instagram  
- Consulta de clientes y acceso a su historial.

### 🛒 **Gestión de Compras / Servicios**
- Registro de servicios/productos adquiridos.
- Fecha de compra automática.
- Campo libre para **feedback del cliente**.  
- Edición y eliminación (soft delete).
- Asociación directa al cliente.

### 🔔 **Notificaciones de Seguimiento**
- Configuración de días para recordatorio.
- Generación automática de notificaciones según las reglas definidas.
- Consulta de notificaciones pendientes.
- Marcado como atendido y control de estados.
- Cálculo automático de *FechaRecordatorio*.

### 📊 **Reportes**
- Cantidad de compras por día, semana o mes.
- Filtros por cliente o fecha.
- Visualización simple para análisis rápido.

### 🔐 **Usuarios y Roles**
- Registro, edición y baja lógica de usuarios.
- Autenticación con Email + Password.
- Manejo de roles:
  - **Administrador**
  - **Empleado**
  - **Seguimiento**
  - **Estudiante**
- Restricción de funcionalidades según permisos.

---

## 🧑‍💻 **Plataformas y Perfiles**

| Plataforma      | Rol / Usuario        | Funcionalidad Principal |
|-----------------|----------------------|-------------------------|
| 💻 **WinForms** | Administrador         | Acceso total: clientes, compras, notificaciones, reportes y registros eliminados. |
| 🌐 **Blazor**   | Empleado Local        | Registro rápido de clientes/compras, consulta de notificaciones, soft delete. |
| 📱 **MAUI**     | Empleado Móvil        | Consulta rápida, registro de feedback y manejo de notificaciones desde el teléfono. |

---

## 🛠 **Tecnologías Utilizadas**
- **Lenguaje:** C# (.NET 8)  
- **Frontend Desktop:** WinForms  
- **Frontend Web:** Blazor WebAssembly / Server  
- **Mobile:** .NET MAUI  
- **Base de Datos:** SQL Server  
- **ORM:** Entity Framework Core  
- **Patrones:**  
  - Soft Delete  
  - Enums para estados  
  - Campos opcionales para feedback  
  - Cálculo automático de recordatorios  

---

## 📚 **Campos Clave del Modelo**

- **DiasParaRecordatorio:** días a esperar antes del seguimiento.  
- **FechaRecordatorio:** fecha resultante del cálculo.  
- **IsDeleted:** oculta registros en vez de borrarlos.  
- **ComentarioFeedback:** comentario libre del cliente por compra/servicio.

---

## 📊 **Reportes Disponibles**
- Clientes con actividad reciente.  
- Historial por cliente.  
- Compras por período (día, semana, mes).  
- Notificaciones pendientes por fecha.  
- Feedback recopilado en el tiempo.

---

## 🚀 **Flujo de Uso del Sistema**

1. Registrar cliente.  
2. Registrar compra/servicio.  
3. El sistema genera automáticamente una notificación según la configuración.  
4. Empleados revisan notificaciones pendientes.  
5. Se registra el contacto o seguimiento con el cliente.  
6. Administración consulta reportes periódicos.

---

## 💡 **Notas Finales**

- Fidelium está pensado para maximizar la organización interna y la fidelización del cliente.  
- El uso de soft delete garantiza la seguridad e integridad histórica de los datos.  
- Su arquitectura multiplataforma permite adaptarse a distintos perfiles de trabajo, desde escritorio hasta dispositivos móviles.  

---
