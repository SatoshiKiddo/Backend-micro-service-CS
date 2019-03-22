using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces;
using ServicioLotoUCAB.Servicio.AccesoDatos;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoIngresoLogin</c>.
    /// Comando compuesto que ejecuta todos los procedimientos para el objetivo puesto como clase: ingreso a través de la interfaz estándar.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier método concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoIngresoLogin : Comando<Entidad>
    {
        /// <summary>
        /// Correo del usuario para realizar el procedimiento de ingreso.
        /// </summary>
        private string _correo;
        /// <summary>
        /// Clave del usuario para realizar el procedimiento de ingreso.
        /// </summary>
        private string _clave;

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

        public ComandoIngresoLogin() { }

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo del usuario para realizar el procedimiento de ingreso.</param>
        /// <param name="clave">Clave del usuario para realizar el procedimiento de ingreso.</param>
        public ComandoIngresoLogin(string correo, string clave)
        {
            Correo = correo;
            Clave = clave;
        }

        /// <summary>
        /// Ejecuta el comando para validar todos los procedimientos y además de realizarlos para el posterior ingreso y disfrute de los servicios por parte de los usuarios.
        /// </summary>
        /// <returns>
        /// Retorna dashboard como predeterminación, esto conforma la información de la interfaz mostrada al usuario después de autenticarse.
        /// </returns>
        /// <exception cref="LotoUcabException">Tira esta excepción como excepción padre, abarcando todas las posibles excepciones con la
        /// ejecución de los diversos comandos simples durante su realización.</exception>
        public override Entidad Ejecutar()
        {
            Usuario user = null;
            Dashboard tablero = null;
            //validar correo
            ComandoValidarCorreo validador = FabricaComandos.FabricarComandoValidarCorreo(Correo);
            validador.Ejecutar();
            //verificar si existe el usuario
            ComandoLeerUsuario verificador = FabricaComandos.FabricarComandoLeerUsuario(Correo);
            user = (Usuario)verificador.Ejecutar();
            //Verificar status de usuario
            ComandoVerificarStatusUsuario lectorStatus = FabricaComandos.FabricarComandoVerificarStatusUsuario(user.Status);
            lectorStatus.Ejecutar();
            //Comparar contrase#as
            ComandoCompararClaves comparadorClaves = FabricaComandos.FabricarComandoCompararClaves(user,Clave);
            comparadorClaves.Ejecutar();
            //Obtener dashboard
            ComandoObtenerDashboard lectorDashboard = FabricaComandos.FabricarComandoObtenerDashboard(user.Correo);
            tablero = lectorDashboard.Ejecutar();
            return tablero;
        }
    }
}
