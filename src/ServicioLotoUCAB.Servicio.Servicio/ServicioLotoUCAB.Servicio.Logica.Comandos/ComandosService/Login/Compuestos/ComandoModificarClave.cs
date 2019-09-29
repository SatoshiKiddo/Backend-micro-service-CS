using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoModificarClave</c>.
    /// Comando compuesto que ejecuta todos los procedimientos para el objetivo puesto como clase: Modificar la clave del usuario.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier método concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoModificarClave : Comando<bool>
    {
        /// <summary>
        /// Correo del usuario para realizar la modificación de la clave.
        /// </summary>
        private string _correo;
        /// <summary>
        /// Clave del usuario para realizar la modificación de la misma.
        /// </summary>
        private string _clave;
        /// <summary>
        /// Clave por la cual se sustituirá por la el usuario.
        /// </summary>
        private string _nuevaClave;
        /// <summary>
        /// Segundo input por parte del usuari para poder establecer la validación de una nueva clave.
        /// </summary>
        private string _nuevaClaveDos;

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

        public string NuevaClave
        {
            get { return _nuevaClave; }
            set { _nuevaClave = value; }
        }

        public string NuevaClaveDos
        {
            get { return _nuevaClaveDos; }
            set { _nuevaClaveDos = value; }
        }

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo del usuario para realizar el procedimiento.</param>
        /// <param name="viejaClave">Clave del usuario antes de realizar la modificación.</param>
        /// <param name="nuevaClave">Nueva clave que sustituirá la vieja, para realizar la modificación.</param>
        /// <param name="nuevaClaveDos">Nueva clave para comparación a través del primer input.</param>
        public ComandoModificarClave(string correo, string viejaClave, string nuevaClave, string nuevaClaveDos)
        {
            Correo = correo;
            Clave = viejaClave;
            NuevaClave = nuevaClave;
            NuevaClaveDos = nuevaClaveDos;
        }

        /// <summary>
        /// Ejecuta el comando para validar todos los procedimientos y además de realizarlos para modificar la clave del usuario
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene una funcionalidad específica.
        /// </returns>
        /// <exception cref="LotoUcabException">Tira esta excepción como excepción padre, abarcando todas las posibles excepciones con la
        /// ejecución de los diversos comandos simples durante su realización.</exception>
        public override bool Ejecutar()
        {
            Usuario user = null;
            //validar correo
            ComandoValidarCorreo validador = FabricaComandos.FabricarComandoValidarCorreo(Correo);
            validador.Ejecutar();
            //verificar si existe el usuario
            ComandoLeerUsuario verificador = FabricaComandos.FabricarComandoLeerUsuario(Correo);
            user = (Usuario)verificador.Ejecutar();
            //Comparar contrase#as viejas
            ComandoCompararClaves comparadorClaves = FabricaComandos.FabricarComandoCompararClaves(user, Clave);
            comparadorClaves.Ejecutar();
            //Verificar formato de nueva clave
            ComandoVerificarFormatoClave verificarNuevaClave = FabricaComandos.FabricarComandoVerificarFormatoClave(NuevaClave);
            verificarNuevaClave.Ejecutar();
            //comparar nuevas contrase#as
            ComandoVerificarNuevaClave comparador = FabricaComandos.FabricarComandoVerificarNuevaClave(NuevaClave, NuevaClaveDos);
            comparador.Ejecutar();
            //establecer nueva contrase#a
            ComandoActualizarClave actualizador = FabricaComandos.FabricarComandoActualizarClave(Correo, NuevaClave, 1);
            actualizador.Ejecutar();

            return true;

        }
    }
}
