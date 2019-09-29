using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Establece el error que pueda estar generando al aplicar los hashes de encriptación de palabras.
    /// </summary>
    public class MD5Exception: LotoUcabException
    {
        /// <summary>
        /// Establece el error llenando los datos necesarios para su desencadenamiento.
        /// </summary>
        /// <param name="ex">Excepción origen por el cual se presenta la creación de este.</param>
        public MD5Exception(Exception ex)
        {
            Error = "Error en proceso de encriptado";
            Codigo = 1;
            ExcepcionOrigen = ex;
        }
    }
}
