using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoals.DAL
{
    public class DalEjercicio
    {
        /// <summary>
        /// Constructor que no se utiliza
        /// </summary>
        public DalEjercicio() 
        {
        }

        /// <summary>
        /// Método que se encarga de cargar y devolver en una lista todos los ejercicios
        /// </summary>
        /// <returns></returns>
        public List<Ejercicio> CargaTodosEjercicios()
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var ejercicios = from ej in dc.Ejercicios
                        select ej;
            return ejercicios.ToList();
        }

        /// <summary>
        /// Método que devuelve el ejercicio buscado por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ejercicio CargaCaloriasMinId(int id)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var calorias = from ej in dc.Ejercicios
                           where ej.IdEjercicio == id
                           select ej;
            return calorias.FirstOrDefault();
        }
    }
}