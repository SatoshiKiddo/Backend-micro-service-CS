using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>CamposInvalidosException</c>
    /// Especificación de los errores que puedan surgir por un formato inválido en uno de los campos en el formulario.
    /// </summary>
    public class CamposInvalidosException : LotoUcabException
    {
        /// <summary>
        /// Establece el error, pudiendo controlando la forma en que se expresa.
        /// </summary>
        /// <param name="campo">Establece el campo el cual ocurrió el error.</param>
        public static void CamposInvalidos(string campo)
        {
            CamposInvalidosException exception = new CamposInvalidosException();
            exception.Codigo = 8;
            exception.Error = "Campo invalido en el formulario: " + campo + ".";
            throw exception;
        }
    }
}
