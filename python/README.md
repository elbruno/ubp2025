# Python con GitHub Copilot - Ciencia de Datos y Desarrollo Web

## 🎯 Objetivos de Aprendizaje

Al completar esta sección, podrás usar GitHub Copilot para:
- Análisis de datos con pandas y numpy
- Crear APIs web con FastAPI
- Implementar modelos de Machine Learning
- Visualización de datos con matplotlib y seaborn
- Automatización de tareas con scripts Python

## 🛠️ Configuración del Entorno

### Prerrequisitos
- **Python 3.9+** 
- **pip** para gestión de paquetes
- **Virtual environment** (venv o conda)
- **Visual Studio Code** con GitHub Copilot

### Configuración Inicial
```bash
# Crear entorno virtual
python -m venv copilot_python_env

# Activar entorno (Windows)
copilot_python_env\Scripts\activate
# Activar entorno (macOS/Linux)
source copilot_python_env/bin/activate

# Instalar paquetes básicos
pip install pandas numpy matplotlib seaborn scikit-learn fastapi uvicorn jupyter
```

### Verificación
```python
# test_setup.py - Copilot puede generar este código
# Script para verificar que todas las librerías están instaladas correctamente
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn import datasets
import fastapi

print("✅ Todas las librerías instaladas correctamente!")
```

## 📊 Sección 1: Análisis de Datos con Pandas

### 🥇 Ejercicio 1: Análisis de Ventas

#### Objetivo
Analizar datos de ventas usando pandas con ayuda de Copilot.

#### Dataset de Ejemplo
```python
# Crear dataset de ventas para práctica
# Dataset debe incluir: fecha, producto, categoria, precio, cantidad, vendedor, region
# Generar 1000 registros de datos sintéticos realistas
# Incluir fechas del último año, productos variados, multiple regiones
```

#### Prompt para Copilot Chat:
```
Crea un DataFrame de pandas con datos sintéticos de ventas que incluya:
- 1000 registros
- Columnas: fecha (último año), producto, categoria, precio, cantidad, vendedor, region
- Datos realistas para una empresa de tecnología
- Guarda como CSV para reutilizar
```

#### Análisis Solicitado
```python
# Análisis exploratorio de datos de ventas:
# 1. Resumen estadístico básico de todas las columnas numéricas
# 2. Ventas totales por mes y región
# 3. Top 10 productos más vendidos
# 4. Vendedor con mejor performance
# 5. Análisis de estacionalidad en las ventas
# 6. Correlación entre precio y cantidad vendida
```

#### Solución de Referencia

<details>
<summary>Ver solución completa</summary>

```python
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from datetime import datetime, timedelta
import random

# Generar datos sintéticos
def generar_datos_ventas():
    """Genera dataset sintético de ventas para análisis."""
    np.random.seed(42)
    
    # Configurar parámetros
    n_records = 1000
    start_date = datetime.now() - timedelta(days=365)
    
    # Listas de datos
    productos = ['iPhone 14', 'Samsung Galaxy', 'iPad', 'MacBook Pro', 'Surface Pro', 
                'AirPods', 'Xbox Series X', 'PlayStation 5', 'Nintendo Switch']
    categorias = ['Smartphones', 'Tablets', 'Laptops', 'Audio', 'Gaming']
    vendedores = ['Ana García', 'Carlos López', 'María Rodríguez', 'José Martín', 'Laura Sánchez']
    regiones = ['Norte', 'Sur', 'Este', 'Oeste', 'Centro']
    
    # Generar datos
    data = []
    for _ in range(n_records):
        fecha = start_date + timedelta(days=random.randint(0, 365))
        producto = random.choice(productos)
        categoria = random.choice(categorias)
        precio = round(random.uniform(50, 2000), 2)
        cantidad = random.randint(1, 10)
        vendedor = random.choice(vendedores)
        region = random.choice(regiones)
        
        data.append({
            'fecha': fecha,
            'producto': producto,
            'categoria': categoria,
            'precio': precio,
            'cantidad': cantidad,
            'vendedor': vendedor,
            'region': region,
            'total': precio * cantidad
        })
    
    return pd.DataFrame(data)

# Generar y guardar datos
df_ventas = generar_datos_ventas()
df_ventas.to_csv('ventas_datos.csv', index=False)
print("✅ Dataset generado y guardado como 'ventas_datos.csv'")

# Análisis exploratorio
print("\n📊 ANÁLISIS EXPLORATORIO DE DATOS")
print("=" * 50)

# 1. Resumen estadístico
print("\n1. Resumen Estadístico:")
print(df_ventas.describe())

# 2. Ventas por mes y región
df_ventas['mes'] = df_ventas['fecha'].dt.to_period('M')
ventas_mes_region = df_ventas.groupby(['mes', 'region'])['total'].sum().unstack()
print("\n2. Ventas por Mes y Región:")
print(ventas_mes_region.head())

# 3. Top 10 productos
top_productos = df_ventas.groupby('producto')['cantidad'].sum().sort_values(ascending=False).head(10)
print("\n3. Top 10 Productos Más Vendidos:")
print(top_productos)

# 4. Mejor vendedor
mejor_vendedor = df_ventas.groupby('vendedor')['total'].sum().sort_values(ascending=False)
print("\n4. Performance por Vendedor:")
print(mejor_vendedor)

# 5. Análisis estacional
ventas_mensuales = df_ventas.groupby('mes')['total'].sum()
print("\n5. Ventas Mensuales (Estacionalidad):")
print(ventas_mensuales)

# 6. Correlación precio-cantidad
correlacion = df_ventas['precio'].corr(df_ventas['cantidad'])
print(f"\n6. Correlación Precio-Cantidad: {correlacion:.3f}")
```

