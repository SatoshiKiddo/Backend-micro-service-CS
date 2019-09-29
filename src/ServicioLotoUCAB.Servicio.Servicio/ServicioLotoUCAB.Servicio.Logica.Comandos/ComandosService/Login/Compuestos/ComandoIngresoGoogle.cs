using Google.Apis.Auth.OAuth2;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoIngresoGoogle</c>.
    /// Comando compuesto que ejecuta todos los procedimientos para el objetivo puesto como clase: ingreso a través de Google.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoIngresoGoogle : Comando<Entidad>
    {

        /// <summary>
        /// Ejecuta el comando para validar todos los procedimientos y además de realizarlos para el posterior ingreso y disfrute de los servicios por parte de los usuarios.
        /// </summary>
        /// <returns>
        /// Retorna dashboard como predeterminación, esto conforma la informaciónde la interfaz mostrada al usuario después de autenticarse.
        /// </returns>
        /// <exception cref="LotoUcabException">Tira esta excepción como excepción padre, abarcando todas las posibles excepciones con la
        /// ejecución de los diversos comandos simples durante su realización.</exception>
        public override Entidad Ejecutar()
        {
            string credentialError = string.Empty;
            Usuario user = null;
            Dashboard tablero = null;
            //Obtener Credenciales
            ComandoGoogleCredentials getCredentials = FabricaComandos.FabricarComandoGoogleCredentials();
            UserCredential credential = getCredentials.Ejecutar();
            //Crear Usuario
            ComandoObtenerUsuarioGoogle getUsuario = FabricaComandos.FabricarComandoObtenerUsuarioGoogle(credential);
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
