using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>UsuarioRegistradoException</c>
    /// Establece el error de cuando un usuaro quiere registrarse y el mismo ya lo está.
    /// </summary>
    public class UsuarioRegistradoException : LotoUcabException
    {
        /// <summary>
        /// Creación de la excepción llenando los datos necesarios para su posterior desencadenamiento.
        /// </summary>
        public UsuarioRegistradoException()
        {
            Error = "Correo ya registrado en el sistema";
            Codigo = 1;
            ExcepcionOrigen = null;
        }
    }
}
