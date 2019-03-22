using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login;
using ServicioLotoUCAB.Servicio.Servicio.Utilidades;
using System;
using System.Net;
using System.Reflection;
using System.ServiceModel.Web;


namespace ServicioLotoUCAB.Servicio.Servicio
{
    /// <summary>
    /// Class <c>Service1</c>
    /// Conforma todos los servicios otorgados por este módulo.
    /// </summary>
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Servicio para realizar el ingreso dentro del sistema con los datos establecidos.
        /// </summary>
        /// <param name="id">Correo de identificación para el usuario dentro del sistema.</param>
        /// <param name="clave">Clave que conforma parte del usuario dentro del sistema para sus distintas acciones.</param>
        /// <returns>Retorna el dashboard con la información necesario para la acción dentro del sistema.</returns>
        public RespuestaDashboard IngresoLogin(string id, string clave)
        {
            RespuestaDashboard response = new RespuestaDashboard();
            //tomar la propagación de errores desde este punto
            try
            {
                log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

                ComandoIngresoLogin comando = FabricaComandos.FabricarComandoIngresoLogin(id,clave);
                response.Tablero = (Dashboard)comando.Ejecutar();
                response.StatusResp = 200;
                response.Descripcion = "Éxito en el ingreso de usuario";
                response.Error = null;
            }
            catch (LotoUcabException e)
            {
                response.StatusResp = 500;
                if (e.ExcepcionOrigen != null)
                {
                    response.Descripcion = " Origen: " + e.ExcepcionOrigen.Source + " -  Método: " + e.ExcepcionOrigen.TargetSite;
                    
                }
                else
                {
                    response.Descripcion = " Origen: " + e.Source + " -  Método: " + e.TargetSite ;
                }
                log.Error(response.Descripcion, e);
                response.Error = e.Error;
            }
            catch (Exception e)
            {
                response.StatusResp = 500;
                response.Descripcion = "Error con origen desconocido. " + e.Source + " -  Método: " + e.TargetSite;
                response.Tablero = null;
                response.Error = "Error interno de origen desconocido";
                log.Error(response.Descripcion, e);
            }
            return response;
        }

        /// <summary>
        /// Procedimiento para la modificación de la clave del usuario.
        /// </summary>
        /// <param name="correo">Identificación del usuario dentro del sistema por el correo.</param>
        /// <param name="viejaClave">Clave que conforma parte del usuario dentro del sistema.</param>
        /// <param name="nuevaClave">Establece la nueva clave para un cambio del usuario en la base de datos.</param>
        /// <param name="nuevaClaveDos">Comparación de validación de la nueva clave.</param>
        /// <returns>Retorna una respuesta estándar determinando el éxito o el fallo de la operación.</returns>
        public Respuesta ModificarClave(string correo, string viejaClave, string nuevaClave, string nuevaClaveDos)
        {
            Respuesta response = new Respuesta();
            //tomar la propagación de errores desde este punto
            try
            {
                log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

                ComandoModificarClave comando = FabricaComandos.FabricarComandoModificarClave(correo, viejaClave, nuevaClave, nuevaClaveDos);
                comando.Ejecutar();
                response.StatusResp = 200;
                response.Descripcion = "Cambio de Clave exitoso";
                response.Error = null;
            }
            catch (LotoUcabException e)
            {
                response.StatusResp = 500;
                if (e.ExcepcionOrigen != null)
                {
                    response.Descripcion = " Origen: " + e.ExcepcionOrigen.Source + " -  Método: " + e.ExcepcionOrigen.TargetSite ;
                }
                else
                {
                    response.Descripcion = " Origen: " + e.Source + " -  Método: " + e.TargetSite ;
                }
                log.Error(response.Descripcion, e);
                response.Error = e.Error;
            }
            catch (Exception e)
            {
                response.StatusResp = 500;
                response.Descripcion = "Error con origen desconocido. " + e.Source + " -  Método: " + e.TargetSite;
                response.Error = "Error interno de origen desconocido";
                log.Error(response.Descripcion, e);
            }

            return response;
        }

        /// <summary>
        /// Procedimiento para la recuperación de la clave del usuario dentro del sistema.
        /// </summary>
        /// <param name="correo">Identificación del usuario dentro del sistema por el correo.</param>
        /// <returns>Retorna una respuesta estándar determinando el éxito o fallo del procedimiento dentro del sistema.</returns>
        public Respuesta RecuperarClave(string correo)
        {
            Respuesta response = new Respuesta();
            //tomar la propagación de errores desde este punto
            try
            {
                log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

                ComandoRecuperarClave comando = FabricaComandos.FabricarComandoRecuperarClave(correo);
                comando.Ejecutar();
                response.StatusResp = 200;
                response.Descripcion = "Recuperacion de clave exitosa. Un correo con la nueva clave ha sido enviado a "+correo;
                response.Error = null;
            }
            catch (LotoUcabException e)
            {
                response.StatusResp = 500;
                if (e.ExcepcionOrigen != null)
                {
                    response.Descripcion = " Origen: " + e.ExcepcionOrigen.Source + " -  Método: " + e.ExcepcionOrigen.TargetSite;
                }
                else
                {
                    response.Descripcion = " Origen: " + e.Source + " -  Método: " + e.TargetSite;
                }
                log.Error(response.Descripcion, e);
                response.Error = e.Error;
            }
            catch (Exception e)
            {
                response.StatusResp = 500;
                response.Descripcion = "Error con origen desconocido. " + e.Source + " -  Método: " + e.TargetSite;
                response.Error = "Error interno de origen desconocido";
                log.Error(response.Descripcion, e);
            }

            return response;
        }

