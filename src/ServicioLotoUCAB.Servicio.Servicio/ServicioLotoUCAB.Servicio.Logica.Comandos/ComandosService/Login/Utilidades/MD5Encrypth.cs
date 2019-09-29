using ServicioLotoUCAB.Servicio.Excepciones.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades
{
    /// <summary>
    /// Clase <c>MD5Encrypth</c>.
    /// Esta clase contiene todo los métodos de encriptación de datos a través de generación de hash a partir del MD5.
    /// </summary>
    public class MD5Encrypth
    {
        /// <summary>
        /// Realiza la encriptación directa de la palabra
        /// </summary>
        /// <param name="dato">Establece la palabra a realizar la encriptación.</param>
        /// <returns>
        /// Entrega el hash generado por el método de encriptación MD5.
        /// </returns>
        /// <exception cref="MD5Exception">Tira esta excepción a raíz de cualquier problemática ocasionada por el procedimiento de encriptación.</exception>
        public static string Encriptar(string dato)
        {
            string hash = string.Empty;
            try
            {
                MD5 md5Hash = MD5.Create();

                hash = GetMd5Hash(md5Hash, dato);
            }
            catch (Exception ex)
            {
                throw new MD5Exception(ex);
            }

            return hash;
        }

        /// <summary>
        /// Realiza la conversión de la palabra en el hash para posteriormente ser controlada por el método principal.
        /// </summary>
        /// <param name="md5Hash">Establece el objeto y medio de encriptación a usar por parte del sistema.</param>
        /// <param name="input">Establece el dato al cual realizar la encriptación..</param>
        /// <returns>
        /// Entrega el hash generado por el método de encriptación MD5.
        /// </returns>
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Realiza la generación de una clave estándar para los usuarios de autenticación Auth.
        /// </summary>
        /// <returns>
        /// Entrega el hash generado por el método de encriptación MD5.
        /// </returns>
        public static string ClaveAuth()
        {
            MD5 md5Hash = MD5.Create();

            return GetMd5Hash(md5Hash, "asdgsjdlhksiutrope64567845hsjljfhgsfgjlsiudrt35634643kjñgjsfigutpsidpifas234523452623thsfhsh");
        }

        /// <summary>
        /// Realiza la comparación de una palabra con el hash a comparar. La encriptación se hace adentro.
        /// </summary>
        /// <returns>
        /// <param name="input">Palabra a realizar el hash y comparar con lo esperado.</param>
        /// <param name="hash">Palabra encriptada esperada para entregar true.</param>
        /// Retorna un booleanos dependiendo de la comparación que se realizó y el resultado que se considera con esto.
        /// </returns>
        public static bool CompararHash( string input, string hash)
        {
            MD5 md5Hash = MD5.Create();

            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
