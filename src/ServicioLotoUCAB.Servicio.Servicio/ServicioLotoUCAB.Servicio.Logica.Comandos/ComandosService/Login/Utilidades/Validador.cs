using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades
{
    /// <summary>
    /// Clase <c>Validador</c>.
    /// Esta clase contiene todos los métodos de validación como métodos estáticos de procedimiento, encapsulando la funcionalidad en esta forma de procedimiento..
    /// </summary>
    public class Validador
    {
        /// <summary>
        /// Realiza la validación del formulario llenado para poder realizar el registro, comprobando a placer del programador lo que se desea validar.
        /// </summary>
        /// <exception cref="CamposInvalidosException">Tira esta excepción reflejando el campo que está incorrecto en su uso.</exception>
        public static void ValidarFormulario(Usuario objeto)
        {
            if (objeto == null)
                CamposInvalidosException.CamposInvalidos("vacio");
            if (string.IsNullOrWhiteSpace(objeto.Apellido))
                CamposInvalidosException.CamposInvalidos("Apellido");
            if (string.IsNullOrWhiteSpace(objeto.Nombre))
                CamposInvalidosException.CamposInvalidos("Nombre");
            if (string.IsNullOrWhiteSpace(objeto.Nombre_Usuario))
                CamposInvalidosException.CamposInvalidos("Nombre de usuario");
            if ((objeto.Clave == null ) || !ValidarClave(objeto.Clave))
                CamposInvalidosException.CamposInvalidos("Clave");
            if (string.IsNullOrWhiteSpace(objeto.Numero_Identificacion))
                CamposInvalidosException.CamposInvalidos("Numero de identificación");
            // se puede manejar la falta de datos en esta clase, agregando lo necesario. En este caso no incluye la repetición de campos, en este caso del nombre de usuario o de correo.
        }

        /// <summary>
        /// Realiza la validación del correo con un formato válido y de estándar general global.
        /// </summary>
        /// <returns>
        /// Retorna un booleano dependiendo de la situación que se dio respecto a la validación del correo.
        /// </returns>
        public static bool ValidarCorreo(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Realiza la validación de la clave con un formato válido y de estándar establecida por el sistema.
        /// </summary>
        /// <returns>
        /// Retorna un booleano dependiendo de la situación que se dio respecto a la validación del formato de clave.
        /// </returns>
        public static bool ValidarClave(string clave)
        {
            var regexClave = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{12,50}");
            return regexClave.IsMatch(clave);
        }
    }
}
