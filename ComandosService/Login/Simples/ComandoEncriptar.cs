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
    /// Clase <c>ComandoEncriptar</c>.
    /// Ejecuta únicamente la encriptación de la clave para guardarlo de forma segura en la base de datos, agregando principio de seguridad al sistema.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoEncriptar : Comando<string>
    {
        /// <summary>
        /// Palabra a la cual se realiza la encriptación para los fines del sistema.
        /// </summary>
        private string _palabra;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="palabra">Palabra a la cual se realiza la encriptación para los fines del sistema.</param>
        public ComandoEncriptar(string palabra)
        {
            Palabra = palabra;
        }
        
        public string Palabra
        {
            get { return _palabra; }
            set { _palabra = value; }
        }

        /// <summary>
        /// Ejecuta el comando para encriptar la clave.
        /// </summary>
        /// <returns>
        /// Retorna el hash como predeterminación, la funcionalidad es el poder asegurar la integridad de la clave.
        /// </returns>
        /// <exception cref="MD5Exception">Tira esta excepción a causa de problemas en cuanto a la seguridad a la hora de encriptar
        /// y asegurar la poición del usuario dentro del sistema por la clave.</exception>
        public override string Ejecutar()
        {
            return MD5Encrypth.Encriptar(Palabra);
        }
    }
}
