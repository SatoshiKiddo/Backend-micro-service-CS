using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>GoogleException</c>
    /// Establece el error que se pueda presentar, englobando cualquier peculiaridad usando la API de Google.
    /// </summary>
    public class GoogleException : LotoUcabException
    {
        /// <summary>
        /// Establece el error llenando todos los datos necesarios para su desencadenamiento.
        /// </summary>
        /// <param name="error">Establece el error que se obtuvo en la ejecución de cualquier procedimiento.</param>
        public static void Codigo201(string error)
        {
            GoogleException exception = new GoogleException();
            exception.Codigo = 201;
            exception.Error = "No se obtuvo la autorización del usuario a través de Google - " + error;
            throw exception;
        }

        /// <summary>
        /// Establece el error llenando todos los datos necesarios para su deencadenamiento.
        /// </summary>
        /// <param name="ex">Establece la excepción origina por la cual se presenta la creación de este mo.</param>
        public static void Codigo202(Exception ex)
        {
            GoogleException exception = new GoogleException();
            exception.Codigo = 202;
            exception.Error = "Error al intentar ejecutar las peticiones al API google.";
            exception.ExcepcionOrigen = ex;
            throw exception;
        }
    }
}
