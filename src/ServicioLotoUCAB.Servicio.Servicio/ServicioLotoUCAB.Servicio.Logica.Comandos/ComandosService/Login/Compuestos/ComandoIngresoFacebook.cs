using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login.Simples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoIngresoFacebook</c>
    /// Comando de ejecución del ingreso por facebook, siendo compuesto por todas las eventualidades para cumplirse el mismo.
    /// </summary>
    public class ComandoIngresoFacebook : Comando<Entidad>
    {
        /// <summary>
        /// Token de verificación para el ingreso y uso de la API de facebook.
        /// </summary>
        private string _token;

        public string Token
        {
           get{ return _token; }
           set { _token = value; }
        }
        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        public ComandoIngresoFacebook(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Ejecuta los procedimientos para obtener el dashboard de información para el usuario a través del ingreso de Facebook
        /// </summary>
        /// <returns>Retorna el dashboard con toda la información necesaria para el usuario.</returns>
        public override Entidad Ejecutar()
        {
            string credentialError = string.Empty;
            Usuario user = null;
            Dashboard tablero = null;
            ComandoObtenerUsuarioFacebook getUsuario = FabricaComandos.FabricarComandoObtenerUsuarioFacebook(_token);
            user = getUsuario.Ejecutar();
            //verificar que no exista en la base de datos
            ComandoVerificarExisteUsuario verificador = FabricaComandos.FabricarComandoVerificarExisteUsuario(user.Correo);
            if (!verificador.Ejecutar())
            {
                //Registrar usuario si no existe
                ComandoRegistroUsuario registro = FabricaComandos.FabricarComandoRegistroUsuario(user);
                registro.Ejecutar();
            }
            //Obtener dashboard
            ComandoObtenerDashboard lectorDashboard = FabricaComandos.FabricarComandoObtenerDashboard(user.Correo);
            tablero = lectorDashboard.Ejecutar();
            return tablero;
        }
    }
}
