using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioLotoUCAB.Servicio.Servicio.Utilidades
{
    /// <summary>
    /// Class <c>Respuesta</c>
    /// Conforma la respuesta estándar otorgada por el usuario.
    /// </summary>
    [DataContract]
    public class Respuesta
    {
        /// <summary>
        /// Establece el status de respuesta, siendo el código del mismo.
        /// </summary>
        protected int _statusRespuesta;
        /// <summary>
        /// Establece la descripción de la respuesta, logrando establecer cualquier tipo de acción dentro del servicio.
        /// </summary>
        protected string _descripcion;
        /// <summary>
        /// Establece el error atrapada dentro de la ejecución del servicio.
        /// </summary>
        protected string _error;

        [DataMember]
        public int StatusResp
        {
            get { return _statusRespuesta; }
            set { _statusRespuesta = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        [DataMember]
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

    }
}