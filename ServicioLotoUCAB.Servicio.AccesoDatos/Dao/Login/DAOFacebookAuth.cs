using Facebook;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login
{
    /// <summary>
    /// Clase <c>DAOFacebookAuth</c>
    /// Establece el medio de interacción y de acceso a datos contra Facebook, siendo un medio de ingreso para el sistema.
    /// </summary>
    public class DAOFacebookAuth: DAOAuth
    {
        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el DAO.
        /// </summary>
        public DAOFacebookAuth()
        {
            Initialize();
        }

        /// <summary>
        /// Establecen los datos necesarios para la ejecución de los comandos.
        /// </summary>
        private void Initialize()
        {
            this._applicationName = "Cliente web 1";
            this._clientId = "377625239668090";
            this._clientSecret = "79f5990fe1bbde1b87d2278ff97557fd";
        }

        /// <summary>
        /// Medio por el cual se obtienen los datos del usuario por facebook
        /// </summary>
        /// <param name="token">Verificación de usuario y autenticidad: permiso de acceso.</param>
        /// <returns>Retorna el usuario con los datos necesarios para el sistema.</returns>
        public Usuario ObtenerUsuario( string token)
        {
            Usuario user = null;
            try
            {
                var fb = new FacebookClient();
                fb.AppId = this._clientId;
                fb.AppSecret = this._clientSecret;
                fb.AccessToken = token;

                dynamic me = fb.Get("me?fields=first_name,last_name,id,email");

                user = new Usuario();
                user.Nombre = me.first_name;
                user.Apellido = me.last_name;
                user.Numero_Identificacion = me.id;
                user.Correo = me.email;
                if (string.IsNullOrWhiteSpace(user.Correo))
                    FacebookException.Codigo202(null);
                user.Clave = "FacebookUser";

                return user;
            }
            catch (Exception e)
            {
                FacebookException.Codigo202(e);
            }
            return user;
        }
    }
}
