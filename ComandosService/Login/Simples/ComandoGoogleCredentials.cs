using Google.Apis.Auth.OAuth2;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoGoogleCredentials</c>.
    /// Ejecuta únicamente la obtención del token y la autorización de la cuenta de Google.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoGoogleCredentials : Comando<UserCredential>
    {
        private string _credentialError;

        /// <summary>
        /// Ejecuta el comando para otener las credenciales y validaciones de Google, autenticación externa.
        /// </summary>
        /// <returns>
        /// Retorna las credenciales a causa de la autenticación por medio de Google.
        /// </returns>
        /// <exception cref="GoogleException">Tira esta excepción a causa de una problemátca ajena a los conocimientos de 
        /// la aplicación respecto a google, pudiendo ser cualquier error respecto a su uso.</exception>
        public override UserCredential Ejecutar()
        {
            DAOGoogleAuth auth = new DAOGoogleAuth();
            _credentialError = string.Empty;
            return auth.GetUserCredential(out _credentialError);
        }
        public string CredentialError
        {
            get { return _credentialError; }
            set { _credentialError = value; }
        }
    }
}
