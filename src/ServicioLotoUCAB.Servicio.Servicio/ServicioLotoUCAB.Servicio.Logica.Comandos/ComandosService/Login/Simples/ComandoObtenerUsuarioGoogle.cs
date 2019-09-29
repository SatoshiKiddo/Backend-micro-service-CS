using Google.Apis.Auth.OAuth2;
using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoObtenerUsuarioGoogle</c>.
    /// Ejecuta las acciones y los étodos para poder obtener a través de la Google API los datos del usuario luego de autenticarse..
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoObtenerUsuarioGoogle : Comando<Usuario>
    {
        /// <summary>
        /// Credenciales por el cual se puede acceder a los métodos de la API de Google.
        /// </summary>
        private UserCredential _credential;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="credential">Credenciales por el cual se puede acceder a los métodos de la API de Google.</param>
        public ComandoObtenerUsuarioGoogle(UserCredential credential)
        {
            _credential = credential;
        }

        /// <summary>
        /// Ejecuta el comando para obtener losdatos del usuario autenticado e ingresado al sistema.
        /// </summary>
        /// <returns>
        /// Retorna Usuario como predeterminación, esto incluso transformando los datos en los captados por el sistema.
        /// </returns>
        /// <exception cref="GoogleException">Tira esta excepción a causa de alguna problemática respecto al acceso de la GoogleAPI.</exception>
        public override Usuario Ejecutar()
        {
            DAOGoogleAuth auth = new DAOGoogleAuth();
            return auth.ObtenerUsuario(_credential);
        }
    }
}
