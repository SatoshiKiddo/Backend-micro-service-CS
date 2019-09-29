using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>UsuarioBloqueadoException</c>
    /// Establece el error cuando el usuario está bloqueado dentro del sistema.
    /// </summary>
    public class UsuarioBloqueadoException: LotoUcabException
    {
        /// <summary>
        /// Creación de la excepción llenando los datos necesaros para su desencadenamiento.
        /// </summary>
        public UsuarioBloqueadoException()
        {
            Error = "Este usuario ha sido bloqueado del sistema";
            Codigo = 10;
            ExcepcionOrigen = null;
        }
    }
}
