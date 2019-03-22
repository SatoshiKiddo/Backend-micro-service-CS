using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{

    /// <summary>
    /// Clase <c>ComandoRecuperarClave</c>.
    /// Comando compuesto que ejecuta todos los procedimientos para el objetivo puesto como clase: recuperar la contraseña de un usuario.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier método concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoRecuperarClave : Comando<bool>
    {
        private string _correo;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo del usuario para realizar la recuperación de contraseña para el mismo.</param>
        public ComandoRecuperarClave(string correo)
        {
            Correo = correo;
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        /// <summary>
        /// Ejecuta el comando para validar todos los procedimientos y además de realizarlos para la recuperación de la contraseña por parte del usuario.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene funcionalidad.
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
            //Generar clave aleatoria
            ComandoGenerarClave generador = FabricaComandos.FabricarComandoGenerarClave();
            string nuevaClave = generador.Ejecutar();
            //Enviar correo
            ComandoEnviarCorreoRecuperacion enviador = FabricaComandos.FabricarComandoEnviarCorreoRecuperacion(Correo, nuevaClave);
            enviador.Ejecutar();
            //Modificar clave y status
            ComandoActualizarClave actualizador = FabricaComandos.FabricarComandoActualizarClave(Correo, nuevaClave, 2);
            actualizador.Ejecutar();
            return true;
        }
    }
}
