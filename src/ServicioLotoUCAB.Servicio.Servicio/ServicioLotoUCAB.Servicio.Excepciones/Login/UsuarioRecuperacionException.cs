using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>UsuarioRecuperacionException</c>
    /// Establece el error que el usuario está en estatus de recuperación de contraseña al ingresar.
    /// </summary>
    public class UsuarioRecuperacionException : LotoUcabException
    {
        /// <summary>
        /// Creación de la excepción llenando los datos necesarios para su posterior desencadenamiento.
        /// </summary>
        public UsuarioRecuperacionException()
        {
            Error = "Usuario en status de RECUPERACION. Debe modificar clave";
            Codigo = 12;
            ExcepcionOrigen = null;
        }
    }
}
