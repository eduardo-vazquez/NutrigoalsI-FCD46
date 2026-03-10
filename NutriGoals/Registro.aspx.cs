using NutriGoals.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppCIFO;

namespace NutriGoals
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que se encarga de realizar la acción del botón de registrar un nuevo usuario 
        /// </summary>
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            DalUsuario dalUsuario = new DalUsuario();
            Usuario usuario = dalUsuario.ExisteUsuarioEmail(TextBoxEmail.Text);

            if (usuario == null)
            {
                PasswordHelper.CreatePasswordHash(TextBoxPassword1.Text, out byte[] passwordHash, out byte[] passwordSalt);
                Usuario newUsuario = new Usuario();
                newUsuario.Email = TextBoxEmail.Text;
                newUsuario.PasswordHash = passwordHash;
                newUsuario.PasswordSalt = passwordSalt;
                dalUsuario.CreaDatosUsuario(newUsuario);

                Session["id"] = dalUsuario.ExisteUsuarioEmail(TextBoxEmail.Text).IdUsuario;
                Session["Nombre"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Usuario nuevo creado correctamente');", true);
                Response.Redirect("~/UserProfile");
            }
            else
            {
                Session["Nombre"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El email ya está registrado');", true);
                mensaje.Text = "El email ya está registrado";
            }
        }
    }
}