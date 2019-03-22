using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>CorreoInvalidoException</c>
    /// Establece el error, determinando que e coreo tien un formato inválido.
    /// </summary>
    public class CorreoInvalidoException : LotoUcabException
    {
        /// <summary>
        /// Establece el error, llenando los campos necesarios sin una excepción origen.
        /// </summary>
        public CorreoInvalidoException()
        {
            Error = "Formato de correo invalido";
            Codigo = 12;
            ExcepcionOrigen = null;
        }

        /// <summary>
        /// Establece el error, llenando los campos necesarios con una excepción origen.
        /// </summary>
        /// <param name="ex">Excepción origen el cual se registra para el desecadenamiento de esta propia excepción.</param>
        public CorreoInvalidoException(Exception ex)
        {
            Error = "Formato de correo invalido";
            Codigo = 12;
            ExcepcionOrigen = ex;
        }
    }
}
