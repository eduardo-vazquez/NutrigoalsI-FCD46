using NutriGoals.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppCIFO;

namespace NutriGoals
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que se encarga de realizar la acción del botón de hacer Login 
        /// </summary>
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            DalUsuario dalUsuario = new DalUsuario();
            Usuario usuario = dalUsuario.ExisteUsuarioEmail(TextBoxEmail.Text);

            if (usuario != null)
            {
                if (PasswordHelper.VerifyPasswordHash(TextBoxPassword.Text, usuario.PasswordHash.ToArray(), usuario.PasswordSalt.ToArray()))
                {
                    Session["id"] = usuario.IdUsuario;
                    Session["Nombre"] = usuario.Nombre;
                    Session["Rol"] = "user";
                    Response.Redirect("~/Home");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password incorrecto');", true);
                    Session["id"] = 0;
                    Session["Nombre"] = null;
                    mensaje.Text = "Password incorrecto";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email incorrecto');", true);
                Session["id"] = 0;
                Session["Nombre"] = null;
                mensaje.Text = "Email incorrecto";
            }
        }
    }
}