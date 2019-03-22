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
    /// Clase <c>ComandoRegistroUsuario</c>.
    /// Comando compuesto que ejecuta todos los procedimientos para el objetivo puesto como clase: registro del usuaro dentro del sistema.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier método concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoRegistroUsuario : Comando<int>
    {
        private Usuario _usuario;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="usuario">Es el formulario usuario para realizar el registro del mismo en el sistema.</param>
        public ComandoRegistroUsuario(Usuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Ejecuta el comando para validar todos los procedimientos y además de realizarlos para el posterior ingreso y disfrute de los servicios por parte de los usuarios.
        /// </summary>
        /// <returns>
        /// Retorna dashboard como predeterminación, esto conforma la información de la interfaz mostrada al usuario después de autenticarse.
        /// </returns>
        /// <exception cref="LotoUcabException">Tira esta excepción como excepción padre, abarcando todas las posibles excepciones con la
        /// ejecución de los diversos comandos simples durante su realización.</exception>
        public override int Ejecutar()
        {
            //validar correo
            ComandoValidarCorreo validador = FabricaComandos.FabricarComandoValidarCorreo(_usuario.Correo);
            validador.Ejecutar();
            //verificar que no exista en la base de datos
            ComandoVerificarExisteUsuario verificador = FabricaComandos.FabricarComandoVerificarExisteUsuario(_usuario.Correo);
            if (!verificador.Ejecutar())
            {
                //validar campos
                ComandoValidacionCampos validarCampos = FabricaComandos.FabricarComandoValidacionCampos(_usuario);
                validarCampos.Ejecutar();
                //encriptar clave
                _usuario.Clave = MD5Encrypth.Encriptar(_usuario.Clave);
                //Insertar usuario
                ComandoInsertarUsuario insertador = FabricaComandos.FabricarComandoComandoInsertarUsuario(_usuario);
                insertador.Ejecutar();
            }else
            {
                throw new UsuarioRegistradoException();
            }
            
            return 0;
        }
    }
}
