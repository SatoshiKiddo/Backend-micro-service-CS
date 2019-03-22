using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones.Login
{
    /// <summary>
    /// Class <c>MSQLException</c>
    /// Establece los distintos errores que se pueden adoptar por parte del manejo de base de datos.
    /// </summary>
    public class MSQLException : LotoUcabException
    {
        /// <summary>
        /// Creación de la excepción para controlar y presentar un error en el manejo de datos.
        /// </summary>
        /// <param name="ex">Excepción origina, que surge para el desencadenamiento.</param>
        public MSQLException(MySqlException ex)
        {
            this.ExcepcionOrigen = ex;
            CodigoExcepciones(ex);
        }

        /// <summary>
        /// Establece la creación de la excepción llenando los datos necesarios pero además controlando posibles errores que surgen por el manejo de datos MySQL
        /// </summary>
        /// <param name="ex"></param>
        private void CodigoExcepciones(MySqlException ex)
        {
            switch (ex.Number)
            {
                //Acá esta la clasificación de errores
                case 1165:
                    Codigo = 105;
                    Error = "La tabla a la que se está intentando insertar los datos, está bloqueada.";
                    break;
                case 1206:
                    Codigo = 106;
                    Error = "Buffer de inserción de la base de datos excedido, el Insert es muy largo para su inserción.";
                    break;
                case 1394:
                    Codigo = 107;
                    Error = "No hay campos en la lista para inserción.";
                    break;
                case 1471:
                    Codigo = 108;
                    Error = "La tabla no permite inserción.";
                    break;
                case 1669:
                    Codigo = 109;
                    Error = "Peligro al intentar realizar \"INSERT DELAYED\".";
                    break;
                case 1671:
                    Codigo = 110;
                    Error = "Se inserta en la columna de AutoIncremento.";
                    break;
                case 1727:
                    Codigo = 111;
                    Error = "Se inserta en la columna de AutoIncremento en la primera columna, posiblemente id.";
                    break;
                case 1046:
                    Codigo = 113;
                    Error = "No se seleccionó una base de datos.";
                    break;
                case 1093:
                    Codigo = 114;
                    Error = "Se selecciona y se modifica en el mismo query.";
                    break;
                case 1104:
                    Codigo = 115;
                    Error = "El SELECT supera el máximo de JOIN en el query.";
                    break;
                case 1222:
                    Codigo = 116;
                    Error = "El SELECT tiene un número diferente de columnas en su aplicación.";
                    break;
                case 0:
                    Codigo = 101;
                    Error = "Fallo en el intento de conexión al servidor.";
                    break;
                case 1045:
                    Codigo = 102;
                    Error = "Usuario de acceso a la base de datos inválido.";
                    break;
                default:
                    Codigo = 104;
                    Error = "Error desconocido al ejecutar el query.";
                    break;
            }
        }
    }
}
