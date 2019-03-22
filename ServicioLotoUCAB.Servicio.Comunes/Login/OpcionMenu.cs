using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Comunes
{
    /// <summary>
    /// Class <c>OpcionMenu</c>
    /// Conforma la estructura de datos sobre una opción del menú dentro del dashboard especificando el medio de acción y su contexto.
    /// </summary>
    public class OpcionMenu : Entidad
    {
        /// <summary>
        /// Establece el nombre del tipo de opción.
        /// </summary>
        private string _nombre;
        /// <summary>
        /// Establece la descripción acerca de la opción dentro del dashboard.
        /// </summary>
        private string _descripcion;
        /// <summary>
        /// Establece el edio para la acción de interacción por esa opción.
        /// </summary>
        private string _url;
        /// <summary>
        /// Establece el dato de opción dentro de la base de datos.
        /// </summary>
        private int _posicion;
        /// <summary>
        /// Establece el status acerca de la opción para su acción dentro del sistema.
        /// </summary>
        private int _status;
        /// <summary>
        /// Establece la opción de menu de la cual surge el mismo.
        /// </summary>
        private int _opcionMenuPadre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int OpcionMenuPadre
        {
            get { return _opcionMenuPadre; }
            set { _opcionMenuPadre = value; }
        }
    }
}
