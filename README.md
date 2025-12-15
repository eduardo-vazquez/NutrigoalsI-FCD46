# IFCD46 – NutriGoals (Documentación Técnica)

## 1. Objetivo del Proyecto
NutriGoals es una aplicación web para el seguimiento de hábitos alimenticios y actividad física. Permite registrar comidas y ejercicios, calcular calorías y macronutrientes automáticamente, consultar recetas y visualizar el progreso diario del usuario mediante gráficos interactivos.  

El proyecto está desarrollado en **ASP.NET Web Forms** con **C#**, con base de datos SQL y consumo de APIs externas para alimentos y recetas.

---

## 2. Arquitectura del Sistema

### 2.1 Tecnologías
- **Frontend:** HTML, CSS, Bootstrap, Font Awesome, ASP.NET Web Forms.
- **Backend:** .NET (C#), Code-behind por página (`.aspx.cs`).
- **Base de datos:** SQL Server.
- **APIs externas:** Open Food Facts, FoodData Central (USDA), CalorieNinjas, Recipe API.
- **Autenticación:** OAuth 2.0 / OpenID Connect.
- **Gestión de scripts y bundles:** ScriptManager y WebOpt bundling.

### 2.2 Estructura general
- **MasterPage (`Site.Master`)**: define navbar, footer con anillos de progreso y menú de acciones rápidas.
- **ContentPages:** cada página concreta extiende MasterPage mediante `ContentPlaceHolderID="MainContent"`.
- **Módulos principales:** registro de alimentos, registro de actividades, consulta de recetas, historial, perfil de usuario.
- **Control de estados:** ViewState y PostBack para formularios, Repeaters para listados dinámicos.

---

## 3. Páginas y Componentes

### 3.1 Dashboard / Home
- Visualiza progreso diario mediante **SVG de anillos** (calorías, proteínas, carbohidratos, grasas).  
- **Botón central**: acceso rápido a Home.  
- **Submenu**: enlaces a registrar alimento, registrar actividad y buscar receta.  
- Actualización de datos en **tiempo real** mediante cálculo de calorías consumidas y quemadas.  

### 3.2 Registrar Actividad (`RegistrarActividad.aspx`)
- **Formulario de registro** con:
  - Fecha/Hora.
  - Actividad seleccionable desde DropDownList.
  - Duración en minutos.
- **Cálculo automático de calorías quemadas** según tipo de actividad.
- **Repeater** para mostrar últimas actividades.  
- Validaciones: RequiredFieldValidator para campos obligatorios.

### 3.3 Registrar Alimento (`RegistrarAlimento.aspx`)  
- **Formulario de registro de comida**:
  - Selección de alimento (con búsqueda por nombre o código de barras).
  - Cantidad en gramos.
  - Fecha/Hora de consumo.
- Calcula automáticamente calorías y macronutrientes.
- Guarda los registros en `RegistroComidas`.
- Repeaters para mostrar historial y alimentos seleccionados.

### 3.4 Recetas (`Recetas.aspx`)  
- **Búsqueda de recetas** por nombre o ingrediente.
- **Repeaters** para:
  - Listado de recetas encontradas.
  - Detalle de alimentos de cada receta (cantidad, macros, calorías, código de barras).
- Posibilidad de registrar alimentos de la receta directamente en el consumo diario.
- Integración con APIs de recetas y alimentos para obtener información nutricional.  

### 3.5 Perfil de Usuario (`UserProfile.aspx`)  
- Gestión de datos personales y objetivos nutricionales:
  - Edad, sexo, peso, altura.
  - Nivel de actividad física.
  - Objetivo calórico y distribución de macronutrientes.
- La información se almacena en `DetallesUsuarios`.

---

## 4. Lógica de Cálculo

### 4.1 Calorías Diarias
Se utiliza la **Ecuación de Harris-Benedict modificada por nivel de actividad**:

TMB (hombres) = 66.47 + (13.75 * peso_kg) + (5 * altura_cm) - (6.76 * edad)
TMB (mujeres) = 655.1 + (9.56 * peso_kg) + (1.85 * altura_cm) - (4.68 * edad)
Calorías_diarias = TMB * factor_actividad


- Factores de actividad:
  - Sedentario: 1.2
  - Ligero: 1.375
  - Moderado: 1.55
  - Intenso: 1.725
  - Muy intenso: 1.9  

### 4.2 Registro de Actividades
- Cálculo de calorías quemadas según MET de la actividad y duración.
- Se resta del total calórico diario para obtener balance energético.

### 4.3 Registro de Alimentos
- Obtención de calorías y macros desde la base de datos local o APIs externas.
- Multiplicación por cantidad consumida en gramos.
- Actualización de los anillos de progreso en tiempo real.

---

## 5. Base de Datos

### 5.1 Tabla `Usuarios`
- `ID_USUARIO`, `NOMBRE_USUARIO`, `CONTRASENA`.

### 5.2 Tabla `DetallesUsuarios`
- `ID_USUARIO`, `NOMBRE`, `APELLIDO`, `EDAD`, `SEXO`, `PESO`, `ALTURA`, `NIVEL_ACTIVIDAD_FISICA`, `OBJETIVO_NUTRICIONAL`, `CALORIAS_DIARIAS_OBJETIVO`, `PROTEINAS_DIARIAS_OBJETIVO`, `CARBOHIDRATOS_DIARIOS_OBJETIVO`, `GRASAS_DIARIAS_OBJETIVO`, `FECHA_CREACION`, `ULTIMA_ACTUALIZACION`.

### 5.3 Tabla `RegistroComidas`
- `ID_REGISTRO`, `ID_USUARIO`, `FECHA`, `HORA`, `ID_COMIDA`, `CANTIDAD`, `CALORIAS`, `PROTEINAS`, `CARBOHIDRATOS`, `GRASAS`.

### 5.4 Tabla `RegistroActividades`
- `ID_REGISTRO`, `ID_USUARIO`, `FECHA`, `HORA`, `TIPO_ACTIVIDAD`, `DURACION`, `INTENSIDAD`, `CALORIAS_QUEMADAS`.

---

## 6. APIs Integradas

| API | Uso |
|-----|-----|
| Open Food Facts | Información nutricional y código de barras de alimentos. |
| FoodData Central | Datos de nutrientes de alimentos genéricos y procesados. |
| CalorieNinjas | Datos de calorías y macronutrientes de alimentos y recetas. |
| Recipe API | Consulta de recetas y composición nutricional. |

---

## 7. Flujo de Datos
1. Usuario inicia sesión → datos cargados desde `Usuarios` y `DetallesUsuarios`.
2. Registro de comida:
   - Usuario selecciona alimento + cantidad.
   - Backend calcula calorías/macros → guarda en `RegistroComidas`.
   - Dashboard actualizado.
3. Registro de actividad:
   - Usuario ingresa tipo y duración.
   - Backend calcula calorías quemadas → guarda en `RegistroActividades`.
   - Dashboard actualizado.
4. Consulta de recetas:
   - Usuario busca receta → datos obtenidos de APIs.
   - Alimentos de receta pueden registrarse directamente en `RegistroComidas`.
5. Dashboard muestra progreso en anillos interactivos (SVG y JS).

---

## 8. Estructura de Proyecto
NutriGoals/
│-- Site.Master
│-- RegistrarActividad.aspx / .cs
│-- RegistrarAlimento.aspx / .cs
│-- Recetas.aspx / .cs
│-- UserProfile.aspx / .cs
│-- Home.aspx / .cs
│-- Scripts/ (JS y librerías)
│-- Content/ (CSS y assets)
│-- App_Code/ (lógica compartida)
│-- Web.config


- Cada `.aspx` corresponde a una **página funcional**.  
- Cada `.aspx.cs` contiene la **lógica de backend** asociada a la página.  
- **MasterPage** define navbar, footer interactivo y estructura de layout común.
