using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>FormatoClaveException</c>
    /// Establece el error por el cual se conforma un formato de clave inválido.
    /// </summary>
    public class FormatoClaveException : LotoUcabException
    {
        /// <summary>
        /// Establece el error llenando los datos específicos para su desencadenamiento.
        /// </summary>
        public FormatoClaveException()
        {
            Error = "Formato de clave incorrecto. Debe poseer mayusculas, minusculas, digitos y caracteres especiales.";
            Error += " Debe poseer una longitud de 12 caracteres";
            Codigo = 12;
            ExcepcionOrigen = null;
        }
    }
}
