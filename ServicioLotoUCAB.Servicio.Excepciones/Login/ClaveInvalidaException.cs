using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>ClaveInvalidaException</c>
    /// Establece el error, por el cual la clave es inválida en la operación.
    /// </summary>
    public class ClaveInvalidaException : LotoUcabException
    {
        /// <summary>
        /// Realiza el procedimiento de creación con los datos necesarios reflejando el error.
        /// </summary>
        public ClaveInvalidaException()
        {
            Error = "Usuario o Clave invalida";
            Codigo = 12;
            ExcepcionOrigen = null;
        }
    }
}
