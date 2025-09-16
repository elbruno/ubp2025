# C# con GitHub Copilot - Desarrollo Backend

## 🎯 Objetivos de Aprendizaje

Al completar esta sección, podrás usar GitHub Copilot para:
- Crear APIs REST con ASP.NET Core
- Implementar operaciones CRUD
- Manejar datos con Entity Framework
- Escribir tests unitarios
- Implementar autenticación y autorización

## 🛠️ Configuración del Entorno

### Prerrequisitos
- **.NET 8 SDK** o superior
- **Visual Studio Code** con GitHub Copilot
- **SQL Server Express** o **SQLite** para bases de datos

### Verificación de Instalación
```bash
# Verifica .NET SDK
dotnet --version

# Crear proyecto de prueba
dotnet new webapi -n CopilotTest
cd CopilotTest
dotnet run
```

## 📚 Ejercicios Progresivos

### 🥇 Ejercicio 1: API Básica de Productos

#### Objetivo
Crear una API REST para gestionar productos usando Copilot.

#### Paso 1: Configuración del Proyecto
```bash
# Crear nueva API
dotnet new webapi -n ProductosAPI
cd ProductosAPI

# Agregar paquetes necesarios
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

#### Paso 2: Modelo de Producto
Abre `Models/Producto.cs` y escribe este comentario para que Copilot genere el modelo:

```csharp
// Modelo de producto para e-commerce
// Propiedades: Id (int), Nombre (string), Precio (decimal), Categoria (string), Stock (int), FechaCreacion (DateTime)
// Incluir validaciones de datos apropiadas
```

**💡 Prompt para Copilot Chat:**
```
Crea una clase Producto con las siguientes propiedades:
- Id: entero, clave primaria
- Nombre: string, requerido, máximo 100 caracteres
- Precio: decimal, debe ser mayor que 0
- Categoria: string, requerido
- Stock: entero, no puede ser negativo
- FechaCreacion: DateTime, valor por defecto la fecha actual

Incluye las anotaciones de validación apropiadas.
```

#### Paso 3: DbContext
En `Data/ProductoContext.cs`:

```csharp
// DbContext para gestionar productos
// Usar Entity Framework con configuración para InMemory database
// Incluir seed data con productos de ejemplo
```

#### Paso 4: Controlador API
En `Controllers/ProductosController.cs`:

```csharp
// Controlador API REST para productos
// Implementar CRUD completo: GET (todos), GET (por id), POST, PUT, DELETE
// Incluir manejo de errores y códigos de estado HTTP apropiados
// Usar async/await para operaciones de base de datos
```

#### Solución de Referencia

<details>
<summary>Ver solución completa</summary>

**Models/Producto.cs:**
```csharp
using System.ComponentModel.DataAnnotations;

namespace ProductosAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }
        
        [Required(ErrorMessage = "La categoría es requerida")]
        public string Categoria { get; set; } = string.Empty;
        
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
```

**Data/ProductoContext.cs:**
```csharp
using Microsoft.EntityFrameworkCore;
using ProductosAPI.Models;

namespace ProductosAPI.Data
{
    public class ProductoContext : DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options) { }
        
        public DbSet<Producto> Productos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Laptop", Precio = 999.99m, Categoria = "Tecnología", Stock = 10 },
                new Producto { Id = 2, Nombre = "Mouse", Precio = 29.99m, Categoria = "Tecnología", Stock = 50 },
                new Producto { Id = 3, Nombre = "Teclado", Precio = 79.99m, Categoria = "Tecnología", Stock = 25 }
            );
        }
    }
}
```

</details>

### 🥈 Ejercicio 2: Tests Unitarios

#### Objetivo
Implementar tests unitarios para el controlador de productos.

#### Configuración de Tests
```bash
# Crear proyecto de tests
dotnet new xunit -n ProductosAPI.Tests
cd ProductosAPI.Tests

