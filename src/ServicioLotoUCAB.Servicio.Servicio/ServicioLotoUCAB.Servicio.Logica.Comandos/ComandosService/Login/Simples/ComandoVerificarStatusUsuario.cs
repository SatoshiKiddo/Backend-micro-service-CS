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
    /// Clase <c>ComandoVerificarStatusUsuario</c>.
    /// Ejecuta únicamente la verificación del status de usuario para pode conocer dicho atributo en el contexto del sistema.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoVerificarStatusUsuario : Comando<bool>
    {
        /// <summary>
        /// Establece el contexto en el que se encuentra el usuario.
        /// </summary>
        private int _status;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="status">Establece el contexto en el que se encuentra el usuario.</param>
        public ComandoVerificarStatusUsuario(int status)
        {
            Status = status;
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Ejecuta el comando para verificar el status de usuario.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="UsuarioRecuperacionException">Tira esta excepción a causa de que el usuario se encuentra en un status de 
        /// recuperación de contraseña.</exception>
        /// <exception cref="UsuarioBloqueadoException">Tira esta excepción a causa de que el usuario se encuentra en un status bloqueado
        /// debido al contexto puesto en el sistema.</exception>
        /// <exception cref="LotoUcabException">Tira esta excepción a causa de un error desconocido encontrado en el momento de ejecución del comando.</exception>
        public override bool Ejecutar()
        {
            switch (Status)
            {
                case 1:
                    //Activo
                    return true;
                case 2:
                    //Recuperacion
                    throw new UsuarioRecuperacionException();
                case 0:
                    //Bloqueado
                    throw new UsuarioBloqueadoException();
                default:
                    throw new LotoUcabException("Estatus desconocido en Base De Datos", 1);
            }
        }
    }
}
