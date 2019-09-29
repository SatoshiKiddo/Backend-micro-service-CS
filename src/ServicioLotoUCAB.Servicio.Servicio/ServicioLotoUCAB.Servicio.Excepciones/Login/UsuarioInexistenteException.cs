using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>UsuarioInexistenteException</c>
    /// Establece el error especificando que el usuario es inexistente dentro del sistema.
    /// </summary>
    public class UsuarioInexistenteException : LotoUcabException
    {
        /// <summary>
        /// Creación de la excepción llenando los datos para posterior desencadenamiento.
        /// </summary>
        public UsuarioInexistenteException()
        {
            Error = "Usuario no registrado en el sistema";
            Codigo = 11;
            ExcepcionOrigen = null;
        }
    }
}
