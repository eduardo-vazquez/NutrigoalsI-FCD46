using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoals
{
    public class DalAlimentoIngerido
    {

        public DalAlimentoIngerido()
        {
        }
        public string CreaNuevoAlimentoIngerido(AlimentoIngerido alim)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            dc.AlimentoIngeridos.InsertOnSubmit(alim);

            try
            {
                dc.SubmitChanges();
                return "Alimento registrado";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}