        public RespuestaDashboard IngresoFacebook(string token)
        {
            RespuestaDashboard response = new RespuestaDashboard();
            //tomar la propagación de errores desde este punto
            try
            {
                log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

                ComandoIngresoFacebook comando = FabricaComandos.FabricarComandoIngresoFacebook(token);
                response.Tablero = (Dashboard)comando.Ejecutar();
                response.StatusResp = 200;
                response.Descripcion = "Éxito en el ingreso de usuario";
                response.Error = null;
            }
            catch (LotoUcabException e)
            {
                response.StatusResp = 500;
                if (e.ExcepcionOrigen != null)
                {
                    response.Descripcion = " Origen: " + e.ExcepcionOrigen.Source + " -  Método: " + e.ExcepcionOrigen.TargetSite;
                }
                else
                {
                    response.Descripcion = " Origen: " + e.Source + " -  Método: " + e.TargetSite;
                }
                log.Error(response.Descripcion, e);
                response.Error = e.Error;
            }
            catch (Exception e)
            {
                response.StatusResp = 500;
                response.Descripcion = "Error con origen desconocido. " + e.Source + " -  Método: " + e.TargetSite;
                response.Error = "Error interno de origen desconocido";
                log.Error(response.Descripcion, e);
            }

            return response;
        }

        /// <summary>
        /// Procedimiento para el ingreso dentro del sistema por medio de Google.
        /// </summary>
        /// <returns>Retorna el dashboard conteniendo toda la información necesaria para sus diferentes acciones dentro del sistema.</returns>
        public RespuestaDashboard IngresoLoginGoogle()
        {
            Dashboard dashboard = new Dashboard();
            RespuestaDashboard response = new RespuestaDashboard();
            
            //tomar la propagación de errores desde este punto.
            try
            {
                log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);
                ComandoIngresoGoogle comando = FabricaComandos.FabricarComandoIngresoGoogle();
                dashboard = (Dashboard) comando.Ejecutar();
                response.Tablero = dashboard;
                response.StatusResp = 200;
                response.Descripcion = "Éxito en el ingreso de usuario";
            }
            catch (LotoUcabException e)
            {
                response.StatusResp = 500;
                if (e.ExcepcionOrigen != null)
                {
                    response.Descripcion = " Origen: " + e.ExcepcionOrigen.Source + " -  Método: " + e.ExcepcionOrigen.TargetSite;
                }
                else
                {
                    response.Descripcion = " Origen: " + e.Source + " -  Método: " + e.TargetSite;
                }
                log.Error(response.Descripcion, e);
                response.Error = e.Error;
            }
            catch (Exception e)
            {
                response.StatusResp = 500;
                response.Descripcion = "Error con origen desconocido. " + e.Source + " -  Método: " + e.TargetSite;
                response.Error = "Error interno de origen desconocido";
                log.Error(response.Descripcion, e);
            }
            return response;
        }

        /// <summary>
        /// Procedimiento de registro del usuario dentro del sistema.
        /// </summary>
        /// <param name="usuario">Formulario de usuario para realizar su registro dentro del sistema.</param>
        /// <returns>Retorna una respuesta estándar indicando el éxito o el fallo del procedimiento.</returns>
        public Respuesta Registro(Usuario usuario)
        {
            Respuesta response = new Respuesta();
            //tomar la propagación de errores desde este punto
            try
            {
                log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

                ComandoRegistroUsuario comando = FabricaComandos.FabricarComandoRegistroUsuario(usuario);
                comando.Ejecutar();
                response.StatusResp = 200;
                response.Descripcion = string.Format("El usuario asociado al correo {0} ha sido creado Exitosamente.",usuario.Correo);
                response.Error = null;
            }
            catch (LotoUcabException e)
            {
                response.StatusResp = 500;
                if (e.ExcepcionOrigen != null)
                {
                    response.Descripcion = " Origen: " + e.ExcepcionOrigen.Source + " -  Método: " + e.ExcepcionOrigen.TargetSite;
                }
                else
                {
                    response.Descripcion = " Origen: " + e.Source + " -  Método: " + e.TargetSite;
                }
                log.Error(response.Descripcion, e);
                response.Error = e.Error;
            }
            catch (Exception e)
            {
                response.StatusResp = 500;
                response.Descripcion = "Error con origen desconocido. " + e.Source + " -  Método: " + e.TargetSite;
                response.Error = "Error interno de origen desconocido";
                log.Error(response.Descripcion, e);
            }

            return response;
        }
    }
}
