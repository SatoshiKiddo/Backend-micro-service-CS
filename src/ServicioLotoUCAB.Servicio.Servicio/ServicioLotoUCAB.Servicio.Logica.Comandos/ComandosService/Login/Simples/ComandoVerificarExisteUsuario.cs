using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoVerificarExisteUsuario</c>.
    /// Ejecuta únicamente la verificación de la existencai de un usario con acceso a la base de datos.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoVerificarExisteUsuario : Comando<bool>
    {
        /// <summary>
        /// Correo por el cual se realizará la verificación de la existencia de usuario.
        /// </summary>
        private string _correo;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo por el cual se realizará la verificación de la existencia de usuario.</param>
        public ComandoVerificarExisteUsuario(string correo)
        {
            Correo = correo;
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        /// <summary>
        /// Ejecuta el comando para validar el formulario de registro.
        /// </summary>
        /// <returns>
        /// Retorna 0 como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="MSQLException">Tira esta excepción a causa de la problemática con las operaciones ejecutadas en la base de datos.</exception>
        public override bool Ejecutar()
        {
            IDAOLogin dao = FabricaDAO.crearDaoLogin();
            Usuario user = (Usuario)dao.ConsultarUsuario(Correo);
            return (user != null);
        }
    }
}
