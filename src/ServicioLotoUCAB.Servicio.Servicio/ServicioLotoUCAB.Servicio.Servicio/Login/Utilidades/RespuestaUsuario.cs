using ServicioLotoUCAB.Servicio.Comunes;
using System.Runtime.Serialization;

namespace ServicioLotoUCAB.Servicio.Servicio.Utilidades
{
    /// <summary>
    /// Class <c>RespuestaUsuario</c>
    /// Conforma la estructura de respuesta otorgando la información de usuario para eservicio.
    /// </summary>
    [DataContract]
    public class RespuestaUsuario : Respuesta
    {
        /// <summary>
        /// Establece el usuario con toda la información respectiva otorgada por la respuesta.
        /// </summary>
        private Usuario _usuario;

        [DataMember]
        public Usuario Usuario
        {
            get
            { return _usuario;}
            set
            { _usuario = value;}
        }
    }
}