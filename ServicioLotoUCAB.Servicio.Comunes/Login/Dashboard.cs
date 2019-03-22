using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Comunes
{
    /// <summary>
    /// Class <c>Dashboard</c>
    /// Establece un objeto respuesta ante un servicio específico del módulo de ingreso.
    /// </summary>
    public class Dashboard : Entidad
    {
        /// <summary>
        /// Establece las opciones de menu permitidas para el usuario dentro del sistema.
        /// </summary>
        private List<OpcionMenu> _opciones;
        /// <summary>
        /// Establece el usuario que ingresó al sistema y está incluido dentro del dashboard como presentación de información.
        /// </summary>
        private Usuario _usuario;

        /// <summary>
        /// Creación del dashboard con las opciones de menú permitidas por el usuario.
        /// </summary>
        public Dashboard()
        {
            Opciones = new List<OpcionMenu>();
        }

        /// <summary>
        /// Creación del dashboard con las opciones de menú permitidas incluyendo el usuario integrando la presentación e información.
        /// </summary>
        /// <param name="opciones">Opciones de menú permitidas para el usuario.</param>
        /// <param name="usuario">Usuario que integra la información en el dashboard.</param>
        public Dashboard(List<OpcionMenu> opciones, Usuario usuario)
        {
            Opciones = opciones;
            Usuario = usuario;
        }

        public List<OpcionMenu> Opciones
        {
            get { return _opciones; }
            set { _opciones = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
    }
}
