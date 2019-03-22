using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioLotoUCAB.Servicio.Comunes;
using System.Runtime.Serialization;

namespace ServicioLotoUCAB.Servicio.Servicio.Utilidades
{
    /// <summary>
    /// Class <c>RespuestaDashboard</c>
    /// Conforma la respuesta del dashboard luego de realizar el ingreso dentro del´sistema.
    /// </summary>
    public class RespuestaDashboard: Respuesta
    {
        /// <summary>
        /// Establece el tablero con la información necesaria para proceder y ejecutar los servicios dentro del sistema.
        /// </summary>
        private Dashboard _tablero;

        [DataMember]
        public Dashboard Tablero
        {
            get
            { return _tablero; }
            set
            { _tablero = value; }
        }
    }
}