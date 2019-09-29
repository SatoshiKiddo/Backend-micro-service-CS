using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ServicioLotoUCAB.Servicio.Comunes
{
    /// <summary>
    /// Class <c>Usuario</c>
    /// Conforma la estructura de datos del usuario que integra dentro del sistema.
    /// </summary>
    public class Usuario: Entidad
    {
        /// <summary>
        /// Establece el id del tipo de usuario dentro de la base de datos.
        /// </summary>
        protected int _id_TipoUsuario;
        /// <summary>
        /// Establece el nombre del usuario dentro de la base de datos.
        /// </summary>
        protected string _nombre;
        /// <summary>
        /// Establece el apellido del usuario dentro de la base de datos.
        /// </summary>
        protected string _apellido;
        /// <summary>
        /// Establece el número de identificación del usuario dentro de la base de datos.
        /// </summary>
        protected string _numero_Identificacion;
        /// <summary>
        /// Establece el nombre de usuario dentro de la base de datos.
        /// </summary>
        protected string _nombre_Usuario;
        /// <summary>
        /// Establece el correo del usuario dentro de la base de datos.
        /// </summary>
        protected string _correo;
        /// <summary>
        /// Establece el status del usuario dentro de la base de datos.
        /// </summary>
        protected int _status;
        /// <summary>
        /// Establece la caducidad del usuario para la realización de ingresos dentro de la base de datos.
        /// </summary>
        protected int _caducidad;
        /// <summary>
        /// Establece la clave del usuario dentro de la base de datos.
        /// </summary>
        protected string _clave;

        public int Id_TipoUsuario
        {
            get { return _id_TipoUsuario; }
            set { _id_TipoUsuario = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Numero_Identificacion
        {
            get { return _numero_Identificacion; }
            set { _numero_Identificacion = value; }
        }

        public string Nombre_Usuario
        {
            get { return _nombre_Usuario; }
            set { _nombre_Usuario = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int Caducidad
        {
            get { return _caducidad; }
            set { _caducidad = value; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
    }
}
