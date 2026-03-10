using NutriGoals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoal
{
    public class DalUserMetrica
    {
        public DalUserMetrica()
        {

        }

        public UserMetrica CargaUserMetricas(int userId)
        {
            using (var dc = new NutriGoalsDataContext())
            {
                return dc.UserMetricas.FirstOrDefault(u => u.FKIdUsuario == userId);
            }
        }
    }  
}