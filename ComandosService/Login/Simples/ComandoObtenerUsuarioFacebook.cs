using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login;
using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login.Simples
{
    /// <summary>
    /// Clase <c>ComandoObtenerUsuarioFacebook</c>
    /// Ejecución del acceso inmediato con la credencial de usuario a los métodos de la API de usuario oteninedo los datos.
    /// </summary>
    public class ComandoObtenerUsuarioFacebook : Comando<Usuario>
    {
        /// <summary>
        /// Token de verificación para el usuario por su ingreso a través de facebook
        /// </summary>
        private string _token;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        public ComandoObtenerUsuarioFacebook(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Ejecuta los procedimientos para obtener los datos del usuario de dicha API.
        /// </summary>
        /// <returns>Retona el usuario con su información necesaria.</returns>
        public override Usuario Ejecutar()
        {
            DAOFacebookAuth dao = FabricaDAO.crearDaoFacebookAuth();
            return dao.ObtenerUsuario(_token);
        }
    }
}
