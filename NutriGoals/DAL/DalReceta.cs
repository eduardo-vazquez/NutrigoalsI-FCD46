using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoals.DAL
{
    public class DalReceta
    {
        public DalReceta() 
        {
        }

        /// <summary>
        /// Método que devuelve la receta buscada por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Receta CargaRecetaPorId (int id)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var receta = from rec in dc.Recetas
                         where rec.IdReceta == id
                         select rec;
            return receta.FirstOrDefault();
        }

        /// <summary>
        /// Método que devuelve una lista de recetas, buscadas por una cadena en sus nombres
        /// </summary>
        /// <param name="buscar"></param>
        /// <returns></returns>
        public List<Receta> CargaRecetasNombre(string buscar)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var recetas = from rec in dc.Recetas
                          where rec.Nombre.Contains(buscar)
                          select rec;
            return recetas.ToList();
        }
    }
}