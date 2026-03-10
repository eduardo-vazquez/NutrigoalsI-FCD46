using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using NutriGoals.DAL;

namespace NutriGoals
{
    public partial class RegistrarAlimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["id"] = 1; // Para pruebas
            txbFechaHora.Text = DateTime.Now.ToString();
            lblMensajeError.Text = "";
            lblMensajeError2.Text = "";
            //lblCodigoOFF.Text = "";
            //lblMarca.Text = "";

            if (!IsPostBack)
            {
                AgregarIngeridos();
                //txbFechaHora.Text = DateTime.Now.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void PintaDatosProducto()
        {
            string barcode = txbCodigoAlimento.Text.Trim();

            //Primero lo buscamos en nuestra tabla de alimentos y si no está vamos a la web de OFF

            Alimento miAlim = new Alimento();

            DALAlimento dal = new DALAlimento();
            if (dal.ExisteAlimento(barcode))
            {
                miAlim = dal.BuscaAlimento(barcode);

                // Mostramos los valores en pantalla
                lblNomProducto.Text = miAlim.Nombre; 
                  
                lblCalorias.Text = "Calorías por 100g: " + (int?)((float?)miAlim.Calorias100);
                lblProteinas.Text = "Proteínas por 100g: " + (float?)miAlim.Proteinas100;
                lblCarbohidratos.Text = "Carbohidratos por 100g: " + (float?)miAlim.Carbohidratos100;
                lblGrasa.Text = "Grasa por 100g: " + (float?)miAlim.Grasas100;

                // Mostramos la imagen si existe
                imgProducto.ImageUrl = miAlim.ImagenUrl;
  
                // Código OFF y marca
                lblCodigoOFF.Text = barcode;
                //lblMarca.Text = marcaProducto?.ToString();
                lblMarca.Text = "";

                //lblMensajeError.Text = "Obtenido de nuestra tabla";

                return;
            }

            // Registramos el alimento ingerido
            //AlimentoIngerido alInger = new AlimentoIngerido();
            //alInger.FKIdUsuario = int.Parse(Session["id"].ToString());


            //Lo buscamos en la web
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

            var codigoProducto = obj["code"];
            var marcaProducto = obj["product"]["brands"];

            // Mostramos los valores en pantalla
            lblNomProducto.Text = nombre.ToString();
            lblCalorias.Text = "Calorías por 100g: " + (int?)((float?)kcal / 4.184);
            lblProteinas.Text = "Proteínas por 100g: " + (float?)proteinas;
            lblCarbohidratos.Text = "Carbohidratos por 100g: " + (float?)carbohidratos;
            lblGrasa.Text = "Grasa por 100g: " + (float?)grasa;

            // Mostramos la imagen si existe
            var imagen = obj["product"]["image_url"];
            imgProducto.ImageUrl = imagen?.ToString();

            // Código OFF y marca
            lblCodigoOFF.Text = codigoProducto.ToString();
            lblMarca.Text = marcaProducto?.ToString();
        }

        public string ObtenerProductoOFF(string barcode)
        {
            try
            {
                string url = "https://world.openfoodfacts.org/api/v2/product/" + barcode;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
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

        public string ObtenerProductoOFFPorNombre(string nombreProducto)
        {
            try
            {
                string termino = HttpUtility.UrlEncode(nombreProducto);

                //string url = "https://world.openfoodfacts.org/cgi/search.pl" +
                string url = "https://es.openfoodfacts.org/cgi/search.pl" +
                             "?search_terms=" + termino +
                             "&search_simple=1&action=process&json=1&page_size=1";

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    string json = client.DownloadString(url);
                    return json;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        protected void btnBuscaAlimento_Click(object sender, EventArgs e)
        {
            bool esCodigo = txbCodigoAlimento.Text.All(char.IsDigit);
            if (esCodigo)
            {
                PintaDatosProducto();
            }
            else
            {
                //txbNombreAlimento.Text = txbCodigoAlimento.Text;
                PintaDatosProductoPorNombre();
            }
        }

        protected void btnRegistraAlim_Click(object sender, EventArgs e)
        {
            

            // Si el alimento no existe en la tabla local, lo insertamos
            Alimento miAlimento = new Alimento();
            //miAlimento.CodigoBarras = txbCodigoAlimento.Text.Trim();
            miAlimento.CodigoBarras = lblCodigoOFF.Text.Trim();
            miAlimento.Nombre = lblNomProducto.Text.Replace("Producto: ", "");
            miAlimento.Calorias100 = decimal.Parse(lblCalorias.Text.Replace("Calorías por 100g: ", ""));
            miAlimento.Proteinas100 = decimal.Parse(lblProteinas.Text.Replace("Proteínas por 100g: ", ""));
            miAlimento.Carbohidratos100 = decimal.Parse(lblCarbohidratos.Text.Replace("Carbohidratos por 100g: ", ""));
            miAlimento.Grasas100 = decimal.Parse(lblGrasa.Text.Replace("Grasa por 100g: ", ""));
            miAlimento.ImagenUrl = imgProducto.ImageUrl;

            DALAlimento dal = new DALAlimento();
            if (!dal.ExisteAlimento(miAlimento.CodigoBarras))
                lblMensajeError.Text = dal.CreaNuevoAlimento(miAlimento);
            else
                //lblMensajeError.Text = "No cargado, ya existe en la base de datos.";
                lblMensajeError.Text = "";

            // Registramos el alimento ingerido
            AlimentoIngerido alInger = new AlimentoIngerido();
            alInger.FKIdUsuario = int.Parse(Session["id"].ToString());
          
            alInger.FKIdAlimento = dal.BuscaIdAlimento(miAlimento.CodigoBarras);
            alInger.FechaHoraConsumo = DateTime.Parse(txbFechaHora.Text);
            alInger.CantidadGramos = decimal.Parse(txbCantidad.Text);
            
            DalAlimentoIngerido dalMiAlim = new DalAlimentoIngerido();
            string mensaje = dalMiAlim.CreaNuevoAlimentoIngerido(alInger);
            lblMensajeError2.Text = mensaje;

            AgregarIngeridos();
            //Response.Redirect("~/RegistrarActividad");
        }

        protected void btnBuscaAlimentoNombre_Click(object sender, EventArgs e)
        {
           
            PintaDatosProductoPorNombre();
        }

        

        

        void PintaDatosProductoPorNombre()
        {
            string nombreBuscado = txbCodigoAlimento.Text.Trim();   // TextBox con el nombre

            //Primero lo buscamos en nuestra tabla de alimentos y si no está vamos a la web de OFF

            Alimento miAlim = new Alimento();

            DALAlimento dal = new DALAlimento();
            miAlim = dal.BuscaNombreAlimento(nombreBuscado);

            if (miAlim != null)
            {
                // Mostramos los valores en pantalla
                lblNomProducto.Text = miAlim.Nombre;

                lblCalorias.Text = "Calorías por 100g: " + (int?)((float?)miAlim.Calorias100);
                lblProteinas.Text = "Proteínas por 100g: " + (float?)miAlim.Proteinas100;
                lblCarbohidratos.Text = "Carbohidratos por 100g: " + (float?)miAlim.Carbohidratos100;
                lblGrasa.Text = "Grasa por 100g: " + (float?)miAlim.Grasas100;

                // Mostramos la imagen si existe
                imgProducto.ImageUrl = miAlim.ImagenUrl;

                // Código OFF y marca
                lblCodigoOFF.Text = miAlim.CodigoBarras;
                //lblMarca.Text = marcaProducto?.ToString();
                lblMarca.Text = "";

                //lblMensajeError.Text = "Obtenido de nuestra tabla por nombre";

                return;
            }

            // Lo buscamos en la web

            string json = ObtenerProductoOFFPorNombre(nombreBuscado);

            if (string.IsNullOrEmpty(json))
            {
                lblCalorias.Text = "Error obteniendo datos.";
                return;
            }

            JObject obj = JObject.Parse(json);

            // El resultado de la búsqueda viene en un array: products
            JArray productos = (JArray)obj["products"];

            if (productos == null || productos.Count == 0)
            {
                lblNomProducto.Text = "No se han encontrado productos.";
                lblCalorias.Text = "";
                lblProteinas.Text = "";
                lblCarbohidratos.Text = "";
                lblGrasa.Text = "";
                imgProducto.ImageUrl = "";
                lblMarca.Text = "";
                lblCodigoOFF.Text = "";
                return;
            }

            // Cogemos el primer producto
            JObject prod = (JObject)productos[0];

            var nombre = prod["product_name"];
            var kcalKj = prod["nutriments"]["energy_100g"];              // kJ
            var proteinas = prod["nutriments"]["proteins_100g"];
            var carbohidratos = prod["nutriments"]["carbohydrates_100g"];
            var grasa = prod["nutriments"]["fat_100g"];
            var imagen = prod["image_url"];

            var codigoProducto = prod["code"];
            var marcaProducto = prod["brands"];

            // Conversión kJ → kcal (simple como ya hacías)
            float kcal = 0;
            if (kcalKj != null)
            {
                float kj = float.Parse(kcalKj.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                kcal = kj / 4.184f;
            }

            // Mostramos los valores en pantalla
            lblNomProducto.Text = nombre != null ? nombre.ToString() : "(sin nombre)";
            lblCalorias.Text = "Calorías por 100g: " + ((int)kcal);
            lblProteinas.Text = "Proteínas por 100g: " + proteinas;
            lblCarbohidratos.Text = "Carbohidratos por 100g: " + carbohidratos;
            lblGrasa.Text = "Grasa por 100g: " + grasa;

            // Imagen
            imgProducto.ImageUrl = imagen != null ? imagen.ToString() : "";

            // Código OFF y marca
            lblCodigoOFF.Text = codigoProducto.ToString();
            //lblMarca.Text = marcaProducto.ToString();

            lblMarca.Text = marcaProducto != null ? marcaProducto.ToString() : "";
        }


        private void AgregarIngeridos()
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var ingeridos = (from ing in dc.AlimentoIngeridos
                               join al in dc.Alimentos on ing.FKIdAlimento equals al.IdAlimento
                               where ing.FKIdUsuario == int.Parse(Session["id"].ToString())
                               orderby ing.FechaHoraConsumo descending
                               select new
                               {
                                   Alimento = al.Nombre,
                                   FechaHora = ing.FechaHoraConsumo,
                                   Cantidad = ing.CantidadGramos,
                                   Calorias = (int)(al.Calorias100*ing.CantidadGramos/100),
                                   Codigo = al.CodigoBarras
                               }).Take(25);
            
            ultimosIngeridos.DataSource = ingeridos;
            ultimosIngeridos.DataBind();
        }

        protected void txbCantidad_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}