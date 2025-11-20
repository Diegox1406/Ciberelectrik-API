# Ciberelectrik API

API REST desarrollada en C# ASP.NET para la gestión de un sistema de comercio electrónico.

## 📋 Descripción

Sistema backend que proporciona servicios para la gestión de productos, categorías, clientes, empleados, pedidos y más para la plataforma Ciberelectrik.

## 🏗️ Arquitectura

- **Lenguaje**: C# (.NET Framework)
- **Base de datos**: SQL Server
- **Patrón**: Repository Pattern
- **Comunicación**: Stored Procedures

## 📁 Estructura del Proyecto

```
pe.com.ciberelectrik.api/
├── Controllers/
│   ├── CategoriaController.cs
│   ├── ClienteController.cs
│   ├── DetalleTicketPedidoController.cs
│   ├── DistritoController.cs
│   ├── EmpleadoController.cs
│   ├── MarcaController.cs
│   ├── ProductoController.cs
│   ├── RolController.cs
│   ├── TicketPedidoController.cs
│   └── TipoDocumentoController.cs
├── Models/
│   ├── db/
│   └── repository/
└── README.md
```

## 🚀 Endpoints Principales

### Categorías
- `GET /api/categoria` - Obtener todas las categorías activas
- `GET /api/categoria/all` - Obtener todas las categorías
- `POST /api/categoria` - Registrar nueva categoría
- `PUT /api/categoria` - Actualizar categoría
- `DELETE /api/categoria/{id}` - Eliminar categoría
- `PUT /api/categoria/enable/{id}` - Habilitar categoría

### Clientes
- Gestión completa de clientes

### Productos
- Gestión de productos y catálogo

### Pedidos
- Gestión de tickets de pedido
- Gestión de detalles de pedido

### Empleados
- Gestión de empleados y roles

### Otros
- Marcas
- Distritos
- Tipos de documento

## 🔧 Configuración

### Prerrequisitos
- Visual Studio 2019 o superior
- .NET Framework 4.x
- SQL Server 2016 o superior
- IIS (para despliegue)

- ASP.NET Web API
- ADO.NET
- SQL Server
- Entity Framework 
