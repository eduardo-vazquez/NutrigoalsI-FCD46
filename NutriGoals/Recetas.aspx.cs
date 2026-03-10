using Microsoft.Ajax.Utilities;
using NutriGoals.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NutriGoals
{
    public partial class Recetas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si aún no hay login hecho, redirige a la pagina de login
            if (Session["id"] == null)
                Response.Redirect("~/Login");

            if (!IsPostBack)
            {
                // Si se carga esta pagina, con una receta "elegida"...
                if (Request.QueryString["id"] != null)
                {
                    var id = Int32.Parse(Request.QueryString["id"]);
                    MuestraAlimentosReceta(id);
                    listaAlimentosReceta.Visible = true;

                    DalReceta dalReceta = new DalReceta();
                    LabelReceta.Text = "Alimentos de la receta: " + dalReceta.CargaRecetaPorId(id).Nombre.ToString();
                    LabelReceta.Visible = true;
                    // Elementos para registrar el consumo de esta receta
                    LabelCantidad.Visible = true;
                    TextBoxCantidad.Visible = true;
                    LabelFechaHora.Visible = true;
                    TextFechaHora.Text = DateTime.Now.ToString();
                    TextFechaHora.Visible = true;
                    ButtonAñadirAlimentos.Text = "Registrar " + dalReceta.CargaRecetaPorId(id).Nombre.ToString();
                    ButtonAñadirAlimentos.Visible = true;
                }
            }
        }

        /// <summary>
        /// Método que se ejecuta al hacer clic en el boton buscar o salir del textboxbusca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            listaAlimentosReceta.Visible = false;

            DalReceta dalReceta = new DalReceta();
            var recetas = dalReceta.CargaRecetasNombre(TextBoxBusca.Text);
            listaRecetasBuscadas.DataSource = recetas;
            listaRecetasBuscadas.DataBind();
        }

        /// <summary>
        /// Método que se encarga de buscar los alimentos de la idreceta y mostrarlos en la tabla de alimentos
        /// </summary>
        /// <param name="id"></param>
        protected void MuestraAlimentosReceta(int id)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var alimentos = from alim in dc.Alimentos
                            join lista in dc.ListaIngredientes on alim.IdAlimento equals lista.FKIdAlimento
                            where lista.FKIdReceta == id
                            select new
                            {
                                Nombre = alim.Nombre,
                                CantidadGR = lista.CantidadGRMS,
                                Calorias100 = alim.Calorias100,
                                Proteinas100 = alim.Proteinas100,
                                Carbohidratos100 = alim.Carbohidratos100,
                                Grasas100 = alim.Grasas100,
                                CodigoBarras = alim.CodigoBarras
                            };
            listaAlimentosReceta.DataSource = alimentos;
            listaAlimentosReceta.DataBind();
        }

        /// <summary>
        /// Método que añade todos los alimentos de una receta, teniendo en cuenta la cantidad ingerida de la receta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAñadirAlimentos_Click(object sender, EventArgs e)
        {
            DalAlimentoIngerido dalAlimentoIngerido = new DalAlimentoIngerido();

            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var ingredientes = (from lista in dc.ListaIngredientes
                                where lista.FKIdReceta == Int32.Parse(Request.QueryString["id"])
                                select lista).ToList();

            // Por cada uno de los alimentos de la receta...
            for (int i = 0; i < ingredientes.Count(); i++)
            {
                AlimentoIngerido aliIng = new AlimentoIngerido();
                aliIng.FKIdUsuario = int.Parse(Session["id"].ToString());
                aliIng.FKIdAlimento = ingredientes.ElementAt(i).FKIdAlimento;
                aliIng.FechaHoraConsumo = DateTime.Parse(TextFechaHora.Text);
                aliIng.CantidadGramos = Convert.ToInt32(int.Parse(TextBoxCantidad.Text) * ingredientes.ElementAt(i).CantidadGRMS / 100);
                dalAlimentoIngerido.CreaNuevoAlimentoIngerido(aliIng);
            }
        }
    }
}
