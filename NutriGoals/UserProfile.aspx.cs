using NutriGoal;
using NutriGoals.DAL;
using System;
using System.Linq;

namespace NutriGoals
{
    public partial class UserProfile : System.Web.UI.Page
    {
        DalUsuario dalUsuario = new DalUsuario();
        DalObjetivosNutricionales dalObjNutri = new DalObjetivosNutricionales();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCampos();
            }
        }

        private void CargarCampos()
        {
            //Session["id"] = 1; 
            if (Session["id"] == null)
                Response.Redirect("~/Login");
            int idUsuario = int.Parse(Session["id"].ToString());

            // Cargar datos del usuario
            var usuario = dalUsuario.CargaDatosUsuario(idUsuario);
            if (usuario != null)
            {
                usrNombre.Text = usuario.Nombre;
                usrApellido1.Text = usuario.Apellido1;
                usrApellido2.Text = usuario.Apellido2;
                //usrEmail.Text = usuario.Email;
            }

            // Cargar objetivos nutricionales
            var objetivos = dalObjNutri.CargaObjetivosNutricionales(idUsuario);
            if (objetivos != null)
            {
                txtCalorias.Text = objetivos.CaloriasDiaObjetivo.ToString();
                txtProteinas.Text = objetivos.ProteinasDiaObjetivo.ToString();
                txtCarbohidratos.Text = objetivos.CarbohidratosDiaObjetivo.ToString();
                txtGrasas.Text = objetivos.GrasasDiaObjetivo.ToString();
            }
            else
            {
                // Mostrar alerta si no hay objetivos
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontraron objetivos nutricionales para este usuario.');", true);
            }

            // Cargar Metricas del usuario
            DalUserMetrica dalUserMetrica = new DalUserMetrica();
            var metrica = dalUserMetrica.CargaUserMetricas(idUsuario);
            if (metrica != null)
            {
                usrAltura.Text = metrica.AlturaCM.ToString();
                usrPeso.Text = metrica.PesoKG.ToString();
                usrNivelDeActividad.SelectedValue = metrica.NivelDeActividad.ToString();
                ddlSexo.SelectedValue = metrica.Sexo.ToString();
                if (metrica.FechaNacimiento.HasValue)
                {
                    usrFechaDeNacimiento.Text = metrica.FechaNacimiento.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    usrFechaDeNacimiento.Text = ""; // o algún valor por defecto
                }
            }


        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int idUsuario = int.Parse(Session["id"].ToString());

            if (!Page.IsValid)
            {
                return; // Detiene el método si algún validador falla
            }

            try
            {
                using (NutriGoalsDataContext db = new NutriGoalsDataContext())
                {
                    //############ GUARDAR DATOS USUARIOS
                    var usuarioExistente = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                    // Asignar valores desde los TextBox
                    usuarioExistente.Nombre = usrNombre.Text;
                    usuarioExistente.Apellido1 = usrApellido1.Text;
                    usuarioExistente.Apellido2 = usrApellido2.Text;
                    //usuarioExistente.Email = usrEmail.Text;

                    //############# GUARDAR METRICAS
                    var userMetricas = db.UserMetricas
                        .FirstOrDefault(u => u.FKIdUsuario == idUsuario);

                    if (userMetricas == null)
                    {
                        userMetricas = new UserMetrica();
                        userMetricas.FKIdUsuario = idUsuario;
                        db.UserMetricas.InsertOnSubmit(userMetricas);
                    }

                    int altura, peso, lev;

                    if (int.TryParse(usrAltura.Text, out altura))
                        userMetricas.AlturaCM = altura;

                    if (int.TryParse(usrPeso.Text, out peso))
                        userMetricas.PesoKG = peso;

                    userMetricas.Sexo = ddlSexo.SelectedValue[0];
                    userMetricas.FechaMedicion = DateTime.Now;

                    DateTime fechaNacimiento;
                    if (DateTime.TryParse(usrFechaDeNacimiento.Text, out fechaNacimiento))
                        userMetricas.FechaNacimiento = fechaNacimiento;

                    if (int.TryParse(usrNivelDeActividad.SelectedValue, out lev))
                        userMetricas.NivelDeActividad = lev;

                    if (int.TryParse(usrNivelDeActividad.SelectedValue, out lev))
                        userMetricas.NivelDeActividad = lev;

                    //############ GUARDAR OBJETIVOS NUTRICIONALES
                    var userObjetivosNutricionales = db.ObjetivosNutricionales.FirstOrDefault(u => u.FKIdUsuario == idUsuario);
                    if (userObjetivosNutricionales == null)
                    {
                        userObjetivosNutricionales = new ObjetivosNutricionale();
                        userObjetivosNutricionales.FKIdUsuario = idUsuario;
                        db.ObjetivosNutricionales.InsertOnSubmit(userObjetivosNutricionales);
                    }
                    int calorias, proteinas, carbohidratos, grasas;
                    if (int.TryParse(txtCalorias.Text, out calorias))
                        userObjetivosNutricionales.CaloriasDiaObjetivo = calorias;

                    if (int.TryParse(txtProteinas.Text, out proteinas))
                        userObjetivosNutricionales.ProteinasDiaObjetivo = proteinas;

                    if (int.TryParse(txtCarbohidratos.Text, out carbohidratos))
                        userObjetivosNutricionales.CarbohidratosDiaObjetivo = carbohidratos;

                    if (int.TryParse(txtGrasas.Text, out grasas))
                        userObjetivosNutricionales.GrasasDiaObjetivo = grasas;
                    // Guardar cambios (insert o update)
                    db.SubmitChanges();
                }

                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Datos guardados correctamente');", true);


            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error al guardar: {ex.Message}');", true);
            }

            
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("~/Login");
        }
    }
}
