# React con GitHub Copilot - Desarrollo Frontend

## 🎯 Objetivos de Aprendizaje

Al completar esta sección, podrás usar GitHub Copilot para:
- Crear componentes React funcionales y de clase
- Implementar hooks personalizados y estado global
- Desarrollar interfaces responsive con CSS/Styled Components
- Integrar APIs y manejar datos asíncronos
- Implementar routing y navegación
- Optimizar performance y testing

## 🛠️ Configuración del Entorno

### Prerrequisitos
- **Node.js 18+** y **npm/yarn**
- **Visual Studio Code** con GitHub Copilot
- **React Developer Tools** (extensión de navegador)

### Configuración Inicial
```bash
# Verificar Node.js
node --version
npm --version

# Crear proyecto React con Vite (más rápido que CRA)
npm create vite@latest copilot-react-app -- --template react
cd copilot-react-app

# Instalar dependencias adicionales
npm install axios react-router-dom styled-components @emotion/react @emotion/styled
npm install -D @testing-library/react @testing-library/jest-dom vitest

# Iniciar servidor de desarrollo
npm run dev
```

### Verificación del Setup
```jsx
// src/App.jsx - Prompt para Copilot
// Crear componente App básico que muestre:
// 1. Header con navegación
// 2. Sección hero con título y descripción
// 3. Cards de funcionalidades de GitHub Copilot
// 4. Footer con enlaces
// Usar CSS moderno con flexbox/grid
```

## 🎨 Sección 1: Componentes y UI

### 🥇 Ejercicio 1: Sistema de Componentes

#### Objetivo
Crear una librería de componentes reutilizables con Copilot.

#### Estructura de Componentes
```
src/
├── components/
│   ├── ui/              # Componentes básicos
│   │   ├── Button.jsx
│   │   ├── Input.jsx
│   │   ├── Card.jsx
│   │   └── Modal.jsx
│   ├── layout/          # Componentes de layout
│   │   ├── Header.jsx
│   │   ├── Sidebar.jsx
│   │   └── Footer.jsx
│   └── features/        # Componentes de funcionalidad
├── hooks/               # Custom hooks
├── services/            # API calls
└── styles/              # CSS/Styled components
```

#### Prompts para Componentes UI

**1. Button Component:**
```jsx
// components/ui/Button.jsx
// Componente Button reutilizable con las siguientes props:
// - variant: "primary", "secondary", "danger", "ghost"
// - size: "small", "medium", "large"
// - disabled: boolean
// - loading: boolean (mostrar spinner)
// - onClick: función
// - children: contenido del botón
// Usar styled-components para styling
// Incluir hover effects y transiciones suaves
```

**2. Input Component:**
```jsx
// components/ui/Input.jsx
// Componente Input con validación:
// - type: "text", "email", "password", "number"
// - placeholder, value, onChange
// - error: string (mensaje de error)
// - required: boolean
// - icon: opcional (icono a la izquierda)
// Styling condicional basado en estado (normal, error, focus)
```

**3. Card Component:**
```jsx
// components/ui/Card.jsx
// Componente Card flexible:
// - header: opcional con título y acciones
// - body: contenido principal
// - footer: opcional con botones/links
// - elevation: nivel de sombra (0-3)
// - clickable: boolean (cursor pointer y hover effect)
// Responsive design con breakpoints
```

#### Solución de Referencia

<details>
<summary>Ver implementación del Button</summary>

```jsx
// components/ui/Button.jsx
import styled from 'styled-components';
import { useState } from 'react';

const StyledButton = styled.button`
  padding: ${props => {
    switch(props.size) {
      case 'small': return '8px 16px';
      case 'large': return '16px 32px';
      default: return '12px 24px';
    }
  }};
  
  background-color: ${props => {
    switch(props.variant) {
      case 'primary': return '#007bff';
      case 'secondary': return '#6c757d';
      case 'danger': return '#dc3545';
      case 'ghost': return 'transparent';
      default: return '#007bff';
    }
  }};
  
  color: ${props => props.variant === 'ghost' ? '#007bff' : 'white'};
  border: ${props => props.variant === 'ghost' ? '1px solid #007bff' : 'none'};
  border-radius: 6px;
  cursor: ${props => props.disabled ? 'not-allowed' : 'pointer'};
  opacity: ${props => props.disabled ? 0.6 : 1};
  
  transition: all 0.2s ease-in-out;
  
  &:hover:not(:disabled) {
    transform: translateY(-1px);
    box-shadow: 0 4px 8px rgba(0,0,0,0.1);
  }
  
  &:active:not(:disabled) {
    transform: translateY(0);
  }
