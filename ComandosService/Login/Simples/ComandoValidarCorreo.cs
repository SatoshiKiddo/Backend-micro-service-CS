using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoValidarCorreo</c>.
    /// Ejecuta únicamente la validación de un campo específico como el correo.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoValidarCorreo : Comando<bool>
    {
        /// <summary>
        /// Correo el cual se realiza la validación de su formato.
        /// </summary>
        private string _correo;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public ComandoValidarCorreo() { }

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo por el cual se realizará la validación de su formato.</param>
        public ComandoValidarCorreo(string correo)
        {
            Correo = correo;
        }

        /// <summary>
        /// Ejecuta el comando para validar el formulario de registro.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="CorreoInvalidoException">Tira esta excepción a causa de un correo inválido en cuanto a su formato.</exception>
        public override bool Ejecutar()
        {
            if (!Validador.ValidarCorreo(Correo))
                throw new CorreoInvalidoException();
            return true;
        }
    }
}
