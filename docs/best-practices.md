# Mejores Prácticas con GitHub Copilot

## 🎯 Principios Fundamentales

### 1. **Contexto es Clave**
Copilot funciona mejor cuando entiende el contexto de tu proyecto.

```javascript
// ❌ Prompt vago
// función que hace algo con datos

// ✅ Prompt específico con contexto
// Función para calcular el promedio de calificaciones de estudiantes
// excluyendo la nota más alta y más baja, útil para sistemas de evaluación
function calcularPromedioAjustado(calificaciones) {
    // Copilot generará código más preciso
}
```

### 2. **Nombres Descriptivos**
Usa nombres que comuniquen la intención claramente.

```python
# ❌ Variables genéricas
data = []
result = 0

# ✅ Variables descriptivas
estudiantes_aprobados = []
promedio_calificaciones = 0.0
```

### 3. **Comentarios Estructurados**
Estructura tus comentarios para guiar mejor a Copilot.

```csharp
// ❌ Comentario simple
// Crear clase usuario

// ✅ Comentario estructurado
// Clase Usuario para sistema de gestión académica
// Propiedades: Id (int), Nombre (string), Email (string), FechaRegistro (DateTime)
// Métodos: ValidarEmail(), CalcularEdad(), ActualizarPerfil()
// Implementar interfaces: IComparable, IEquatable
public class Usuario
{
    // Copilot generará implementación completa
}
```

## 🛠️ Técnicas por Tecnología

### C# - Mejores Prácticas

#### 1. **Aprovecha las Convenciones .NET**
```csharp
// Copilot respeta automáticamente las convenciones C#
public class ProductoService : IProductoService
{
    private readonly ILogger<ProductoService> _logger;
    private readonly IRepository<Producto> _repository;

    // Constructor injection automático
    public ProductoService(ILogger<ProductoService> logger, IRepository<Producto> repository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    // Métodos async con nomenclatura apropiada
    public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
    {
        // Implementación generada por Copilot
    }
}
```

#### 2. **Prompts para Patrones de Diseño**
```csharp
// Implementar patrón Repository con Unit of Work
// Incluir interfaces genéricas, dependency injection
// Manejar transacciones de base de datos
// Implementar lazy loading y eager loading
```

#### 3. **Testing Automático**
```csharp
// Generar tests unitarios para ProductoService
// Usar Moq para mocking de dependencias
// Incluir casos: éxito, excepciones, edge cases
// Seguir patrón Arrange-Act-Assert
```

### Python - Mejores Prácticas

#### 1. **Type Hints para Mejor Contexto**
```python
from typing import List, Dict, Optional, Union
import pandas as pd

# Copilot genera código más preciso con type hints
def analizar_datos_ventas(
    df: pd.DataFrame,
    fecha_inicio: Optional[str] = None,
    fecha_fin: Optional[str] = None
) -> Dict[str, Union[float, int]]:
    """
    Analiza datos de ventas en un período específico.
    
    Args:
        df: DataFrame con columnas ['fecha', 'producto', 'cantidad', 'precio']
        fecha_inicio: Fecha en formato 'YYYY-MM-DD'
        fecha_fin: Fecha en formato 'YYYY-MM-DD'
    
    Returns:
        Diccionario con métricas: total_ventas, promedio_diario, productos_únicos
    """
    # Copilot generará implementación apropiada
    pass
```

#### 2. **Docstrings Estructurados**
```python
# Usar formato Google/NumPy para docstrings
def entrenar_modelo_prediccion(
    X_train: np.ndarray, 
    y_train: np.ndarray, 
    modelo_tipo: str = 'random_forest'
) -> Tuple[object, Dict[str, float]]:
    """
    Entrena modelo de machine learning para predicción de ventas.

    Args:
        X_train: Features de entrenamiento (shape: n_samples, n_features)
        y_train: Target variable (shape: n_samples,)
        modelo_tipo: Tipo de modelo ('random_forest', 'linear_regression', 'svm')

    Returns:
        Tuple con (modelo_entrenado, métricas_evaluación)
    
    Raises:
        ValueError: Si modelo_tipo no es válido
        
    Example:
        >>> modelo, metricas = entrenar_modelo_prediccion(X, y, 'random_forest')
        >>> print(metricas['accuracy'])
    """
```

#### 3. **Prompts para Data Science**
```python
# Análisis exploratorio completo de dataset de ventas:
# 1. Estadísticas descriptivas con outliers detection
# 2. Correlaciones entre variables numéricas
# 3. Distribuciones por categorías
# 4. Análisis temporal con estacionalidad
# 5. Feature engineering automático
# 6. Visualizaciones con matplotlib/seaborn
```

### React - Mejores Prácticas

#### 1. **Componentes con Props Claramente Definidas**
```jsx
// Componente ProductCard con todas las props necesarias
// Props: product (objeto), onAddToCart (función), onWishlist (función)
// Estados internos: loading, error, quantity
// Responsive design, accessibility, animations
const ProductCard = ({ 
    product, 
    onAddToCart, 
    onWishlist, 
    showQuickView = false 
}) => {
    // Copilot generará implementación completa
};
```

