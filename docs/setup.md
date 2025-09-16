# Tutorial Completo de GitHub Copilot - Configuración Detallada

## 🛠️ Configuración Paso a Paso

### 1. Instalación de GitHub Copilot

#### Para Visual Studio Code (Recomendado)

1. **Abre Visual Studio Code**
2. **Ve a Extensions** (`Ctrl+Shift+X` o `Cmd+Shift+X`)
3. **Busca "GitHub Copilot"**
4. **Instala las siguientes extensiones:**
   - `GitHub Copilot` - Autocompletado de código IA
   - `GitHub Copilot Chat` - Chat interactivo con IA

#### Para JetBrains IDEs (IntelliJ, PyCharm, etc.)

1. **Ve a File → Settings → Plugins**
2. **Busca "GitHub Copilot"**
3. **Instala el plugin oficial**
4. **Reinicia el IDE**

#### Para Visual Studio (Windows)

1. **Ve a Extensions → Manage Extensions**
2. **Busca "GitHub Copilot"**
3. **Instala la extensión**
4. **Reinicia Visual Studio**

### 2. Autenticación

#### Método 1: Desde VS Code
1. **Abre VS Code**
2. **Presiona `Ctrl+Shift+P`** para abrir Command Palette
3. **Escribe "GitHub Copilot: Sign In"**
4. **Sigue las instrucciones en el navegador**
5. **Autoriza la aplicación en GitHub**

