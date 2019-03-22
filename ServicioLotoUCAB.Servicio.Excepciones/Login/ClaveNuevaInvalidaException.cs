using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>ClaveNuevaInvalidaException</c>
    /// Establece el error por el cual se determina un error de que la nueva clave noes válida para la operación.
    /// </summary>
    public class ClaveNuevaInvalidaException : LotoUcabException
    {
        /// <summary>
        /// Realiza el procedimiento de creación con los campos requeridos para establecer el error.
        /// </summary>
        public ClaveNuevaInvalidaException()
        {
            Error = "Nuevas claves no coinciden";
            Codigo = 1;
            ExcepcionOrigen = null;
        }
    }
}
