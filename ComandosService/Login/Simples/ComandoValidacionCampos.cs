using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoValidacionCampos</c>.
    /// Ejecuta únicamente la validación de los campos a través de los métodos necesarios.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoValidacionCampos : Comando<int>
    {
        /// <summary>
        /// Formulario de usuario al cual se realizarán las respectivas validaciones.
        /// </summary>
        private Usuario _usuario;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="usuario">Formulario de usuario al cual se realizarán las respectivas validaciones.</param>
        public ComandoValidacionCampos(Usuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Ejecuta el comando para validar el formulario de registro.
        /// </summary>
        /// <returns>
        /// Retorna 0 como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="CamposInvalidosException">Tira esta excepción a causa de la falta de requisitos que deben contener
        /// los campos válidos de un formulario.</exception>
        public override int Ejecutar()
        {
            Validador.ValidarFormulario(_usuario);
            return 0;
        }
    }
}