`;

const Spinner = styled.div`
  width: 16px;
  height: 16px;
  border: 2px solid transparent;
  border-top: 2px solid currentColor;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  margin-right: 8px;
  
  @keyframes spin {
    to { transform: rotate(360deg); }
  }
`;

const Button = ({ 
  variant = 'primary',
  size = 'medium',
  disabled = false,
  loading = false,
  onClick,
  children,
  ...props 
}) => {
  return (
    <StyledButton
      variant={variant}
      size={size}
      disabled={disabled || loading}
      onClick={onClick}
      {...props}
    >
      {loading && <Spinner />}
      {children}
    </StyledButton>
  );
};

export default Button;
```

</details>

### 🥈 Ejercicio 2: Layout Responsive

#### Objetivo
Crear un layout adaptable usando CSS Grid y Flexbox.

#### Prompt Principal
```jsx
// components/layout/AppLayout.jsx
// Layout principal de la aplicación:
// - Header fijo con navegación responsive (hamburger menu en mobile)
// - Sidebar colapsable en desktop, drawer en mobile
// - Main content area con padding apropiado
// - Footer sticky al bottom
// Breakpoints: mobile (768px), tablet (1024px), desktop (1200px+)
// Usar CSS-in-JS o CSS modules
```

#### Navegación Responsive
```jsx
// components/layout/Navigation.jsx
// Componente de navegación que se adapte:
// Desktop: horizontal navbar con dropdowns
// Tablet: navbar compacta con iconos
// Mobile: hamburger menu con sidebar
// Incluir indicador de página activa
// Smooth transitions entre estados
```

## 🔧 Sección 2: Estado y Lógica

### 🥇 Ejercicio 3: Hooks Personalizados

#### Objetivo
Crear hooks reutilizables para lógica común.

#### Custom Hooks a Implementar

**1. useAPI Hook:**
```jsx
// hooks/useAPI.js
// Hook para manejar llamadas a APIs:
// - Parámetros: url, options
// - Estados: data, loading, error
// - Funciones: refetch, mutate
// - Cache automático con localStorage
// - Cleanup para evitar memory leaks
// - Retry automático en caso de error
```

**2. useLocalStorage Hook:**
```jsx
// hooks/useLocalStorage.js
// Hook para persistir estado en localStorage:
// - Sincronización entre tabs
// - Serialización automática de objetos
// - Valores por defecto
// - Cleanup automático
// - TypeScript support
```

**3. useDebounce Hook:**
```jsx
// hooks/useDebounce.js
// Hook para debouncing de valores:
// - Útil para búsquedas en tiempo real
// - Delay configurable
// - Cleanup automático
// - Optimización de renders
```

#### Implementación de useAPI

<details>
<summary>Ver implementación completa</summary>

```jsx
// hooks/useAPI.js
import { useState, useEffect, useCallback, useRef } from 'react';

const useAPI = (url, options = {}) => {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const abortControllerRef = useRef(null);

  const fetchData = useCallback(async (customUrl = url, customOptions = {}) => {
    try {
      setLoading(true);
      setError(null);

      // Abort previous request
      if (abortControllerRef.current) {
        abortControllerRef.current.abort();
      }

      // Create new abort controller
      abortControllerRef.current = new AbortController();

      const response = await fetch(customUrl, {
        signal: abortControllerRef.current.signal,
        ...options,
        ...customOptions,
        headers: {
          'Content-Type': 'application/json',
          ...options.headers,
          ...customOptions.headers,
        },
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const result = await response.json();
      setData(result);
      return result;
    } catch (err) {
      if (err.name !== 'AbortError') {
        setError(err.message);
        console.error('API Error:', err);
      }
    } finally {
      setLoading(false);
    }
  }, [url, options]);

  const refetch = useCallback(() => {
    return fetchData();
  }, [fetchData]);

  const mutate = useCallback((newData) => {
    setData(newData);
  }, []);

  useEffect(() => {
    if (url) {
      fetchData();
    }

    // Cleanup function
    return () => {
      if (abortControllerRef.current) {
        abortControllerRef.current.abort();
      }
    };
  }, [fetchData, url]);

  return { data, loading, error, refetch, mutate, fetchData };
};

export default useAPI;
```

</details>

### 🥈 Ejercicio 4: Gestión de Estado Global

#### Objetivo
Implementar estado global usando Context API y useReducer.

