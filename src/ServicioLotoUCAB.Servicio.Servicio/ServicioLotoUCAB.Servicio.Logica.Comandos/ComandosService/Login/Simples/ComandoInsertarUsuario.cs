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
    /// Clase <c>ComandoInsertarUsuario</c>.
    /// Ejecuta únicamente la inserción de los usuarios, como funcionalidad de registro.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoInsertarUsuario : Comando<bool>
    {
        /// <summary>
        /// Usuario al cual se va a insertar en la base de datos.
        /// </summary>
        private Usuario _usuario;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="usuario">Usuario al cual se va a insertar en la base de datos.</param>
        public ComandoInsertarUsuario(Usuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Ejecuta el comando para realizar la inserción del usuario específico.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="MSQLException">Tira esta excepción a causa de algun problema relacionado de 
        /// la base de datos.</exception>
        public override bool Ejecutar()
        {
            IDAOLogin dao = FabricaDAO.crearDaoLogin();
            dao.InsertarUsuario(_usuario);
            return true;
        }
    }
}
