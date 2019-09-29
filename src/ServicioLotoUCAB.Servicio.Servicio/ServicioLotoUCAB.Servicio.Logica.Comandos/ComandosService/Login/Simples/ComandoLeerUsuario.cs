using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoLeerUsuario</c>.
    /// Ejecuta la operación de lecturar u obtención de un usuario desde la base de datos.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoLeerUsuario : Comando<Entidad>
    {
        /// <summary>
        /// Correo con el cual se puede obtener los datos del usuario dentro del sistema.
        /// </summary>
        private string _correo;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo con el cual se puede obtener los datos del usuario dentro del sistema, procedimiento query.</param>
        public ComandoLeerUsuario(string correo)
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
        /// <exception cref="MSQLException">Tira esta excepción a causa de alguna problemática causada por la base de datos.</exception>
        /// <exception cref="UsuarioInexistenteException">Tira esta excepción a causa de la inexistencia del usuario dentro del sistema.</exception>
        public override Entidad Ejecutar()
        {
            IDAOLogin dao = FabricaDAO.crearDaoLogin();
            Usuario user = (Usuario)dao.ConsultarUsuario(Correo);
            if (user != null) return user;
            throw new UsuarioInexistenteException();
        }
    }
}
