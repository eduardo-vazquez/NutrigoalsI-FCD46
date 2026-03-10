# IFCD46 – NutriGoals (Technical Documentation)

## 1. Project Objective
NutriGoals is a web application for tracking eating habits and physical activity. It allows users to log meals and exercises, automatically calculate calories and macronutrients, consult recipes, and visualize daily progress through interactive charts.

The project is developed in **ASP.NET Web Forms** with **C#**, using a SQL database.

---

## 2. System Architecture

### 2.1 Technologies
- **Frontend:** HTML, CSS, Bootstrap, Font Awesome, ASP.NET Web Forms.
- **Backend:** .NET (C#), Code-behind per page (`.aspx.cs`).
- **Database:** SQL Server.
- **External APIs:** Open Food Facts.

### 2.2 General Structure
- **MasterPage (`Site.Master`)**: defines the navbar, footer with progress rings, and quick action menu.
- **ContentPages:** each specific page extends the MasterPage using `ContentPlaceHolderID="MainContent"`.
- **Main Modules:** food logging, activity logging, recipe lookup, history, user profile.
- **State Control:** ViewState and PostBack for forms, Repeaters for dynamic listings.

---

## 3. Pages and Components

### 3.1 Dashboard / Home
- Visualizes daily progress using **SVG rings** (calories, protein, carbohydrates, fats).
- **Central Button**: quick access to Home.
- **Submenu**: links to log food, log activity, and search recipes.
- **Real-time** data update by calculating calories consumed and burned.

### 3.2 Log Activity (`RegistrarActividad.aspx`)
- **Logging form** with:
  - Date/Time.
  - Activity selectable from a DropDownList.
  - Duration in minutes.
- **Automatic calculation of calories burned** based on activity type.
- **Repeater** to show recent activities.
- Validations: RequiredFieldValidator for mandatory fields.

### 3.3 Log Food (`RegistrarAlimento.aspx`)
- **Meal logging form**:
  - Food selection (with search by name or barcode).
  - Quantity in grams.
  - Date/Time of consumption.
- Automatically calculates calories and macronutrients.
- Saves logs in `RegistroComidas`.
- Repeaters to show history and selected foods.

### 3.4 Recipes (`Recetas.aspx`)
- **Recipe search** by name or ingredient.
- **Repeaters** for:
  - List of found recipes.
  - Food details for each recipe (quantity, macros, calories, barcode).
- Ability to log recipe foods directly into daily consumption.
- Integration with recipe and food APIs for nutritional information.

### 3.5 User Profile (`UserProfile.aspx`)
- Personal data and nutritional goals management:
  - Age, sex, weight, height.
  - Physical activity level.
  - Caloric goal and macronutrient distribution.
- Information is stored in `DetallesUsuarios`.

---

## 4. Calculation Logic

### 4.1 Daily Calories
The **Harris-Benedict Equation modified by activity level** is used:

BMR (men) = 66.47 + (13.75 * weight_kg) + (5 * height_cm) - (6.76 * age)
BMR (women) = 655.1 + (9.56 * weight_kg) + (1.85 * height_cm) - (4.68 * age)
Daily_Calories = BMR * activity_factor

- Activity factors:
  - Sedentary: 1.2
  - Light: 1.375
  - Moderate: 1.55
  - Intense: 1.725
  - Very intense: 1.9

### 4.2 Activity Logging
- Calculation of calories burned based on activity MET and duration.
- Subtracted from the daily caloric total to get energy balance.

### 4.3 Food Logging
- Retrieval of calories and macros from the local database or external APIs.
- Multiplication by consumed quantity in grams.
- Real-time progress ring update.

---

## 5. Database

### 5.1 `Usuarios` Table
- `ID_USUARIO`, `NOMBRE_USUARIO`, `CONTRASENA`.

### 5.2 `DetallesUsuarios` Table
- `ID_USUARIO`, `NOMBRE`, `APELLIDO`, `EDAD`, `SEXO`, `PESO`, `ALTURA`, `NIVEL_ACTIVIDAD_FISICA`, `OBJETIVO_NUTRICIONAL`, `CALORIAS_DIARIAS_OBJETIVO`, `PROTEINAS_DIARIAS_OBJETIVO`, `CARBOHIDRATOS_DIARIOS_OBJETIVO`, `GRASAS_DIARIAS_OBJETIVO`, `FECHA_CREACION`, `ULTIMA_ACTUALIZACION`.

### 5.3 `RegistroComidas` Table
- `ID_REGISTRO`, `ID_USUARIO`, `FECHA`, `HORA`, `ID_COMIDA`, `CANTIDAD`, `CALORIAS`, `PROTEINAS`, `CARBOHIDRATOS`, `GRASAS`.

### 5.4 `RegistroActividades` Table
- `ID_REGISTRO`, `ID_USUARIO`, `FECHA`, `HORA`, `TIPO_ACTIVIDAD`, `DURACION`, `INTENSIDAD`, `CALORIAS_QUEMADAS`.

---

## 6. Integrated APIs

| API | Use |
|-----|-----|
| Open Food Facts | Nutritional information and food barcode. |

---

## 7. Data Flow
1. User logs in → data loaded from `Usuarios` and `DetallesUsuarios`.
2. Food logging:
   - User selects food + quantity.
   - Backend calculates calories/macros → saves in `RegistroComidas`.
   - Dashboard updated.
3. Activity logging:
   - User enters type and duration.
   - Backend calculates calories burned → saves in `RegistroActividades`.
   - Dashboard updated.
4. Recipe lookup:
   - User searches for a recipe.
   - Recipe foods can be logged directly into `RegistroComidas`.
5. Dashboard shows progress on interactive rings (SVG and JS).

---

## 8. Project Structure
NutriGoals/
│-- Site.Master
│-- RegistrarActividad.aspx / .cs
│-- RegistrarAlimento.aspx / .cs
│-- Recetas.aspx / .cs
│-- UserProfile.aspx / .cs
│-- Home.aspx / .cs
│-- Scripts/ (JS and libraries)
│-- Content/ (CSS and assets)
│-- App_Code/ (shared logic)
│-- Web.config

- Each `.aspx` corresponds to a **functional page**.
- Each `.aspx.cs` contains the **backend logic** associated with the page.
- **MasterPage** defines navbar, interactive footer, and common layout structure.
