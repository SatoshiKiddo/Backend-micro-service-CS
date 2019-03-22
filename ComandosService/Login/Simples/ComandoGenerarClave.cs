using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login
{
    /// <summary>
    /// Clase <c>ComandoGenerarClave</c>.
    /// Ejecuta únicamente la realización de una clave aleatoria.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoGenerarClave : Comando<string>
    {
        /// <summary>
        /// Ejecuta el comando para validar el formulario de registro.
        /// </summary>
        /// <returns>
        /// Retorna un string como predeterminación, este devuelve una clave aleatoria para objetivos propios de la 
        /// aplicación.
        /// </returns>
        public override string Ejecutar()
        {
            string minusculas = "abcdefghijklmnopqrstuvwxyz";
            string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";
            string especiales = "!@#$%^&*";

            Random random = new Random();

            string claveGenerada = "";
            for (int i = 0; i <= 12; i++)
            {
                if (i < 3) claveGenerada += minusculas[random.Next(minusculas.Length)].ToString();
                if (i < 6) claveGenerada += mayusculas[random.Next(mayusculas.Length)].ToString();
                if (i < 9) claveGenerada += numeros[random.Next(numeros.Length)].ToString();
                else claveGenerada += especiales[random.Next(especiales.Length)].ToString();
            }

            char[] arreglo = claveGenerada.ToCharArray();
            int n = arreglo.Length;
            while (n > 0)
            {
                n--;
                int k = random.Next(arreglo.Length);
                var value = arreglo[k];
                arreglo[k] = arreglo[n];
                arreglo[n] = value;
            }
            claveGenerada = new string(arreglo);

            return claveGenerada;
        }
    }
}