</details>

### 🥈 Ejercicio 2: Visualización de Datos

#### Objetivo
Crear visualizaciones profesionales con matplotlib y seaborn.

#### Prompts para Copilot
```python
# Crear dashboard de visualizaciones para datos de ventas:
# 1. Gráfico de líneas: ventas mensuales con tendencia
# 2. Gráfico de barras: ventas por región
# 3. Heatmap: correlación entre variables numéricas
# 4. Box plot: distribución de precios por categoría
# 5. Gráfico circular: participación de cada vendedor
# Usar estilo profesional con colores corporativos
```

## 🌐 Sección 2: APIs Web con FastAPI

### 🥇 Ejercicio 3: API de Análisis de Datos

#### Objetivo
Crear una API que exponga análisis de datos usando FastAPI.

#### Estructura del Proyecto
```bash
# Crear estructura del proyecto
mkdir analisis_api
cd analisis_api
mkdir app models services

# Estructura sugerida:
# analisis_api/
# ├── app/
# │   ├── __init__.py
# │   ├── main.py
# │   ├── models/
# │   ├── services/
# │   └── routers/
# ├── data/
# └── requirements.txt
```

#### Prompt Principal
```python
# API FastAPI para análisis de datos de ventas
# Endpoints necesarios:
# GET /ventas/resumen - estadísticas generales
# GET /ventas/por-region - ventas agrupadas por región
# GET /ventas/top-productos - productos más vendidos
# GET /ventas/vendedores - performance de vendedores
# POST /ventas/filtrar - filtrar ventas por criterios
# Incluir modelos Pydantic, manejo de errores, documentación automática
```

#### Implementación Paso a Paso

**1. Modelos Pydantic:**
```python
# models/ventas.py
# Modelos Pydantic para validación de datos de ventas
# VentaModel: representar una venta individual
# FiltroVentas: modelo para filtros de búsqueda
# ResumenVentas: modelo para respuesta de resumen
# Incluir validaciones apropiadas para cada campo
```

**2. Servicios de Análisis:**
```python
# services/analisis_service.py
# Servicio para operaciones de análisis de datos
# Métodos: obtener_resumen, analizar_por_region, top_productos, performance_vendedores
# Usar pandas para procesamiento de datos
# Implementar cache para consultas frecuentes
```

**3. Rutas de la API:**
```python
# routers/ventas_router.py
# Router FastAPI con todos los endpoints de ventas
# Incluir documentación detallada para cada endpoint
# Manejo de errores HTTP apropiados
# Validación de parámetros de entrada
```

### 🥈 Ejercicio 4: Autenticación y Middleware

