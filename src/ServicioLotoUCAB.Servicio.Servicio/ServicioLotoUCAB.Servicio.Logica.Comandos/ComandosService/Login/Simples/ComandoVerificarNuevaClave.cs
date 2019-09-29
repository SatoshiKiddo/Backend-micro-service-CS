using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioLotoUCAB.Servicio.Excepciones.Login;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoVerificarNuevaClave</c>.
    /// Ejecuta únicamente la verificación de la nueva clave, comparando las dos en su igualdad.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoVerificarNuevaClave : Comando<bool>
    {
        /// <summary>
        /// Clave por la cual se realizará la sustitución por la vieja, concretando la funcionalidad.
        /// </summary>
        private string _nuevaClave;
        /// <summary>
        /// Comparación por la cual se validará la nueva clabe.
        /// </summary>
        private string _nuevaClaveDos;

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
        /// <param name="nuevaClave">Clave por el cual se realizará la sustitución por la vieja, concretando la funcionalidad.</param>
        /// <param name="nuevaClaveDos">Comparación por la cual se validará la nueva clave.</param>
        public ComandoVerificarNuevaClave (string nuevaClave, string nuevaClaveDos)
        {
            NuevaClave = nuevaClave;
            NuevaClaveDos = nuevaClaveDos;
        }

        /// <summary>
        /// Ejecuta el comando para la comparación de las dos lcaves comprobando su igualdad.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="ClaveNuevaInvalidaException">Tira esta excepción a causa de desigualdad de las dos claves.</exception>
        public override bool Ejecutar()
        {
            if (NuevaClave.Equals(NuevaClaveDos)) return true;
            throw new ClaveNuevaInvalidaException();
        }
        
    }
}
