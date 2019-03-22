using Google.Apis.Plus.v1.Data;
using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Plus.v1.Data.Person;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login.Utilidades
{
    /// <summary>
    /// Clase <c>PersonConvert</c>.
    /// Esta clase contiene todo los métodos de conversión de los datos retornados por el GoogleAPI, controlando el llenado de usuario con la información adecuada.
    /// </summary>
    public class PersonConvert
    {
        /// <summary>
        /// Realiza la creación del usuario con los datos del PersonGoogle.
        /// </summary>
        /// <param name="user">Establece la estructura de datos obtenida por la API de Google.</param>
        /// <returns>
        /// Retorna el usuario con los datos válidos para su procedimiento a partir de la creación de los datos obtenidos de Google.
        /// </returns>
        /// <exception cref="LotoUcabException">Tira esta excepción debido a cualquier error reflejado con los métodos implementados dentro de la funcionalidad.</exception>
        public static Usuario CrearUsuario(Person user)
        {
            Usuario Res = new Usuario();
            Res.Nombre = user.Name.GivenName;
            Res.Apellido = user.Name.FamilyName;
            Res.Nombre_Usuario = user.Nickname;
            if (user.Emails != null)
                foreach (EmailsData email in user.Emails)
                {
                    if (email.Type.Equals("acount"))
                    {
                        Res.Correo = email.Value;
                        break;
                    }
                }
            Res.Clave = "GoogleUser";
            return Res;
        }
    }
}
