using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Clase <c>FacebookException</c>
    /// Excepcion ocasinada por cualquier eventualidad en el facebook de error.
    /// </summary>
    public class FacebookException: LotoUcabException
    {
        /// <summary>
        /// Establece el error causado en el procedimiento de autorización por facebook, llenando los datos necesarios.
        /// </summary>
        /// <param name="ex">Excepcion origen de donde surge el error.</param>
        public static void Codigo202(Exception ex)
        {
            FacebookException exception = new FacebookException();
            exception.Codigo = 203;
            exception.Error = "Error al intentar ejecutar las peticiones al API facebook.";
            exception.ExcepcionOrigen = ex;
            throw exception;
        }
    }
}
