# 📋 Fidelium | Sistema de Fidelización de Clientes a través de feedback.

---

## 🔹 Descripción del Proyecto

Este proyecto es un **Sistema de Fidelización de Clientes**, diseñado para ayudar a empresas a **registrar y gestionar sus clientes**, llevar el control de las **compras o servicios que adquieren** y realizar **seguimientos automáticos** mediante notificaciones.

El sistema permite:
- Mantener un registro organizado de todos los clientes.  
- Registrar cada compra o servicio que realiza un cliente.  
- Generar notificaciones automáticas para recordar seguimiento al cliente después de un período determinado.  
- Registrar la opinión o **feedback del cliente**, lo que ayuda a mejorar el servicio y personalizar futuras interacciones.  
- Consultar reportes simples que muestran la actividad de los clientes en un período de tiempo determinado.

---

## 🎯 Objetivo

El objetivo principal del sistema es **mejorar la relación con los clientes** mediante un seguimiento organizado y sistemático. Esto ayuda a:  
- Incrementar la satisfacción del cliente.  
- Facilitar el trabajo de los empleados al automatizar recordatorios y notificaciones.  
- Permitir que la administración tenga información clara y ordenada sobre las compras y el comportamiento de los clientes.

---

## 🧩 Funcionalidades Principales

1. **Gestión de Clientes:**  
   - Registrar nuevos clientes.  
   - Modificar datos existentes.  
   - Eliminar clientes (soft delete: los registros no se borran realmente, solo se ocultan).

2. **Gestión de Compras/Servicios:**  
   - Registrar cada compra o servicio que realiza un cliente.  
   - Modificar o eliminar registros de compras/servicios.  
   - Vincular cada compra con notificaciones de seguimiento.

3. **Feedback del Cliente:**  
   - Cada compra permite registrar comentarios o sugerencias del cliente.  
   - Esto permite personalizar futuras interacciones y mejorar la relación.

4. **Notificaciones Automáticas:**  
   - Configura recordatorios automáticos para hacer seguimiento a los clientes.  
   - Ejemplo: si un cliente compra un servicio de mantenimiento, se puede programar un recordatorio 30 días después para ofrecer un nuevo servicio o seguimiento.  
   - Los recordatorios se generan automáticamente según la configuración de días.

5. **Reportes de Compras:**  
   - Permite generar informes por cliente o por período de tiempo.  
   - Ayuda a la empresa a monitorear la actividad y rendimiento de sus ventas o servicios.

---

## 🧑‍💻 Roles y Plataformas

El sistema está pensado para diferentes **usuarios y plataformas**, cada uno con permisos específicos:

| Plataforma  | Rol / Usuario      | Funcionalidad Principal                                                                 |
|-------------|-------------------|-----------------------------------------------------------------------------------------|
| 💻 WinForms | **Administrador** | Control total: crear, modificar, eliminar clientes y compras, generar reportes y gestionar notificaciones, acceso a todos los registros, incluso los eliminados “soft deleted”. |
| 🌐 Blazor   | **Empleado Local**| Puede registrar clientes y compras rápidamente, consultar clientes y compras, ver notificaciones activas, eliminar registros de manera temporal (soft delete). |
| 📱 MAUI     | **Empleado Móvil**| Consultar clientes y compras desde el teléfono, ver notificaciones pendientes, registrar y marcar feedback, eliminar registros temporalmente (soft delete). |

---

## 🛠 Tecnologías Utilizadas

- **Lenguaje de programación:** C# (.NET 8)  
- **Aplicaciones de escritorio y web:** WinForms, Blazor App, .NET MAUI  
- **Base de datos:** SQL Server  
- **ORM (para manejo de la base de datos):** Entity Framework Core  
- **Patrones y buenas prácticas:** soft delete, enums para estados, campos opcionales para feedback e Instagram, cálculo automático de recordatorios.

---

## 📚 Explicación de Campos Clave

- **DiasParaRecordatorio:** número de días después de la compra en que se debe recordar al cliente.  
- **FechaRecordatorio:** fecha exacta en que se generará la notificación.  
- **IsDeleted:** permite eliminar registros “de manera segura” sin borrarlos de la base de datos, para que se puedan recuperar o consultar desde la administración.  
- **Feedback del cliente:** campo libre donde se pueden registrar comentarios o sugerencias de cada cliente, para mejorar la atención futura.

---

## 📊 Reportes y Consultas

El sistema permite generar reportes simples para responder preguntas como:  
- ¿Qué clientes realizaron compras en este mes?  
- ¿Cuáles servicios tienen notificaciones pendientes?  
- ¿Qué feedback dejaron los clientes en sus compras?  

Esto ayuda a la administración a tomar decisiones estratégicas basadas en datos reales.

---

## 🚀 Cómo Funciona

1. **Registrar un cliente:** se crean los datos básicos del cliente (nombre, teléfono, correo, Instagram).  
2. **Registrar una compra/servicio:** se asocia al cliente, se describe el servicio y se puede agregar feedback.  
3. **Generar notificación:** el sistema calcula automáticamente la fecha de seguimiento según los días configurados.  
4. **Seguimiento:** los empleados reciben notificaciones y pueden registrar nuevas interacciones o comentarios del cliente.  
5. **Reportes:** la administración puede consultar la actividad histórica de clientes y compras.

---


## 💡 Notas Finales

- El sistema está pensado para **facilitar el trabajo diario** de los empleados y la administración.  
- Permite un **seguimiento proactivo de los clientes**, aumentando la satisfacción y fidelización.  
- Todos los registros importantes quedan protegidos mediante **soft delete**, evitando pérdida de información.  
- La implementación multiplataforma permite usarlo en escritorio, web y dispositivos móviles según el rol del usuario.

---
