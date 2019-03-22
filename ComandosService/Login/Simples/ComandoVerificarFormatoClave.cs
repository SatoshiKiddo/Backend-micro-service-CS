using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoVerificarFormatoClave</c>.
    /// Ejecuta únicamente la verificación del ormato de clave.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoVerificarFormatoClave : Comando<bool>
    {
        /// <summary>
        /// Clave por el cual se realizará la validación de su formato.
        /// </summary>
        private string _clave;
        /// <summary>
        /// Constante que establece la mínima longitud que debe poseer la clave.
        /// </summary>
        const int MIN_LONGITUD = 12;
        /// <summary>
        /// Constante que establece la máxima longitud que debe poseer la clave.
        /// </summary>
        const int MAX_LONGITUD = 12;

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="clave">Clave por el cual se realizará la validación de su formato.</param>
        public ComandoVerificarFormatoClave( string clave)
        {
            Clave = clave;
        }

        /// <summary>
        /// Ejecuta el comando para validar el formato de la cave.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="FormatoClaveException">Tira esta excepción a causa de un formato inválido para el sistema acerca de la clave.</exception>
        public override bool Ejecutar()
        {
            if (!Validador.ValidarClave(Clave))
                throw new FormatoClaveException();
            return true;
        }
    }
}
