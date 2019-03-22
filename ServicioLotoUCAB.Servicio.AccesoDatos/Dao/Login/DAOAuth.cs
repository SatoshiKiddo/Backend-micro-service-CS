using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login
{
    /// <summary>
    /// Clase Abstracta <c>DAOAuth</c>
    /// Esta clase establece el cuerpo y estructura del medio para la manipulación de APIS externas de autenticación Auth.
    /// </summary>
    public abstract class DAOAuth
    {
        /// <summary>
        /// Nombre de la aplicación dentro del sistema de Google.
        /// </summary>
        protected string _applicationName;
        /// <summary>
        /// El id del cliente para la implementación de la aplicación.
        /// </summary>
        protected string _clientId;
        /// <summary>
        /// Hash/clave para poder realizar cualquier acción válida con el sistema de Google.
        /// </summary>
        protected string _clientSecret;
        /// <summary>
        /// Usuario para manipular cualquier acceso y control de datos para la clase
        /// </summary>
        protected Usuario _usuario;
        /// <summary>
        /// Son los aspectos de medio para el acceso para la obtención de información.
        /// </summary>
        protected string[] _scopes;

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
    }
}
