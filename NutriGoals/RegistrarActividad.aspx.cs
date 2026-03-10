using NutriGoals.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NutriGoals
{
    public partial class RegistrarActividad : System.Web.UI.Page
    {
        public List<ActividadFisica> actividades = new List<ActividadFisica>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si aún no hay login hecho, redirige a la pagina de login
            if (Session["id"] == null)
                Response.Redirect("~/Login");

            if (!IsPostBack)
            {
                AgregarActividades();
                CargaDatosEjercicios();
                TextBoxFechaHora.Text = DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// Método que se encarga de agregar en una lista las últimas actividades realizadas por el usuario
        /// </summary>
        private void AgregarActividades()
        {
            

            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var actividades = (from act in dc.ActividadFisicas
                               join ej in dc.Ejercicios on act.FKIdEjercicio equals ej.IdEjercicio
                               where act.FKIdUsuario == int.Parse(Session["id"].ToString())
                               orderby act.FechaHora descending
                               select new
                               {
                                   Ejercicio = ej.Nombre,
                                   FechaHora = act.FechaHora,
                                   Duracion = act.TiempoMinutos,
                                   Calorias = act.CaloriasTotales
                               }).Take(10);
            ultimasActividades.DataSource = actividades;
            ultimasActividades.DataBind();
        }

        /// <summary>
        /// Método que se encarga de cargar y rellenar el ComboBox de los ejercicios existentes en la tabla de ejercicios
        /// </summary>
        protected void CargaDatosEjercicios()
        {
            // Carga los datos de los ejercicios en el DropDownListEjercicios
            DalEjercicio dalEjercicio = new DalEjercicio();
            DropDownListEjercicios.DataSource = dalEjercicio.CargaTodosEjercicios();
            DropDownListEjercicios.DataTextField = "Nombre";
            DropDownListEjercicios.DataValueField = "IdEjercicio";
            DropDownListEjercicios.DataBind();
        }

        /// <summary>
        /// Método que se encarga de actualizar el numero de calorias según el ejercicio escogido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownListEjercicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            DalEjercicio dalEjercicio = new DalEjercicio();
            var ejercicio = int.Parse(DropDownListEjercicios.SelectedValue);
            LabelCaloriasEjercicio.Text = dalEjercicio.CargaCaloriasMinId(ejercicio).CaloriasPorMinuto.ToString() + " kCal/min";
        }

        /// <summary>
        /// Método que se encarga de realizar la acción del botón de crear/registrar una nueva actividad
        /// </summary>
        protected void ButtonCreaActividad_Click(object sender, EventArgs e)
        {
            ActividadFisica actividadFisica = new ActividadFisica();
            actividadFisica.FechaHora = DateTime.Parse(TextBoxFechaHora.Text);
            actividadFisica.FKIdUsuario = int.Parse(Session["id"].ToString());
            actividadFisica.FKIdEjercicio = int.Parse(DropDownListEjercicios.SelectedValue);
            actividadFisica.TiempoMinutos = decimal.Parse(TextBoxDuracion.Text);

            DalEjercicio dalEjercicio = new DalEjercicio();
            var caloriasMinuto = dalEjercicio.CargaCaloriasMinId(actividadFisica.FKIdEjercicio).CaloriasPorMinuto;
            actividadFisica.CaloriasTotales = Convert.ToInt32(caloriasMinuto * actividadFisica.TiempoMinutos);

            DalActividadFisica dalActividadFisica = new DalActividadFisica();
            dalActividadFisica.CreaNuevaActividad(actividadFisica);
            Response.Redirect("~/RegistrarActividad");
        }
    }
}