using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriGoals.DAL
{
    public class DalUsuario
    {
        /// <summary>
        /// Contructor que no se utiliza
        /// </summary>
        public DalUsuario() 
        {
        }

        /// <summary>
        /// Método que se encarga de insertar un nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        public string CreaDatosUsuario(Usuario usuario)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            dc.Usuarios.InsertOnSubmit(usuario);

            try
            {
                dc.SubmitChanges();
                return "Insert correcto";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Método que se encarga de actualizar los datos de un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string ActualizaDatosUsuario(Usuario usuario)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var usu = from u in dc.Usuarios
                      where u.IdUsuario == usuario.IdUsuario
                      select u;
            Usuario usuario1 = usu.FirstOrDefault();

            usuario1.Email = usuario.Email;
            usuario1.Nombre = usuario.Nombre;
            usuario1.Apellido1 = usuario.Apellido1;
            usuario1.Apellido2 = usuario.Apellido2;

            try
            {
                dc.SubmitChanges();
                return "Actualización registro correcta";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Método que se encarga de cargar los datos de un usuario buscandolo por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario CargaDatosUsuario(int id)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var usu = from e in dc.Usuarios
                       where e.IdUsuario== id
                       select e;
            return usu.FirstOrDefault();
        }

        /// <summary>
        /// Método que se encarga de cargar los datos de un usuario buscandolo por su email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Usuario ExisteUsuarioEmail(string email)
        {
            NutriGoalsDataContext dc = new NutriGoalsDataContext();
            var usu = from e in dc.Usuarios
                       where e.Email == email
                       select e;
            return usu.FirstOrDefault();
        }
    }
}