# Agregar referencias
dotnet add reference ../ProductosAPI/ProductosAPI.csproj
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.AspNetCore.Mvc.Testing
```

#### Prompt para Copilot
```csharp
// Tests unitarios para ProductosController
// Implementar tests para:
// - GET todos los productos (debe retornar lista)
// - GET producto por ID (existente y no existente)
// - POST crear producto (válido e inválido)
// - PUT actualizar producto
// - DELETE eliminar producto
// Usar InMemory database para los tests
// Incluir setup y cleanup apropiados
```

### 🥉 Ejercicio 3: Autenticación JWT

#### Objetivo
Implementar autenticación JWT en la API.

#### Paquetes Necesarios
```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```

#### Prompts para Copilot

1. **Modelo de Usuario:**
```csharp
// Modelo de usuario para autenticación
// Propiedades: Id, Username, Email, PasswordHash, Role
// Incluir validaciones apropiadas
```

2. **Servicio de Autenticación:**
```csharp
// Servicio para manejar autenticación JWT
// Métodos: Login, RegisterUser, GenerateJwtToken, ValidateUser
// Usar BCrypt para hash de contraseñas
// Token debe incluir claims de usuario y rol
```

3. **Middleware de Autenticación:**
```csharp
// Configurar autenticación JWT en Program.cs
// Incluir configuración de token validation parameters
// Agregar policies de autorización por roles
```

## 🏆 Desafíos Avanzados

### Desafío 1: Sistema de Inventario Completo
Extiende la API de productos para incluir:
- **Categorías** como entidad separada
- **Proveedores** con información de contacto
- **Movimientos de stock** (entradas y salidas)
- **Reportes** de inventario

### Desafío 2: Patrón Repository
Refactoriza el código para implementar:
- **Interface IRepository<T>**
- **ProductoRepository** 
- **Unit of Work pattern**
- **Dependency Injection**

### Desafío 3: API con Cache
Implementa caching para mejorar el rendimiento:
- **Memory Cache** para datos frecuentes
- **Distributed Cache** con Redis
- **Cache invalidation** en operaciones CRUD

## 📊 Ejercicios con Entity Framework

### Relaciones entre Entidades

#### Prompt para One-to-Many
```csharp
// Configurar relación entre Categoria y Producto
// Una categoría puede tener muchos productos
// Un producto pertenece a una categoría
// Incluir navegation properties y foreign key
// Configurar cascading delete apropiado
```

#### Prompt para Many-to-Many
```csharp
// Configurar relación entre Producto y Proveedor
// Un producto puede tener múltiples proveedores
// Un proveedor puede suministrar múltiples productos
// Crear tabla intermedia ProductoProveedor con precio y fecha
```

### Queries Avanzadas

#### LINQ con Copilot
```csharp
// Queries LINQ para reportes:
// 1. Productos con stock bajo (menos de 10 unidades)
// 2. Productos más vendidos por categoría
// 3. Proveedores con mayor volumen de productos
// 4. Análisis de precio promedio por categoría
// 5. Productos sin movimiento en los últimos 30 días
```

## 🔧 Debugging con Copilot

### Técnicas Útiles

1. **Explicar Errores:**
```
/explain
Selecciona el error y pide explicación a Copilot
```

2. **Sugerir Fixes:**
```
"Este código da error [pegar error]. ¿Cómo lo solucionas?"
```

3. **Optimizar Performance:**
```
/optimize
"Optimiza esta query LINQ para mejor rendimiento"
```

## 📝 Buenas Prácticas Específicas para C#

### 1. Convenciones de Naming
```csharp
// ✅ Copilot respeta las convenciones C#
public class ProductoService  // PascalCase para clases
{
    private readonly IRepository _repository;  // camelCase con _ para fields privados
    
    public async Task<Producto> ObtenerProductoAsync(int id)  // PascalCase para métodos
    {
        var producto = await _repository.GetByIdAsync(id);  // camelCase para variables locales
        return producto;
    }
}
```

### 2. Uso de Using Statements
```csharp
// Prompt: "Generar using statements apropiados para Entity Framework y ASP.NET Core"
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
```

### 3. Async/Await Patterns
```csharp
// Prompt: "Convertir métodos síncronos a asíncronos siguiendo las mejores prácticas"
public async Task<ActionResult<IEnumerable<Producto>>> GetProductosAsync()
{
    var productos = await _context.Productos.ToListAsync();
    return Ok(productos);
}
```

## 🚀 Proyecto Final: E-Commerce API

### Objetivo
Crear una API completa de e-commerce usando todo lo aprendido.

### Funcionalidades Requeridas
- **Gestión de productos** (CRUD completo)
- **Sistema de usuarios** (registro, login, perfiles)
- **Carrito de compras** (agregar, quitar, actualizar)
- **Procesamiento de órdenes** (crear, pagar, enviar)
- **Autenticación JWT** (con roles admin/customer)
- **Reportes administrativos** (ventas, productos populares)

### Estructura Sugerida
```
ECommerceAPI/
├── Controllers/
│   ├── ProductosController.cs
│   ├── UsuariosController.cs
│   ├── CarritoController.cs
│   └── OrdenesController.cs
├── Models/
│   ├── Producto.cs
│   ├── Usuario.cs
│   ├── Carrito.cs
│   └── Orden.cs
├── Services/
│   ├── IProductoService.cs
│   ├── IUsuarioService.cs
│   └── Implementations/
├── Data/
│   └── ECommerceContext.cs
└── Tests/
    └── Controllers/
```

### Prompts de Inicio
1. "Crear estructura de proyecto para API de e-commerce con las entidades: Usuario, Producto, Carrito, Orden"
2. "Implementar autenticación JWT con roles admin y customer"
3. "Crear endpoints para gestión completa de carrito de compras"

## 📚 Recursos Adicionales

- [Documentación oficial de ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Mejores prácticas C# con Copilot](../docs/best-practices.md)

## 🎯 Siguiente Paso

Una vez completados estos ejercicios, puedes continuar con:
- **[Python - Ciencia de Datos y Web](../python/README.md)**
- **[React - Desarrollo Frontend](../react/README.md)**

¡Continúa explorando las capacidades de GitHub Copilot!