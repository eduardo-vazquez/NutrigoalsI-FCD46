using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NutriGoals.DAL;



namespace NutriGoals
{
    public partial class BuscaAlimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscaAlimento_Click(object sender, EventArgs e)
        {
            PintaDatosProducto();
        }

        void PintaDatosProducto()
        {
            string barcode = txbCodAlimento.Text.Trim();

         
            string json = ObtenerProductoOFF(barcode);

            if (string.IsNullOrEmpty(json))
            {
                lblCalorias.Text = "Error obteniendo datos.";
                return;
            }

            // Convertir JSON a JObject
            JObject obj = JObject.Parse(json);

            // Obtenemos el nombre
            var nombre = obj["product"]["product_name"];

            // Obtenemos datos nutricionles
            var kcal = obj["product"]["nutriments"]["energy_100g"];
            var proteinas = obj["product"]["nutriments"]["proteins_100g"];
            var carbohidratos = obj["product"]["nutriments"]["carbohydrates_100g"];
            var grasa = obj["product"]["nutriments"]["fat_100g"];

            // Mostramos los valores en pantalla
            lblNomProducto.Text = nombre.ToString();
            lblCalorias.Text = "Calorías por 100g: " + (int?)((float?)kcal/4.184);
            lblProteinas.Text = "Proteínas por 100g: " + (float?)proteinas;
            lblCarbohidratos.Text = "Carbohidratos por 100g: " + (float?)carbohidratos;
            lblGrasa.Text = "Grasa por 100g: " + (float?)grasa;

            // Mostramos la imagen si existe
            var imagen = obj["product"]["image_url"];
            imgProducto.ImageUrl = imagen?.ToString();
        }

        public string ObtenerProductoOFF(string barcode)
        {
            try
            {
                string url = "https://world.openfoodfacts.org/api/v2/product/" + barcode;

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);

                    //System.Diagnostics.Debug.WriteLine(json);
                    return json;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        protected void btnCargaAlimento_Click(object sender, EventArgs e)
        { 
            Alimento miAlimento = new Alimento();
            miAlimento.CodigoBarras = txbCodAlimento.Text.Trim();
            miAlimento.Nombre = lblNomProducto.Text.Replace("Producto: ", "");
            miAlimento.Calorias100 = decimal.Parse(lblCalorias.Text.Replace("Calorías por 100g: ", ""));
            miAlimento.Proteinas100 = decimal.Parse(lblProteinas.Text.Replace("Proteínas por 100g: ", ""));
            miAlimento.Carbohidratos100 = decimal.Parse(lblCarbohidratos.Text.Replace("Carbohidratos por 100g: ", ""));
            miAlimento.Grasas100 = decimal.Parse(lblGrasa.Text.Replace("Grasa por 100g: ", ""));
            miAlimento.ImagenUrl = imgProducto.ImageUrl;

            DALAlimento dal = new DALAlimento();
            if(!dal.ExisteAlimento(miAlimento.CodigoBarras))
                lblMensajeError.Text =dal.CreaNuevoAlimento(miAlimento);
            else
            {
                lblMensajeError.Text = "No cargado, ya existe en la base de datos.";
            }
        }
    }

 }