#### Prompt para Estado Global
```jsx
// context/AppContext.jsx
// Sistema de estado global para aplicación de e-commerce:
// Estados a gestionar:
// - user: información del usuario autenticado
// - cart: items en el carrito de compras
// - products: lista de productos
// - ui: loading states, modals, notifications
// 
// Acciones:
// - LOGIN, LOGOUT para usuario
// - ADD_TO_CART, REMOVE_FROM_CART, CLEAR_CART
// - SET_PRODUCTS, ADD_PRODUCT, UPDATE_PRODUCT
// - SHOW_LOADING, HIDE_LOADING, SHOW_NOTIFICATION
//
// Usar useReducer para lógica compleja
// Crear hooks específicos: useAuth, useCart, useProducts
```

#### Context con TypeScript (opcional)
```tsx
// Si usas TypeScript, prompt para tipos:
// Definir tipos TypeScript para:
// - User interface
// - Product interface
// - CartItem interface
// - AppState interface
// - Action types union
// Crear context tipado con valores por defecto
```

## 🌐 Sección 3: Integración con APIs

### 🥇 Ejercicio 5: Dashboard de Datos

#### Objetivo
Crear un dashboard que consuma APIs y muestre datos en tiempo real.

#### Funcionalidades del Dashboard
```jsx
// pages/Dashboard.jsx
// Dashboard administrativo con:
// 1. Cards de métricas principales (ventas, usuarios, productos)
// 2. Gráficos de líneas para trends temporales
// 3. Tabla de datos con paginación y filtros
// 4. Actualización automática cada 30 segundos
// 5. Estados de loading y error bien manejados
// 6. Responsive design para mobile/tablet
```

#### Componentes de Gráficos
```jsx
// components/charts/LineChart.jsx
// Componente de gráfico de líneas usando Chart.js o Recharts:
// - Props: data, xKey, yKey, color, title
// - Responsive y animado
// - Tooltip informativo
// - Legend configurable
// - Export to image functionality
```

#### Integración con API Real
```jsx
// services/api.js
// Servicio para conectar con APIs:
// - Base URL configurable por environment
// - Interceptors para autenticación automática
// - Manejo de refresh tokens
// - Retry logic para requests fallidos
// - Request/response logging en desarrollo
```

### 🥈 Ejercicio 6: Formularios Avanzados

#### Objetivo
Implementar formularios complejos con validación.

#### Prompt para Formulario de Producto
```jsx
// components/forms/ProductForm.jsx
// Formulario complejo para crear/editar productos:
// Campos:
// - Nombre (requerido, min 3 chars)
// - Descripción (textarea, max 500 chars)
// - Precio (number, mayor que 0)
// - Categoría (select con opciones de API)
// - Imágenes (drag & drop multiple files)
// - Tags (input con autocomplete)
// - Disponible (checkbox)
//
// Funcionalidades:
// - Validación en tiempo real
// - Autosave cada 30 segundos
// - Preview de imágenes
// - Submit con confirmación
// - Estados de loading/success/error
```

#### Custom Hook para Formularios
```jsx
// hooks/useForm.js
// Hook reutilizable para gestión de formularios:
// - Manejo automático de valores
// - Validación con reglas personalizables
// - Dirty state tracking
// - Reset functionality
// - Submit handling con async support
// - Error state management
```

## 🎭 Sección 4: Testing y Optimización

### 🥇 Ejercicio 7: Testing Comprehensivo

#### Objetivo
Implementar tests unitarios y de integración.

#### Setup de Testing
```bash
# Configurar testing environment
npm install -D @testing-library/react @testing-library/jest-dom @testing-library/user-event vitest jsdom
```

#### Prompts para Tests
```jsx
// tests/components/Button.test.jsx
// Tests comprehensivos para componente Button:
// 1. Renderizado básico con diferentes props
// 2. Handling de eventos click
// 3. Estados disabled y loading
// 4. Variantes de styling
// 5. Accessibility testing
// Usar React Testing Library best practices
```

```jsx
// tests/hooks/useAPI.test.js
// Tests para custom hook useAPI:
// 1. Fetch exitoso con datos mock
// 2. Manejo de errores HTTP
// 3. Loading states
// 4. Abort requests al unmount
// 5. Refetch functionality
// Usar mock service worker para APIs
```

### 🥈 Ejercicio 8: Optimización de Performance

#### Objetivo
Implementar técnicas de optimización para mejor rendimiento.

#### Técnicas de Optimización
```jsx
// Optimizaciones a implementar:
// 1. React.memo para prevenir re-renders innecesarios
// 2. useMemo y useCallback para computaciones costosas
// 3. Lazy loading de componentes con React.lazy
// 4. Virtualization para listas largas
// 5. Image optimization con lazy loading
// 6. Code splitting por rutas
// 7. Service worker para caching
```

#### Prompt para Lazy Loading
```jsx
// components/LazyImage.jsx
// Componente para lazy loading de imágenes:
// - Intersection Observer API
// - Placeholder mientras carga
// - Error fallback
// - Progressive enhancement
// - Responsive images con srcset
// - Optimización de formato (WebP fallback)
```

