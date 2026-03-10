using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoals
{
    public class DalObjetivosNutricionales
    {
        // Cargar los objetivos nutricionales más recientes del usuario
        public ObjetivosNutricionale CargaObjetivosNutricionales(int userId)
        {
            using (var dc = new NutriGoalsDataContext())
            {
                return dc.ObjetivosNutricionales.FirstOrDefault(u => u.FKIdUsuario == userId);
            }
        }
    }
}