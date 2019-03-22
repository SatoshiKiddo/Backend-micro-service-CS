using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Comunes
{
    /// <summary>
    /// Abstract Class <c>Entidad</c>
    /// Conforma la estructura de un dato de presentación de respuesta para englobar a cualquier para la respuesta de los servicios.
    /// </summary>
    public abstract class Entidad
    {
        /// <summary>
        /// Establece un id para identificación de la clase.
        /// </summary>
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