## 🚀 Proyecto Final: E-Commerce Frontend

### Objetivo
Crear una aplicación completa de e-commerce que integre todos los conceptos.

### Arquitectura del Proyecto
```
ecommerce-frontend/
├── public/
├── src/
│   ├── components/
│   │   ├── ui/           # Componentes reutilizables
│   │   ├── layout/       # Layout components
│   │   ├── forms/        # Form components
│   │   └── charts/       # Chart components
│   ├── pages/
│   │   ├── Home.jsx
│   │   ├── Products.jsx
│   │   ├── ProductDetail.jsx
│   │   ├── Cart.jsx
│   │   ├── Checkout.jsx
│   │   └── Dashboard.jsx
│   ├── hooks/            # Custom hooks
│   ├── context/          # Global state
│   ├── services/         # API services
│   ├── utils/            # Utility functions
│   ├── styles/           # Global styles
│   └── tests/            # Test files
├── package.json
└── vite.config.js
```

### Funcionalidades Principales

1. **Catálogo de Productos:**
   - Grid responsive de productos
   - Filtros y búsqueda avanzada
   - Paginación infinita
   - Vista de detalles con galería

2. **Carrito de Compras:**
   - Agregar/quitar productos
   - Actualizar cantidades
   - Persistencia en localStorage
   - Checkout flow completo

3. **Autenticación:**
   - Login/registro
   - Perfil de usuario
   - Historial de órdenes
   - Wishlist

4. **Dashboard Admin:**
   - Gestión de productos
   - Métricas y analytics
   - Gestión de órdenes
   - Reportes

### Prompts de Inicio para el Proyecto Final

**1. Setup Inicial:**
```
"Crear estructura completa de proyecto React para e-commerce con Vite, incluyendo configuración de routing, estado global, y arquitectura de componentes"
```

**2. Catálogo de Productos:**
```
"Implementar página de productos con grid responsive, filtros avanzados, búsqueda en tiempo real, y paginación infinita usando React Query"
```

**3. Carrito de Compras:**
```
"Crear sistema completo de carrito: Context para estado, persistencia localStorage, animaciones de agregar/quitar, y mini-cart en header"
```

**4. Checkout Flow:**
```
"Implementar proceso de checkout multi-step: información personal, dirección de envío, método de pago, y confirmación con validación"
```

## 📱 Responsive Design y Accessibility

### Prompts para Responsive Design
```jsx
// Implementar sistema de breakpoints:
// - Mobile-first approach
// - Flexbox y CSS Grid
// - Typography responsive
// - Touch-friendly interfaces
// - Performance en devices móviles
```

### Accessibility (a11y)
```jsx
// Mejores prácticas de accesibilidad:
// - Semantic HTML elements
// - ARIA labels y roles
// - Keyboard navigation
// - Screen reader compatibility
// - Color contrast compliance
// - Focus management
```

## 🛠️ Herramientas de Desarrollo

### Storybook para Componentes
```bash
# Setup Storybook
npx storybook@latest init

# Prompt para stories:
# "Crear stories completas para todos los componentes UI con todos los estados y variantes posibles"
```

### DevTools y Debugging
```jsx
// Herramientas de debugging con Copilot:
// 1. React DevTools profiling
// 2. Console.log estratégico
// 3. Error boundaries
// 4. Performance monitoring
// 5. Bundle analyzer
```

## 📊 Métricas y Monitoring

### Performance Monitoring
```jsx
// Implementar métricas de performance:
// - Web Vitals tracking
// - User interaction analytics
// - Error tracking con Sentry
// - A/B testing framework
// - Real User Monitoring (RUM)
```

## 🎯 Siguiente Paso

Después de completar React, habrás cubierto las tres tecnologías principales:
- ✅ **C# - Backend Development**
- ✅ **Python - Data Science & Web APIs**  
- ✅ **React - Frontend Development**

### Proyectos Integradores Sugeridos
1. **Full-Stack E-Commerce:** React frontend + C# API backend
2. **Analytics Dashboard:** React frontend + Python FastAPI + ML models
3. **Multi-platform App:** React Native mobile + shared backend

## 📚 Recursos Adicionales

- [React Documentation](https://react.dev/)
- [React Router](https://reactrouter.com/)
- [React Query/TanStack Query](https://tanstack.com/query/)
- [React Testing Library](https://testing-library.com/docs/react-testing-library/intro/)
- [React Performance Best Practices](../docs/best-practices.md)

¡Felicitaciones por completar el tutorial completo de GitHub Copilot! 🎉