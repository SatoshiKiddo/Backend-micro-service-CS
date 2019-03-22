using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoCompararClaves</c>.
    /// Ejecuta únicamente la funcionalidad de comparar la clave de ingreso con el de la base de datos.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoCompararClaves : Comando<bool>
    {
        /// <summary>
        /// Usuario el cual realizará el procedimiento de comparación de claves.
        /// </summary>
        private Usuario _user;
        /// <summary>
        /// Clave del usuario el cual realizará la comparación
        /// </summary>
        private string _clave;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="user">Usuario el cual realizará el procedimiento de comparación de claves.</param>
        /// <param name="clave">Clave del usuario para realizar el pocedimiento de comparación de claves.</param>
        public ComandoCompararClaves(Usuario user, string clave)
        {
            _user = user;
            Clave = clave;
        }

        public Usuario user
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        /// <summary>
        /// Ejecuta el comando para comparar la clave del login con la guardada en la base de datos.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="ClaveInvalidaException">Tira esta excepción a causa de la falta de requisitos que deben contener
        /// las claves en el sistema</exception>
        public override bool Ejecutar()
        {
            if (MD5Encrypth.CompararHash(Clave, user.Clave)) return true;
            else
            {
                IDAOLogin dao = FabricaDAO.crearDaoLogin();
                int caducidad = user.Caducidad - 1;
                if (caducidad < 1)
                {
                    caducidad = 0;
                    dao.ModificarStatusUsuario(user.Correo, 2);
                }
                dao.ModificarCaducidad(user.Correo, caducidad);
                throw new ClaveInvalidaException();
            }
            
        }
    }
}