#### Prompt para Autenticación
```python
# Implementar autenticación JWT en FastAPI
# Crear middleware para validar tokens
# Endpoints: /auth/login, /auth/register, /auth/refresh
# Proteger endpoints de análisis con decorador de autenticación
# Usar passlib para hash de contraseñas
```

## 🤖 Sección 3: Machine Learning

### 🥇 Ejercicio 5: Predicción de Ventas

#### Objetivo
Implementar un modelo predictivo usando scikit-learn.

#### Dataset y Preprocessing
```python
# Preparación de datos para machine learning:
# 1. Feature engineering: extraer características de fechas
# 2. Encoding categórico para variables no numéricas
# 3. Normalización de características numéricas
# 4. División train/test estratificada
# 5. Manejo de valores faltantes si existen
```

#### Modelos a Implementar
```python
# Implementar y comparar múltiples modelos:
# 1. Linear Regression para predicción de ventas
# 2. Random Forest para clasificación de productos exitosos
# 3. K-Means para segmentación de clientes
# 4. Time Series forecasting con ARIMA
# Incluir evaluación de modelos con métricas apropiadas
```

#### Prompt Específico
```python
# Sistema completo de predicción de ventas:
# 1. Clase ModeloVentas con métodos train, predict, evaluate
# 2. Pipeline de preprocessing automático
# 3. Validación cruzada para selección de hiperparámetros
# 4. Guardado y carga de modelos entrenados
# 5. API endpoint para hacer predicciones en tiempo real
```

### 🥈 Ejercicio 6: Análisis de Sentimientos

#### Objetivo
Implementar análisis de sentimientos de reviews de productos.

#### Prompt para Dataset
```python
# Generar dataset sintético de reviews de productos:
# 1000 reviews con texto, calificación (1-5), producto, fecha
# Reviews realistas tanto positivos como negativos
# Incluir variedad de productos tecnológicos
# Balancear sentimientos positivos, neutrales y negativos
```

#### Implementación ML
```python
# Pipeline completo de análisis de sentimientos:
# 1. Preprocessing de texto: limpieza, tokenización, stemming
# 2. Feature extraction: TF-IDF vectorización
# 3. Modelo de clasificación: Naive Bayes o SVM
# 4. Evaluación con matriz de confusión y métricas
# 5. API endpoint para clasificar nuevas reviews
```

## 🛠️ Sección 4: Automatización y Scripts

### 🥇 Ejercicio 7: Web Scraping Automatizado

#### Objetivo
Crear scripts de automatización para recopilación de datos.

#### Prompt para Web Scraping
```python
# Script de web scraping para precios de productos:
# 1. Usar requests y BeautifulSoup
# 2. Scraper para múltiples sitios e-commerce
# 3. Manejo de rate limiting y headers apropiados
# 4. Guardado de datos en base de datos SQLite
# 5. Sistema de logging para monitoreo
# 6. Ejecución programada con schedule
```

### 🥈 Ejercicio 8: Generación de Reportes

#### Objetivo
Automatizar la generación de reportes empresariales.

#### Prompts Específicos
```python
# Sistema de reportes automatizado:
# 1. Generador de reportes PDF con matplotlib y reportlab
# 2. Templates de reportes para diferentes departamentos
# 3. Envío automático por email con schedule
# 4. Dashboard web con Streamlit para visualización interactiva
# 5. Integración con Google Sheets para datos en tiempo real
```

## 🏆 Proyecto Final: Plataforma de Analytics

### Objetivo
Crear una plataforma completa de analytics con todas las tecnologías aprendidas.

### Arquitectura Sugerida
```
analytics_platform/
├── backend/                 # FastAPI backend
│   ├── app/
│   ├── models/
│   ├── services/
│   └── ml_models/
├── data_processing/         # Scripts de procesamiento
│   ├── scrapers/
│   ├── etl/
│   └── ml_training/
├── frontend/               # Dashboard web (opcional)
│   └── streamlit_app.py
├── notebooks/              # Jupyter notebooks para análisis
├── data/                   # Datasets
├── reports/                # Reportes generados
└── requirements.txt
```

### Funcionalidades Requeridas

1. **Backend API:**
   - Endpoints para CRUD de datos
   - Análisis estadísticos en tiempo real
   - Predicciones ML como servicio
   - Autenticación y autorización

