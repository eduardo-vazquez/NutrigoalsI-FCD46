using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoals
{
    public class DALAlimento
    {
        public DALAlimento()
        {
        }

        public string CreaNuevoAlimento(Alimento alim)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            dc.Alimentos.InsertOnSubmit(alim);

            try
            {
                dc.SubmitChanges();
                //return "Insert correcto";
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public bool ExisteAlimento(string codigo)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var usu = from e in dc.Alimentos
                      where e.CodigoBarras == codigo
                      select e;

            return usu.Any();
        }

        public int BuscaIdAlimento(string codigo) 
        {
            int idAlimento = -1;

            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var usu = from e in dc.Alimentos
                      where e.CodigoBarras == codigo
                      select e;
            
            if (usu.Any())
                idAlimento = usu.First().IdAlimento;
            
            return idAlimento;

        }

        public Alimento BuscaAlimento(string codigo)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var usu = from e in dc.Alimentos
                      where e.CodigoBarras == codigo
                      select e;

            if (usu.Any())
                return usu.First();
            else
                return null;
        }

        public Alimento BuscaNombreAlimento(string nombre)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var usu = from e in dc.Alimentos
                      where e.Nombre == nombre
                      select e;

            if (usu.Any())
                return usu.First();
            else
                return null;
        }


    }
}