#### Método 2: Desde GitHub.com
1. **Ve a [github.com/settings/copilot](https://github.com/settings/copilot)**
2. **Activa tu suscripción de Copilot**
3. **Configura las preferencias**

### 3. Verificación de Configuración

Crea un archivo de prueba para verificar que todo funciona:

#### Test en JavaScript
```javascript
// test-copilot.js
// Función que suma dos números
function sumar(a, b) {
    // Copilot debería autocompletar: return a + b;
}

// Función que encuentra el número mayor en un array
function encontrarMayor(numeros) {
    // Presiona Tab para aceptar la sugerencia de Copilot
}
```

#### Test en Python
```python
# test-copilot.py
# Función para calcular el factorial de un número
def factorial(n):
    # Copilot generará la implementación

# Función para verificar si un número es primo
def es_primo(numero):
    # Deja que Copilot complete la lógica
```

#### Test en C#
```csharp
// test-copilot.cs
// Clase para gestionar una lista de estudiantes
public class GestorEstudiantes
{
    // Copilot generará propiedades y métodos
}
```

### 4. Configuración Avanzada

#### Configurar Copilot en VS Code

Abre **Settings** (`Ctrl+,`) y busca "copilot":

```json
{
    "github.copilot.enable": {
        "*": true,
        "yaml": false,
        "plaintext": false,
        "markdown": true
    },
    "github.copilot.inlineSuggest.enable": true,
    "github.copilot.advanced": {
        "secret_key": "your-key-here",
        "length": 500,
        "temperature": 0.5,
        "top_p": 1,
        "stop": ["\n\n"]
    }
}
```

#### Atajos de Teclado Personalizados

Ve a **File → Preferences → Keyboard Shortcuts** y busca "copilot":

```json
[
    {
        "key": "ctrl+shift+a",
        "command": "github.copilot.generate",
        "when": "editorTextFocus"
    },
    {
        "key": "ctrl+shift+c",
        "command": "github.copilot.acceptInlineCompletion",
        "when": "editorTextFocus"
    }
]
```

### 5. Configuración por Proyecto

#### .vscode/settings.json
```json
{
    "github.copilot.enable": {
        "javascript": true,
        "typescript": true,
        "python": true,
        "csharp": true,
        "json": false
    },
    "github.copilot.inlineSuggest.enable": true,
    "github.copilot.advanced": {
        "length": 300,
        "temperature": 0.3
    }
}
```

### 6. Configuración de Entornos de Desarrollo

#### Para C# (.NET)

```bash
# Verificar instalación
dotnet --version

# Instalar SDK si es necesario
# Windows: https://dotnet.microsoft.com/download
# macOS: brew install dotnet
# Linux: sudo apt-get install dotnet-sdk-8.0

# Crear proyecto de prueba
dotnet new console -n CopilotTest
cd CopilotTest
dotnet run
```

#### Para Python

```bash
# Verificar instalación
python --version
pip --version

# Crear entorno virtual
python -m venv copilot-env

# Activar entorno
# Windows:
copilot-env\Scripts\activate
# macOS/Linux:
source copilot-env/bin/activate

# Instalar paquetes esenciales
pip install pandas numpy matplotlib seaborn fastapi uvicorn jupyter
```

#### Para React/Node.js

```bash
# Verificar instalación
node --version
npm --version

# Instalar/actualizar Node.js si es necesario
# Windows/macOS: https://nodejs.org/
# Linux: sudo apt-get install nodejs npm

# Crear proyecto React
npx create-react-app copilot-react-test
cd copilot-react-test
npm start
```

### 7. Extensiones Complementarias

#### VS Code Extensions Recomendadas

```json
{
    "recommendations": [
        "ms-vscode.vscode-typescript-next",
        "ms-python.python",
        "ms-dotnettools.csharp",
        "bradlc.vscode-tailwindcss",
        "formulahendry.auto-rename-tag",
        "christian-kohler.path-intellisense",
        "ms-vscode.live-server",
        "ritwickdey.liveserver"
    ]
}
```

### 8. Solución de Problemas Comunes

#### Copilot No Aparece

1. **Verifica la autenticación:**
   ```
   Ctrl+Shift+P → "GitHub Copilot: Check Status"
   ```

2. **Verifica la suscripción:**
   - Ve a [github.com/settings/billing](https://github.com/settings/billing)
   - Confirma que tienes Copilot activo

3. **Reinicia VS Code:**
   - Cierra completamente VS Code
   - Abre de nuevo

#### Sugerencias No Relevantes

1. **Mejora el contexto:**
   ```javascript
   // ❌ Poco contexto
   function calc() {}
   
   // ✅ Mejor contexto
   // Función para calcular el interés compuesto anual
   function calcularInteresCompuesto(principal, tasa, tiempo) {}
   ```

2. **Usa nombres descriptivos:**
   ```python
   # ❌ Nombres genéricos
   def process(data): pass
   
   # ✅ Nombres específicos
   def procesar_datos_ventas_mensuales(datos_ventas): pass
   ```

#### Copilot Muy Lento

1. **Verifica la conexión a internet**
2. **Cierra pestañas/aplicaciones innecesarias**
3. **Reduce la longitud de sugerencias:**
   ```json
   {
       "github.copilot.advanced": {
           "length": 200
       }
   }
   ```

### 9. Configuración de Red/Proxy

#### Para Entornos Corporativos

```json
{
    "http.proxy": "http://proxy.company.com:8080",
    "http.proxyStrictSSL": false,
    "github.copilot.advanced": {
        "proxy": "http://proxy.company.com:8080"
    }
}
```

### 10. Verificación Final

Ejecuta este checklist para confirmar que todo está funcionando:

- [ ] ✅ GitHub Copilot instalado y activado
- [ ] ✅ Autenticación exitosa con GitHub
- [ ] ✅ Sugerencias aparecen al escribir código
- [ ] ✅ Chat de Copilot responde (`Ctrl+I`)
- [ ] ✅ Entornos de desarrollo configurados (C#, Python, React)
- [ ] ✅ Atajos de teclado funcionando
- [ ] ✅ Sin errores en la consola de VS Code

### 11. Primeros Pasos Recomendados

Una vez configurado, empieza con estos ejercicios básicos:

1. **Prueba autocompletado básico**
2. **Experimenta con Copilot Chat**
3. **Completa el [Ejercicio de Introducción](introduction.md#ejercicio-práctico-de-introducción)**
4. **Elige tu tecnología preferida y comienza los ejercicios específicos**

### 🎯 ¿Todo Listo?

Si has completado esta configuración exitosamente, ¡estás listo para comenzar el tutorial!

**Próximos pasos:**
- 📖 [Introducción a GitHub Copilot](introduction.md)
- 🔧 [C# - Desarrollo Backend](../csharp/README.md)
- 🐍 [Python - Ciencia de Datos y Web](../python/README.md)
- ⚛️ [React - Desarrollo Frontend](../react/README.md)

---

**¿Problemas con la configuración?** Abre un issue en este repositorio y te ayudaremos.