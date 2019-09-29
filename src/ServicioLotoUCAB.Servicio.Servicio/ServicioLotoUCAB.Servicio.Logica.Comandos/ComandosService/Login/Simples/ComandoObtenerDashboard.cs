using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces;
using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoObtenerDashboard</c>.
    /// Ejecuta únicamente la operación para obtener los datos representados a ngreso del usuario.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoObtenerDashboard : Comando<Dashboard>
    {
        /// <summary>
        /// Correo por el cual se puede obtener el dashboard a través de las limitaciones de opción en la interfaz.
        /// </summary>
        private string _correo;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo por el cual se puede obtener el dashboard a través de las limitaciones de opción en la interfaz.</param>
        public ComandoObtenerDashboard(string correo)
        {
            Correo = correo;
        }

        /// <summary>
        /// Ejecuta el comando para realizar el método para obtener el dashboard.
        /// </summary>
        /// <returns>
        /// Retorna el dashboard con funcionalidad de obtener las limitaciones para el usuario en acción del sistema.
        /// </returns>
        /// <exception cref="MSQLException">Tira esta excepción a causa de alguna problemática respecto al acceso de la base de datos.</exception>
        public override Dashboard Ejecutar()
        {
            IDAOLogin dao = FabricaDAO.crearDaoLogin();
            return (Dashboard)dao.ConsultarDashboard(Correo);
        }
    }
}
