using NutriGoals.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NutriGoals
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si aún no hay login hecho, redirige a la pagina de login
            if (Session["id"] == null)
                Response.Redirect("~/Login");

            if (!IsPostBack)
            {
                CargarDatosConsumidosHoy();
                CargarDatosEjerciciosHoy();
                CargarTotales();
            }
        }

        /// <summary>
        /// Método que se encarga de cargar los totales de Calorias, Proteinas, Carbohidratos y Grasas
        /// </summary>
        protected void CargarTotales()
        {
            DalObjetivosNutricionales dalObjetivosNutricionales = new DalObjetivosNutricionales();
            ObjetivosNutricionale on = dalObjetivosNutricionales.CargaObjetivosNutricionales(int.Parse(Session["id"].ToString()));
            LabCaloriasObjetivo.Text = Convert.ToInt32(on.CaloriasDiaObjetivo).ToString();
            LabProteinasObjetivo.Text = Convert.ToInt32(on.ProteinasDiaObjetivo).ToString();
            LabCarbohidratosObjetivo.Text = Convert.ToInt32(on.CarbohidratosDiaObjetivo).ToString();
            LabGrasasObjetivo.Text = Convert.ToInt32(on.GrasasDiaObjetivo).ToString();
        }

        /// <summary>
        /// Método que se encarga de cargar los alimentos consumidos hoy
        /// con sus Calorias, Proteinas, Carbohidratos y Grasas
        /// </summary>
        protected void CargarDatosConsumidosHoy()
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var consumidoHoy = (from alIng in dc.AlimentoIngeridos
                                join ali in dc.Alimentos on alIng.FKIdAlimento equals ali.IdAlimento
                                where alIng.FKIdUsuario == int.Parse(Session["id"].ToString())
                                && (alIng.FechaHoraConsumo >= DateTime.Today && alIng.FechaHoraConsumo <= DateTime.Today.AddDays(1))
                                orderby alIng.FechaHoraConsumo
                                select new
                                {
                                    Hora = alIng.FechaHoraConsumo.TimeOfDay,
                                    Cantidad = alIng.CantidadGramos,
                                    Alimento = ali.Nombre,
                                    Calorias = Convert.ToInt32(ali.Calorias100 * alIng.CantidadGramos / 100),
                                    Proteinas = Convert.ToInt32(ali.Proteinas100 * alIng.CantidadGramos / 100),
                                    Carbohidratos = Convert.ToInt32(ali.Carbohidratos100 * alIng.CantidadGramos / 100),
                                    Grasas = Convert.ToInt32(ali.Grasas100 * alIng.CantidadGramos / 100)
                                });
            listaConsumidoHoy.DataSource = consumidoHoy;
            listaConsumidoHoy.DataBind();

            if (consumidoHoy.Any())
            {
                LabCaloriasTotales.Text = Convert.ToInt32(consumidoHoy.Sum(x => x.Calorias)).ToString();
                LabProteinasTotales.Text = Convert.ToInt32(consumidoHoy.Sum(x => x.Proteinas)).ToString();
                if (LabCaloriasObjetivo == null)
                {
                    throw new Exception("LabCaloriasObjetivo es null");
                }
                else {
                    LabCarbohidratosTotales.Text = Convert.ToInt32(consumidoHoy.Sum(x => x.Carbohidratos)).ToString();
                }
                LabGrasasTotales.Text = Convert.ToInt32(consumidoHoy.Sum(x => x.Grasas)).ToString();
            }
        }

        /// <summary>
        /// Método que se encarga de cargar los datos de los ejercicios realizados hoy y suma 
        /// las calorias de estos a las totales objetivo
        /// </summary>
        protected void CargarDatosEjerciciosHoy()
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var actividades = (from act in dc.ActividadFisicas
                               join ej in dc.Ejercicios on act.FKIdEjercicio equals ej.IdEjercicio
                               where act.FKIdUsuario == int.Parse(Session["id"].ToString())
                               && (act.FechaHora >= DateTime.Today && act.FechaHora <= DateTime.Today.AddDays(1))
                               orderby act.FechaHora descending
                               select new
                               {
                                   Ejercicio = ej.Nombre,
                                   Hora = act.FechaHora.TimeOfDay,
                                   Duracion = act.TiempoMinutos,
                                   Calorias = act.CaloriasTotales
                               });
            listaActividadesHoy.DataSource = actividades;
            listaActividadesHoy.DataBind();

            if (actividades.Any()) {
               LabCaloriasEjercicios.Text = "+ " + Convert.ToInt32(actividades.Sum(x => x.Calorias)).ToString();
            }
        }
    }
}