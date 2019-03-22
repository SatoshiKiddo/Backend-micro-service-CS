using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoActualizarClave</c>.
    /// Ejecuta únicamente la actualizacón a través de los métodos necesarios.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoActualizarClave : Comando<bool>
    {
        /// <summary>
        /// Correo del usuario para realizar el procedimieto e actualización de clave.
        /// </summary>
        private string _correo;
        /// <summary>
        /// Clave del usuario para realizar el procedimiento de actualizar clave. 
        /// </summary>
        private string _clave;
        /// <summary>
        /// Status del usuario para establecer laacción que se toma para la actualización de la clave.
        /// </summary>
        private int _status;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo del usuario para realizar el procedimiento de actualizar la clave.</param>
        /// <param name="clave">Clave del usuario para realizar el procedimiento de actualizar la clave.</param>
        /// <param name="status">Estatus del usuario para establecer en que contexto actuar.</param>
        public ComandoActualizarClave(string correo, string clave, int status)
        {
            Correo = correo;
            Clave = clave;
            Status = status;
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Ejecuta el comando para validar la nueva clave para el usuario específico.
        /// </summary>
        /// <returns>
        /// Retorna true comoelemento predeterminado, sin embargo no tiene una funcionalidad establecida.
        /// </returns>
        /// <exception cref="ClaveNuevaInvalidaException">Tira esta excepción a causa de la falta de cumplir el requisito
        /// de las claves dentro de la plataforma.</exception>
        public override bool Ejecutar()
        {
            IDAOLogin dao = FabricaDAO.crearDaoLogin();
            dao.ModificarClave(Correo, MD5Encrypth.Encriptar(Clave),Status);
            return true;
        }
    }
}
