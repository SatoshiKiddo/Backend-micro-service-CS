using ServicioLotoUCAB.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces
{
    /// <summary>
    /// Interface <c>IDAOLogin</c>
    /// Interfaz que establece los métodos que deben implementar cualquier dao para realizar los distintos ingresos en l sistema.
    /// </summary>
    public interface IDAOLogin
    {
        /// <summary>
        /// Establece el método para consultar el usuario con al base de datos.
        /// </summary>
        /// <param name="correo">Establece la identificación por la cual extraemos los datos del usuario.</param>
        /// <returns>Retorna el usuario desués de realizar la consulta del usuario.</returns>
        Entidad ConsultarUsuario(string correo);

        /// <summary>
        /// Establece el método para consultar las opciones de menú permitidas por el tipo de usuario.
        /// </summary>
        /// <param name="tipoUsuario">Establece la categoría del usuario por el cual tiene acceso a las distintas características de la interfaz.</param>
        /// <returns>Retorna una lista de las distintas opciones que están permitidas por el tipo de usuario.</returns>
        List<OpcionMenu> ConsultarOpcionesmenu(int tipoUsuario);

        /// <summary>
        /// Establece el método para consultar el dashboard entero con los datos necesarios por cierto usuario.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario dentro de la base de datos.</param>
        /// <returns>Retorna el dashboard completo con todos los datos incluidos en la esructura.</returns>
        Entidad ConsultarDashboard(string correo);

        /// <summary>
        /// Establece el método para modificar la clave para el usuario dentro del sistema.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario por medio del correo para manipulación de información.</param>
        /// <param name="clave">Establce la clave por la cual permite la autenticación de procedimientos por parte del usuario, en este caso para cambiarla.</param>
        /// <param name="status">Establece el estatus por el cual se encuentra el usuario para realizar el procedimiento de la base de datos.</param>
        void ModificarClave(string correo, string clave, int status);

        /// <summary>
        /// Establece el método para modifcar el status de usuario según la acción dentro del sistema.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario por el medio del cual lo reconoce dentro del sistema.</param>
        /// <param name="status">Establece el status en el que se necuentra el usuario para las diferentes operaciones a realizar dentro del sistema.</param>
        void ModificarStatusUsuario(string correo, int status);

        /// <summary>
        /// Establece el método para modificar la caducidad de ingresos o acciones dentro del sistema.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario por el medio del cual lo reconoce dentro del sistema.</param>
        /// <param name="caducidad">Establece la cantidad de intentos por el cual se realiza el procedimiento de ingreso.</param>
        void ModificarCaducidad(string correo, int caducidad);

        /// <summary>
        /// Establece el método para realizar la inserción de un nuevo usuario dentro de la base de datos del sistema.
        /// </summary>
        /// <param name="user">Establece el nuevo usuario el cual se tiene que insertar dentro del sistema.</param>
        /// <returns>Retorna un entero para establecer el resultado de la acción, no tiene una funcionalidad específica.</returns>
        int InsertarUsuario(Usuario user);
        
    }
}