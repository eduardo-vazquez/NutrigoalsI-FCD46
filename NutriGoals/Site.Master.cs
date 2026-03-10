using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NutriGoals
{
    public partial class SiteMaster : MasterPage
    {
        public int PorcCalorias { get; set; }
        public int PorcProteinas { get; set; }
        public int PorcCarbohidratos { get; set; }
        public int PorcGrasas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                //Response.Redirect("~/Login.aspx");
                return;
            }
            // Valores por defecto (IMPORTANTE)
            PorcCalorias = 0;
            PorcProteinas = 0;
            PorcCarbohidratos = 50;
            PorcGrasas = 0;

            CargarPorcentajes((int)Session["id"]);
        }

        private void CargarPorcentajes(int idUsuario)
        {
            DateTime hoy = DateTime.Today;

            using (NutriGoalsDataContext dc = new NutriGoalsDataContext())
            {
                // ================= OBJETIVOS =================
                var objetivos = dc.ObjetivosNutricionales
                                  .FirstOrDefault(o => o.FKIdUsuario == idUsuario);

                if (objetivos == null)
                    return;

                // ================= INGESTA =================
                var ingesta = (from ing in dc.AlimentoIngeridos
                               join al in dc.Alimentos on ing.FKIdAlimento equals al.IdAlimento
                               where ing.FKIdUsuario == idUsuario
                                     && ing.FechaHoraConsumo.Date == hoy
                               select new
                               {
                                   Calorias = al.Calorias100 * ing.CantidadGramos / 100,
                                   Proteinas = al.Proteinas100 * ing.CantidadGramos / 100,
                                   Carbs = al.Carbohidratos100 * ing.CantidadGramos / 100,
                                   Grasas = al.Grasas100 * ing.CantidadGramos / 100
                               }).ToList();

                decimal totalCalorias = ingesta.Sum(x => x.Calorias);
                decimal totalProteinas = ingesta.Sum(x => x.Proteinas);
                decimal totalCarbs = ingesta.Sum(x => x.Carbs);
                decimal totalGrasas = ingesta.Sum(x => x.Grasas);

                // ================= EJERCICIO =================
                int caloriasEjercicio = dc.ActividadFisicas
                    .Where(a => a.FKIdUsuario == idUsuario && a.FechaHora.Date == hoy)
                    .Sum(a => (int?)a.CaloriasTotales) ?? 0;

                // Calorías netas
                decimal caloriasNetas = totalCalorias - caloriasEjercicio;
                if (caloriasNetas < 0) caloriasNetas = 0;

                // ================= PORCENTAJES =================
                PorcCalorias = Calcular(caloriasNetas, objetivos.CaloriasDiaObjetivo);
                PorcProteinas = Calcular(totalProteinas, objetivos.ProteinasDiaObjetivo);
                PorcCarbohidratos = Calcular(totalCarbs, objetivos.CarbohidratosDiaObjetivo);
                PorcGrasas = Calcular(totalGrasas, objetivos.GrasasDiaObjetivo);
            }
        }
        
        int Calcular(decimal actual, decimal objetivo)
        {
            if (objetivo <= 0) return 0;
            return Math.Min(100, (int)Math.Round((actual * 100M) / objetivo));
        }
    }
}