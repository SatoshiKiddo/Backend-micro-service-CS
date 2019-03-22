using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using ServicioLotoUCAB.Servicio.Excepciones;
using System.Net;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoCorreoRecuperación</c>.
    /// Ejecuta únicamente el envío del correo para el procedimiento de recuperación de contraseña.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoEnviarCorreoRecuperacion : Comando<bool>
    {
        /// <summary>
        /// Correo del usuario al cual enviar el correo de recuperación de clave.
        /// </summary>
        private string _correo;
        /// <summary>
        /// Clave a enviar al usuario para su recuperación de uso.
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

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="correo">Correo del usuario al cual enviar el correo de recuperación de contraseña.</param>
        /// <param name="clave">Clave para enviar al usuario para su recuperación de uso.</param>
        public ComandoEnviarCorreoRecuperacion(string correo, string clave)
        {
            Correo = correo;
            Clave = clave;
        }

        /// <summary>
        /// Ejecuta el comando para enviar el correo para la recuperación de contraseña.
        /// </summary>
        /// <returns>
        /// Retorna true como predeterminación, no tiene utilidad específica.
        /// </returns>
        /// <exception cref="LotoUcabException">Tira esta excepción a causa de las problemáticas que puedan surgir por el envío del correo.</exception>
        public override bool Ejecutar()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("lotoucabfavornoresponder", "qaz123wsx456");
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mensaje = new MailMessage { From = new MailAddress("lotoucabfavornoresponder@gmail.com", "lotoucabfavornoresponder", Encoding.UTF8) };
                mensaje.To.Add(new MailAddress(Correo));
                mensaje.Subject = "LotoUCAB recuperacion de clave";
                mensaje.Body = "Servicio tecnico LotoUCAB\nHemos modificado su clave\nPara acceder al sistema debe dirigirse primero a cambio de clave\nNueva clave : " + Clave;
                mensaje.BodyEncoding = Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                mensaje.Priority = MailPriority.Normal;
                mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.SendAsync(mensaje, "Sending...");

                return true;
            }
            catch (Exception ex)
            {
                throw new LotoUcabException(ex, "Error al intentar enviar email", 1);
            }
        }
    }
}