#### 2. **Custom Hooks Descriptivos**
```jsx
// Custom hook para gestionar estado de carrito de compras
// Funcionalidades: agregar, quitar, actualizar cantidad, limpiar
// Persistencia en localStorage, cálculo de totales
// Validación de stock, manejo de cupones de descuento
const useShoppingCart = () => {
    // Implementación generada por Copilot
};
```

#### 3. **Prompts para Performance**
```jsx
// Optimizar componente ProductList para 1000+ productos:
// - Virtualización con react-window
// - Memoización con React.memo
// - Lazy loading de imágenes
// - Debouncing para filtros de búsqueda
// - Suspense para code splitting
```

## 🎭 Prompts Efectivos por Escenario

### Debugging y Resolución de Problemas

#### Explicar Errores
```
Prompt: "Este código da el error [pegar error completo]. Explica qué significa y cómo solucionarlo paso a paso."

Ejemplo en C#:
"System.NullReferenceException en línea 45. El objeto no está definido. ¿Cómo debuggear y resolver?"
```

#### Optimizar Performance
```
Prompt: "Esta función es lenta con datasets grandes. Analiza y sugiere optimizaciones específicas:"

// Función que necesita optimización
def procesar_ventas_anuales(df):
    resultado = []
    for index, row in df.iterrows():
        # Procesamiento fila por fila
    return resultado
```

#### Refactoring
```
Prompt: "Refactoriza este código para seguir principios SOLID y mejorar maintainability:"

// Código que necesita refactoring
public class OrderManager
{
    public void ProcessOrder(Order order)
    {
        // 200 líneas de código con múltiples responsabilidades
    }
}
```

### Generación de Tests

#### Tests Unitarios
```
Prompt: "Genera tests unitarios completos para esta función. Incluye casos límite, excepciones y mocks necesarios:"

public async Task<List<Producto>> BuscarProductosAsync(string termino, int pagina = 1)
{
    // Implementación del método
}
```

#### Tests de Integración
```
Prompt: "Crea tests de integración para este endpoint API. Incluye casos de éxito, errores HTTP, validación de datos:"

[HttpPost]
public async Task<ActionResult<Producto>> CrearProducto([FromBody] ProductoDto productoDto)
{
    // Implementación del endpoint
}
```

### Documentación Automática

#### README Técnico
```
Prompt: "Genera README completo para este proyecto React. Incluye: instalación, configuración, scripts disponibles, estructura de carpetas, guías de contribución."
```

#### Documentación de API
```
Prompt: "Documenta esta API REST con Swagger/OpenAPI. Incluye ejemplos de request/response, códigos de error, autenticación:"

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    // Métodos del controlador
}
```

## 🚀 Workflows de Desarrollo

### Desarrollo Dirigido por Tests (TDD)

1. **Describir el Comportamiento**
```
Prompt: "Quiero implementar un servicio de autenticación JWT. Primero, genera los tests que definan el comportamiento esperado."
```

2. **Implementar la Lógica**
```
Prompt: "Ahora implementa el servicio que pase todos estos tests. Usa las mejores prácticas de seguridad."
```

3. **Refactorizar**
```
Prompt: "Los tests pasan. Refactoriza el código para mejor legibilidad y performance sin romper los tests."
```

### Feature Development

1. **Planificación**
```
Prompt: "Necesito implementar un sistema de notificaciones en tiempo real. Sugiere la arquitectura completa: backend, frontend, base de datos."
```

2. **Implementación Incremental**
```
Prompt: "Empezamos con el backend. Crea el modelo de datos y API endpoints para notificaciones."
```

3. **Integración**
```
Prompt: "Ahora conecta el frontend React con WebSockets para recibir notificaciones en tiempo real."
```

## 🔍 Debugging Avanzado

### Análisis de Performance

#### Profiling de Código
```python
# Prompt para análisis de performance
# "Analiza este código y sugiere optimizaciones específicas para big data:"

def analizar_millones_registros(df):
    # Código que procesa millones de filas
    for index, row in df.iterrows():
        # Operaciones costosas
    return resultado
```

#### Memory Leaks
```javascript
// Prompt para detectar memory leaks
// "Revisa este código React y identifica posibles memory leaks:"

useEffect(() => {
    const interval = setInterval(() => {
        // Operaciones que podrían causar leaks
    }, 1000);
    
    // ¿Falta cleanup?
}, []);
```

### Análisis de Seguridad

#### Vulnerabilidades
```csharp
// Prompt para análisis de seguridad
// "Revisa este código y identifica vulnerabilidades de seguridad:"

public ActionResult Login(string username, string password)
{
    var query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
    // SQL Injection vulnerability
}
```

#### Mejores Prácticas de Seguridad
```
Prompt: "Convierte este endpoint inseguro en uno que siga las mejores prácticas de seguridad web (OWASP Top 10)."
```

## 📊 Métricas y Calidad

