# IFCD46-nutrigoals

## OBJETIVO DEL PROYECTO 
NutriGoal es una web para el seguimiento de habitos alimenticios y actividades fisicas.

### DISEÑOGENEAL Y ARQUITECTURA:

- [ ] Frontend: HTML, CSS.
- [ ] Backend: .Net (C#).
- [ ] Base de Datos: SQL.
- [ ] Integracion con API de alimentos: Open Food Facts API.
- [ ] Autenticacion mediante OAuth 2.0 y OpenID Connect (OIDC)

### FUNCIONALIDADES:
- [ ] El usuario puede crear una cuenta e iniciar sesion. 
- [ ] Poder cargar las necesidades caloricas y de macronutrientes diarias segun los objetivos del usuario.
- [ ] El usuario podra definir sus necesidades nutricionales en la aplicacion, utilizando formulas estandarizadas, segun su edad, sexo, peso, altura y nivel de actividad fisica.
- [ ] El usuario podra registrar sus comidas diarias, especificando los alimentos consumidos y sus cantidades. Esto se podra hacer mediante una base de datos de alimentos integrada en la aplicacion (https://world.openfoodfacts.org/data).
- [ ] El sistema calculara automaticamente las calorias y macronutrientes consumidos en cada comida y los sumara al total diario del usuario.
- [ ] Se podra visualizar como van las calorias y macronutrientes consumidos a traves de circulos de progreso.
- [ ] El usuario podra registrar sus actividades fisicas diarias, especificando el tipo de actividad, duracion e intensidad.
- [ ] El sistema calculara automaticamente las calorias quemadas en cada actividad fisica y las restara del total diario del usuario.
- [ ] Todo esto se ira actualizando a tiempo real.
- [ ] El usuario podra ver un historial de sus registros diarios, semanales y mensuales, para analizar su progreso a lo largo del tiempo.
- [ ] El usario podra consultar recetas a partir de ingredientes que tenga en casa y cada receta mostrara informacion nutricional, para incorporar a su plan alimenticio.
- [ ]  Visualizar lo comido cuanto significa en actividad fisica. Eso se podria elegir la quivalencia con el tipo de actividad. <- INTERESANTE
- [ ]  Los eccesos en cal diario enviar alarma.

### MOCKUPS

[FIGMA] (https://www.figma.com/design/9MciY2F8rPhQxvWKaUKYMR/NutriGoals?node-id=0-1&m=dev&t=Rs223yUgBAosNcQZ-1)

[GRAFICO ER] [https://drive.google.com/file/d/1vBRKAZvVdviYHMCfmnoOfEtlbhZ-jMs1/view?usp=sharing]

### TAREAS PRINCIPALES (divididas en sprints):

[TRELLO] (https://trello.com/invite/b/68f649e434c65abca57be625/ATTI4f0930a755cd5857f273b4a3e41c29b83AF2183C/)

#### SPRINT 1:
- [ ] Configuracion del entorno de desarrollo.
- [ ] Diseño de la base de datos.
- [ ] Implementacion del sistema de autenticacion y gestion de usuarios.
- [ ] Configuración del repositorio, control de versiones y documentación inicial

#### SPRINT 2:
- [ ] Implementacion del registro y seguimiento de comidas.
- [ ] Coneccion con la base de datos de alimentos.
- [ ] Implementacion del calculo automatico de calorias y macronutrientes.
- [ ] Pruebas unitarias y de integracion para las funcionalidades implementadas.

#### SPRINT 3:
- [ ] Implementacion del registro y seguimiento de actividades fisicas.
- [ ] Implementacion del calculo automatico de calorias quemadas.
- [ ] Pruebas unitarias y de integracion para las funcionalidades implementadas.


#### SPRINT 4:
- [ ] Implementacion del historial de registros diarios, semanales y mensuales.
- [ ] Desarrollo de la interfaz de usuario para la visualizacion del historial.
- [ ] Pruebas unitarias y de integracion para las funcionalidades implementadas.

#### SPRINT 5:
- [ ] Implementacion de la funcionalidad de recetas basadas en ingredientes disponibles.
- [ ] Integracion de la informacion nutricional en las recetas.
- [ ] Desarrollo de la interfaz de usuario para la visualizacion de recetas.

#### SPRINT 6:
- [ ] Desarrollo de la interfaz de usuario para todas las funcionalidades.
- [ ] Pruebas de usabilidad y ajustes en la interfaz de usuario.

### DISEÑO DE BASE DE DATOS

TABLA DE USUARIOS:
- ID_USUARIO
- NOMBRE_USUARIO 
- CONTRASENA

TABLA USARIOS_DETALLES:
- ID_USUARIO
- NOMBRE
- APELLIDO
- EDAD
- SEXO
- PESO
- ALTURA
- NIVEL_ACTIVIDAD_FISICA
- OBJETIVO_NUTRICIONAL
- CALORIAS_DIARIAS_OBJETIVO
- PROTEINAS_DIARIAS_OBJETIVO
- CARBOHIDRATOS_DIARIOS_OBJETIVO
- GRASAS_DIARIAS_OBJETIVO
- FECHA_CREACION
- ULTIMA_ACTUALIZACION

TABLA REGISTRO_COMIDAS:
- ID_REGISTRO
- ID_USUARIO
- FECHA
- HORA
- ID_COMIDA (DESDE BASE DE DATOS DE ALIMENTOS)
- CANTIDAD
- CALORIAS
- PROTEINAS
- CARBOHIDRATOS
- GRASAS

TABLA REGISTRO_ACTIVIDADES:
- ID_REGISTRO
- ID_USUARIO
- FECHA
- HORA
- TIPO_ACTIVIDAD
- DURACION
- INTENSIDAD
- CALORIAS_QUEMADAS


APIs para la base de datos de alimentos:

Open Food Facts 
API	Base de datos colaborativa y abierta con millones de productos alimenticios. 
Permite recuperar ingredientes, valores nutricionales (calorías, macros, alérgenos…) usando por ejemplo el código de barras. 

FoodData Central API (del USDA)	
Fuente pública de composición de alimentos: datos de nutrientes de muchos alimentos genéricos y procesados. 
Datos en dominio público (CC0), lo que facilita su uso libre.

CalorieNinjas API	
API gratuita con datos nutricionales (calorías, macros) de muchos alimentos y recetas; útil si buscas algo sencillo y rápido de integrar. 
calorieninjas.com

Recipe API (API?Ninjas)	
API para acceder a un catálogo amplio de recetas, lo que puede servir como base para el módulo de “elaboración de recetas” de tu proyecto. 
api-ninjas.com