2. **Procesamiento de Datos:**
   - ETL automatizado
   - Web scraping programado
   - Feature engineering automático
   - Entrenamiento continuo de modelos

3. **Visualización:**
   - Dashboard interactivo
   - Reportes PDF automatizados
   - Alertas por email/Slack
   - Métricas en tiempo real

### Prompts de Inicio para el Proyecto Final

1. **Arquitectura General:**
```
"Diseña la arquitectura completa de una plataforma de analytics empresarial con FastAPI, incluye estructura de carpetas, dependencias y flujo de datos"
```

2. **Backend Setup:**
```
"Crea el esqueleto de FastAPI con estructura modular para analytics: routers, services, models, database, y configuración"
```

3. **Pipeline ML:**
```
"Implementa pipeline completo de machine learning: ingesta de datos, preprocessing, entrenamiento, evaluación y deployment"
```

## 📚 Buenas Prácticas con Python y Copilot

### 1. Docstrings y Type Hints
```python
# ✅ Copilot genera mejor código con type hints
from typing import List, Dict, Optional
import pandas as pd

def analizar_ventas(
    df: pd.DataFrame, 
    fecha_inicio: Optional[str] = None,
    fecha_fin: Optional[str] = None
) -> Dict[str, float]:
    """
    Analiza datos de ventas en un período específico.
    
    Args:
        df: DataFrame con datos de ventas
        fecha_inicio: Fecha de inicio del análisis (YYYY-MM-DD)
        fecha_fin: Fecha de fin del análisis (YYYY-MM-DD)
    
    Returns:
        Diccionario con métricas de ventas analizadas
    """
    # Copilot generará implementación más precisa
    pass
```

### 2. Manejo de Errores
```python
# Prompt: "Implementar manejo robusto de errores para API de datos"
from fastapi import HTTPException
import logging

async def procesar_datos(archivo: str):
    try:
        # Copilot agregará validaciones apropiadas
        pass
    except FileNotFoundError:
        logging.error(f"Archivo no encontrado: {archivo}")
        raise HTTPException(status_code=404, detail="Archivo no encontrado")
    except pd.errors.EmptyDataError:
        logging.error("El archivo está vacío")
        raise HTTPException(status_code=400, detail="Datos inválidos")
```

### 3. Testing
```python
# Prompt: "Crear tests unitarios completos para funciones de análisis de datos"
import pytest
import pandas as pd
from unittest.mock import Mock, patch

def test_analizar_ventas():
    # Copilot generará casos de prueba apropiados
    pass

def test_api_endpoints():
    # Tests para endpoints FastAPI
    pass
```

## 🔧 Herramientas de Desarrollo

### Jupyter Notebooks con Copilot
```python
# En Jupyter, Copilot ayuda con:
# 1. Análisis exploratorio de datos paso a paso
# 2. Visualizaciones interactivas
# 3. Experimentación con modelos ML
# 4. Documentación automática de análisis
```

### Debugging Efectivo
```python
# Técnicas de debugging con Copilot:
# 1. Usar logging estructurado
# 2. Implementar assertions en puntos críticos
# 3. Crear funciones de validación de datos
# 4. Usar breakpoints estratégicos en VS Code
```

## 📊 Métricas y Monitoreo

### Prompts para Monitoreo
```python
# Sistema de monitoreo para aplicaciones Python:
# 1. Métricas de performance con time/memory profiling
# 2. Health checks para APIs
# 3. Alertas automáticas por email/Slack
# 4. Dashboard de métricas en tiempo real
# 5. Logs estructurados con nivel apropiado
```

## 🎯 Siguiente Paso

Después de completar los ejercicios de Python, puedes continuar con:
- **[React - Desarrollo Frontend](../react/README.md)**
- **[C# - Desarrollo Backend](../csharp/README.md)** (si no lo completaste)

## 📚 Recursos Adicionales

- [Documentación de FastAPI](https://fastapi.tiangolo.com/)
- [Pandas Documentation](https://pandas.pydata.org/docs/)
- [Scikit-learn User Guide](https://scikit-learn.org/stable/user_guide.html)
- [Python con GitHub Copilot - Mejores Prácticas](../docs/best-practices.md)

¡Sigue experimentando con las capacidades de GitHub Copilot en Python!