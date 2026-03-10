using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace NutriGoals.DAL
{
    public class DalActividadFisica
    {
        /// <summary>
        /// Constructor que no se utiliza
        /// </summary>
        public DalActividadFisica()
        {
        }

        /// <summary>
        /// Método que se encarga de insertar una nueva actividad física
        /// </summary>
        /// <param name="usuario"></param>
        public string CreaNuevaActividad(ActividadFisica actividadFisica)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            dc.ActividadFisicas.InsertOnSubmit(actividadFisica);

            try
            {
                dc.SubmitChanges();
                return "Insert correcto";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Método que se encarga de cargar todas las actividades físicas
        /// </summary>
        /// <returns></returns>
        public List<ActividadFisica> CargarTodasActividadesFisicas()
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var actividades = from act in dc.ActividadFisicas
                             select act;
            return actividades.ToList();
        }
    }
}