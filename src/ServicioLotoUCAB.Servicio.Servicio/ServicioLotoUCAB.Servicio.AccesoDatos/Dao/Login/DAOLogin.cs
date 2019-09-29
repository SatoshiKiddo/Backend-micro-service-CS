using MySql.Data.MySqlClient;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Interfaces;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using ServicioLotoUCAB.Servicio.Excepciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login
{
    /// <summary>
    /// Class <c>DAOLogin</c>
    /// Establece la clase para el manejo de datos query a través de MySQL.
    /// </summary>
    public class DAOLogin : DAO,IDAOLogin
    {
        static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Establece la creación del DAO para el manejo del módulo de ingreso a través de la base de datos.
        /// </summary>
        public DAOLogin()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.Port = 3306;
            conn_string.UserID = "lotoU";
            conn_string.Password = "pedrito123";
            conn_string.Database = "lotoucab";
            //StringConexion = ConfigurationManager.ConnectionStrings["MySqlLoginConnection"].ConnectionString;
            //StringConexion = "Server=127.0.0.1;Port=3306;Database=lotoucab;Uid=root;Pwd=yeisson415;";
            StringConexion = conn_string.ToString();
        }

        /// <summary>
        /// Establece la obtención de un dashboard con todos los datos necesarios para su próximo funcionamiento dentro de su implementación.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario dentro del sistema por el correo.</param>
        /// <returns>Retorna el dashboard con toda la información necesaria para cualquier servicio que lo desee implementar.</returns>
        public Entidad ConsultarDashboard(string correo)
        {
            log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            Usuario user = (Usuario)ConsultarUsuario(correo);
            List<OpcionMenu> opciones = ConsultarOpcionesmenu(user.Id_TipoUsuario);

            return new Dashboard(opciones, user);
        }

        /// <summary>
        /// Establece la obtención de una lista de opciones de menú para la integración del dashboard.
        /// </summary>
        /// <param name="tipoUsuario">Establece la categoría a la que pertenece el usuario para sus limitaciones entro del sistema.</param>
        /// <returns>Retorna la lista de opcones de menú permitidas según tipo de usuario en el ingreso.</returns>
        public List<OpcionMenu> ConsultarOpcionesmenu(int tipoUsuario)
        {
            List<OpcionMenu> opciones = new List<OpcionMenu>();

            log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();
                ComandoSQL.CommandText = string.Format("SELECT B.ID_OPCIONMENUPADRE, B.NOMBRE, B.DESCRIPCION, B.URL, B.POSICION, B.ESTATUS from tb_tipousuario_opcionmenu AS A "
                    + "JOIN tb_opcionmenu AS B ON A.ID_OPCIONMENU = B.ID_OPCIONMENU "
                    + "WHERE A.ID_TIPOUSUARIO = @tipoUsuario;");
                ComandoSQL.Parameters.Add(new MySqlParameter("tipoUsuario", tipoUsuario));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                OpcionMenu item = null;
                while (LectorTablaSQL.Read())
                {
                    item = new OpcionMenu();
                    //item.OpcionMenuPadre = Convert.ToInt32(LectorTablaSQL.GetString(0));
                    item.Nombre = LectorTablaSQL.GetString(1);
                    item.Descripcion = LectorTablaSQL.GetString(2);
                    item.Url = LectorTablaSQL.GetString(3);
                    item.Posicion = Convert.ToInt32(LectorTablaSQL.GetString(4));
                    item.Status = Convert.ToInt32(LectorTablaSQL.GetString(5));

                    opciones.Add(item);
                }
            }
            catch (MySqlException ex)
            {
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MSQLException(ex);
            }
            catch (Exception ex)
            {

                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new LotoUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return opciones;
        }

        /// <summary>
        /// Establece la obtención de un usuario a través de un correo determinado para posterior implementación del sistema.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario detro del sistema por el correo.</param>
        /// <returns>Retorna el usuario que se relaciona directamente con esa identificación.</returns>
        public Entidad ConsultarUsuario(string correo)
        {

            Usuario user = null;

            log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();
                ComandoSQL.CommandText = string.Format("SELECT * FROM tb_usuario AS A WHERE A.CORREOELECTRONICO = @correo");
                ComandoSQL.Parameters.Add(new MySqlParameter("correo", correo));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    user = new Usuario();
                    user.Id = Convert.ToInt32(LectorTablaSQL.GetString(0));
                    user.Id_TipoUsuario = Convert.ToInt32(LectorTablaSQL.GetString(2));
                    user.Nombre = LectorTablaSQL.GetString(4);
                    user.Apellido = LectorTablaSQL.GetString(5);
                    user.Numero_Identificacion = LectorTablaSQL.GetString(6);
                    user.Nombre_Usuario = LectorTablaSQL.GetString(7);
                    user.Correo = LectorTablaSQL.GetString(8);
                    user.Status = Convert.ToInt32(LectorTablaSQL.GetString(9));
                    user.Caducidad = Convert.ToInt32(LectorTablaSQL.GetString(10));
                    user.Clave = LectorTablaSQL.GetString(11);
                }
                else
                {
                    user = null;
                }

            }
            catch (MySqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MSQLException(ex);
            }
            catch (Exception ex)
            {
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new LotoUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            return user;
        }

        /// <summary>
        /// Realización de la inserción del usuario contra la base de datos.
        /// </summary>
        /// <param name="user">Establece el usuario que será insertado en el sistema.</param>
        /// <returns>Retorna un int, no tiene una funcionalidad específica.</returns>
        public int InsertarUsuario(Usuario user)
        {
            int afectados = 0;

            log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();
                
                ComandoSQL.CommandText = string.Format("INSERT INTO tb_usuario (ID_DOMINIO, ID_TIPOUSUARIO, ID_USUARIOPADRE, NOMBRE, APELLIDO, NUMEROIDENTIFICACION, USUARIO, CORREOELECTRONICO, ESTATUS, CADUCIDAD, CLAVE) VALUES (@dominio, @tipo, @padre, @nombre, @apellido, @numero, @usuario, @correo, @estatus, @caducidad, @clave);");
                ComandoSQL.Parameters.Add(new MySqlParameter("@dominio", 0));
                ComandoSQL.Parameters.Add(new MySqlParameter("@tipo", 7));
                ComandoSQL.Parameters.Add(new MySqlParameter("@padre", 0));
                ComandoSQL.Parameters.Add(new MySqlParameter("@nombre", user.Nombre));
                ComandoSQL.Parameters.Add(new MySqlParameter("@apellido", user.Apellido));
                ComandoSQL.Parameters.Add(new MySqlParameter("@numero", user.Numero_Identificacion));
                ComandoSQL.Parameters.Add(new MySqlParameter("@usuario", user.Nombre));
                ComandoSQL.Parameters.Add(new MySqlParameter("@correo", user.Correo));
                ComandoSQL.Parameters.Add(new MySqlParameter("@estatus", 1));
                ComandoSQL.Parameters.Add(new MySqlParameter("@caducidad", 3));
                ComandoSQL.Parameters.Add(new MySqlParameter("@clave", user.Clave));
                afectados = ComandoSQL.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MSQLException(ex);
            }
            catch (Exception ex)
            {
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new LotoUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            if (afectados == 0)
                throw new LotoUcabException("Imposible registrar usuario en la base de datos",1);
            return afectados;
        }

        /// <summary>
        /// Establece la modificación de la caducidad por los intentos de ingreso por parte del usuario contra el sistema.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario dentro del sistema por el correo.</param>
        /// <param name="caducidad">Establece la cantidad de ingresos permitidos por parte del usuario si ocurre el error de una invalidación en el mismo.</param>
        public void ModificarCaducidad(string correo, int caducidad)
        {
            int afectados = 0;

            log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("UPDATE tb_usuario SET CADUCIDAD = @caducidad WHERE CORREOELECTRONICO = @correo;");
                ComandoSQL.Parameters.Add(new MySqlParameter("caducidad", caducidad));
                ComandoSQL.Parameters.Add(new MySqlParameter("correo", correo));
                afectados = ComandoSQL.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MSQLException(ex);
            }
            catch (Exception ex)
            {
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new LotoUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
            
            if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usuarios duplicados en Base de datos",20);

        }

        /// <summary>
        /// Establece la modificación de la clave por un procedimiento específico dentro del sistema.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario dentro del sistema por el correo.</param>
        /// <param name="clave">Establece la clave del usuario específico realizando la acción de modificación de clave.</param>
        /// <param name="status">Establece el status del usuario específico realizando la acción de modificación de clave.</param>
        public void ModificarClave(string correo, string clave, int status)
        {
            int afectados = 0;

            log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("UPDATE tb_usuario SET ESTATUS = @status, CADUCIDAD = @caducidad, CLAVE = @clave WHERE CORREOELECTRONICO = @correo;");
                ComandoSQL.Parameters.Add(new MySqlParameter("status", status));
                ComandoSQL.Parameters.Add(new MySqlParameter("caducidad", 3));
                ComandoSQL.Parameters.Add(new MySqlParameter("clave", clave));
                ComandoSQL.Parameters.Add(new MySqlParameter("correo", correo));
                afectados = ComandoSQL.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MSQLException(ex);
            }
            catch (Exception ex)
            {
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new LotoUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);
        }

        /// <summary>
        /// Establece la modificación del usuario por un procedimiento específico dentro del sistema.
        /// </summary>
        /// <param name="correo">Establece la identificación del usuario dentro del sistema por el correo.</param>
        /// <param name="status">Establece el status del usuario específico realizando la acción de modificar su status.</param>
        public void ModificarStatusUsuario(string correo, int status)
        {
            int afectados = 0;

            log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("UPDATE tb_usuario SET ESTATUS = @estatus WHERE CORREOELECTRONICO = @correo;");
                ComandoSQL.Parameters.Add(new MySqlParameter("estatus", status));
                ComandoSQL.Parameters.Add(new MySqlParameter("correo", correo));
                afectados = ComandoSQL.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MSQLException(ex);
            }
            catch (Exception ex)
            {
                log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new LotoUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);
        }
    }
}