### Code Quality Metrics

#### Complejidad Ciclomática
```
Prompt: "Esta función tiene alta complejidad ciclomática. Refactorízala para reducir la complejidad manteniendo la funcionalidad:"

public bool ValidarUsuario(Usuario usuario)
{
    if (usuario != null && usuario.Email != null && usuario.Email.Contains("@"))
    {
        if (usuario.Edad >= 18 && usuario.Edad <= 120)
        {
            if (usuario.Nombre != null && usuario.Nombre.Length > 2)
            {
                // Muchas condiciones anidadas
                return true;
            }
        }
    }
    return false;
}
```

#### Test Coverage
```
Prompt: "Analiza la cobertura de tests de este módulo y genera tests adicionales para alcanzar 90% de cobertura:"

public class CalculadoraService
{
    public decimal Sumar(decimal a, decimal b) => a + b;
    public decimal Restar(decimal a, decimal b) => a - b;
    public decimal Multiplicar(decimal a, decimal b) => a * b;
    public decimal Dividir(decimal a, decimal b) => b != 0 ? a / b : throw new DivideByZeroException();
}
```

## 🎯 Casos de Uso Específicos

### E-Learning Platform

```
Prompt: "Diseña la arquitectura completa de una plataforma e-learning:
- Backend: API REST con autenticación, cursos, progreso
- Frontend: Dashboard estudiante/profesor, reproductor de video
- Base de datos: Usuarios, cursos, lecciones, progreso
- Características: live streaming, quizzes, certificados"
```

### IoT Dashboard

```
Prompt: "Crea un dashboard IoT para monitorear sensores:
- Python: Scripts para recibir datos de sensores MQTT
- FastAPI: API para almacenar y consultar datos
- React: Dashboard en tiempo real con gráficos
- Características: alertas, históricos, predicciones"
```

### Financial Analytics

```
Prompt: "Desarrolla sistema de análisis financiero:
- Python: Algoritmos de análisis técnico y fundamental
- C#: API de trading con conexión a brokers
- React: Interface de trading con gráficos avanzados
- Características: backtesting, risk management, alerts"
```

## 🛡️ Buenas Prácticas de Seguridad

### Prompts de Seguridad

```
Prompt General: "Revisa este código en busca de vulnerabilidades de seguridad comunes (OWASP Top 10) y sugiere fixes específicos."

Prompt Específico: "Implementa autenticación segura con:
- Password hashing con bcrypt/Argon2
- JWT con refresh tokens
- Rate limiting
- CSRF protection
- Input validation/sanitization"
```

## 📈 Optimización Continua

### Performance Monitoring

```
Prompt: "Implementa sistema de monitoreo de performance para aplicación web:
- Métricas de servidor (CPU, memoria, response time)
- Métricas de cliente (FCP, LCP, CLS)
- Alertas automáticas
- Dashboard de métricas
- Logs estructurados"
```

### A/B Testing

```
Prompt: "Crea framework de A/B testing para React app:
- Feature flags dinámicos
- Segmentación de usuarios
- Métricas y conversión
- Dashboard de resultados
- Rollback automático"
```

## 🎓 Consejos Avanzados

### 1. **Iteración Gradual**
No pidas todo a la vez. Construye gradualmente:
```
1. "Crea la estructura básica de..."
2. "Ahora agrega validación a..."
3. "Implementa el manejo de errores para..."
4. "Optimiza el performance de..."
```

### 2. **Contexto del Dominio**
Incluye contexto del dominio del negocio:
```
"Sistema de gestión hospitalaria: implementa módulo de citas que maneje horarios de médicos, especialidades, sala de emergencias, y lista de espera."
```

### 3. **Especifica Constraints**
Menciona limitaciones técnicas:
```
"Implementa cache Redis para esta API, considerando que tenemos máximo 1GB RAM y 1000 requests/minuto."
```

### 4. **Pide Alternativas**
```
"Muestra 3 enfoques diferentes para implementar real-time notifications: WebSockets, Server-Sent Events, y Polling. Compara pros/cons."
```

### 5. **Evolución del Código**
```
"Este código funciona para 100 usuarios. ¿Cómo lo modificarías para soportar 100,000 usuarios?"
```

## 🔄 Workflow Recomendado

### Desarrollo de Features

1. **Análisis** → "Analiza los requerimientos y sugiere arquitectura"
2. **Diseño** → "Crea los modelos de datos y interfaces"
3. **Implementación** → "Implementa la lógica core"
4. **Testing** → "Genera tests comprehensivos"
5. **Optimización** → "Optimiza performance y seguridad"
6. **Documentación** → "Documenta la funcionalidad"

### Code Review

1. **Revisión Automática** → "Revisa este PR en busca de bugs, security issues, y mejoras"
2. **Suggestions** → "Sugiere mejoras específicas para este código"
3. **Alternative Approaches** → "¿Hay mejores maneras de implementar esto?"

¡Experimenta con estos enfoques y ajústalos a tu estilo de desarrollo!