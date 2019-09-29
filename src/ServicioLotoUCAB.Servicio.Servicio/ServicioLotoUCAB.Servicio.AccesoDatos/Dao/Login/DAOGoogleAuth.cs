using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login.Utilidades;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using System;
using System.Collections.Generic;
using System.Threading;
using static Google.Apis.Plus.v1.Data.Person;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login
{
    /// <summary>
    /// Clase <c>DAOGoogleAuth</c>.
    /// Esta clase contiene todo los métodos de acceso a los procedimientos y autenticaciones a través de Google obteniendo datos y controlándolos.
    /// </summary>
    public class DAOGoogleAuth : DAOAuth
    {
        /// <summary>
        /// Establece la inicialización de datos y validaciones para el acceso de permisos por parte de Google.
        /// </summary>
        public DAOGoogleAuth()
        {
            Initialize();
        }
        private void Initialize()
        {
            this._applicationName = "Cliente web 1";
            this._clientId = "781078004250-iqnrgojm07pvnmd2ck2fmv3uhragdndg.apps.googleusercontent.com";
            this._clientSecret = "l7-G37147TOHvWx9oyVNGKFG";
            string[] ScopesGoogle =
            {
                PlusService.Scope.UserinfoProfile
            };
            this._scopes = ScopesGoogle;
        }

        /// <summary>
        /// Método para controlar y obtener los datos necesarios para la creación de un usuario en el sistema.
        /// </summary>
        /// <param name="credential">Establece las credenciales necesarias para el acceso a los datos.</param>
        /// <returns>Retorna el usuario con el control y redirección de los datos obtenidos por la API.</returns>
        /// <exception cref="GoogleException">Tira esta excepción cuando ocurre alguna problemática dentro del procedimiento.</exception>
        public Usuario ObtenerUsuario(UserCredential credential)
        {
            Person dataRetrieve = null;
            try
            {
                PlusService service = new PlusService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Plus Sample",
                });
                GmailService serviceMail = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Gmail Sample",
                });
                PeopleResource.GetRequest personRequest = service.People.Get("me");
                var me = serviceMail.Users.GetProfile("me").Execute();
                dataRetrieve = personRequest.Execute();
                EmailsData email = new EmailsData();
                email.Value = me.EmailAddress;
                email.Type = "acount";
                dataRetrieve.Emails = new List<EmailsData>();
                if (!dataRetrieve.Emails.Contains(email))
                    dataRetrieve.Emails.Add(email);
            }
            catch (Exception ex)
            {
                GoogleException.Codigo202(ex);
            }
            return PersonConvert.CrearUsuario(dataRetrieve);
        }

        /// <summary>
        /// El método realiza los procedimientos necesarios para poder obtener los credenciales cuando el usuario realiza la autenticación.
        /// </summary>
        /// <param name="error">Establece el error que se obtiene al realiza el procedimiento</param>
        /// <returns>Retorna las credenciales del usuario e Google para poder tener acceso a los datos.</returns>
        /// <exception cref="GoogleException">Tira esta excepción cuando ocurre alguna problemática dentro del procedimiento.</exception>
        public UserCredential GetUserCredential(out string error)
        {
            this.Initialize();
            UserCredential credential = null;
            error = string.Empty;
            try
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = _clientId,
                    ClientSecret = _clientSecret
                },
                this._scopes,
                Environment.UserName,
                CancellationToken.None,
                new FileDataStore("Google Oaut2")).Result;
            }
            catch (Exception)
            {
                GoogleException.Codigo201("Error desconocido al realizar la conexión con Google.");
            }
            return credential;
        }
    }
}
