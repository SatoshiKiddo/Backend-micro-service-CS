using Google.Apis.Auth.OAuth2;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login.Simples;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos
{
    public class FabricaComandos
    {

        public static ComandoIngresoLogin FabricarComandoIngresoLogin(string id, string clave)
        {
            return new ComandoIngresoLogin(id,clave);
        }

        public static ComandoValidarCorreo FabricarComandoValidarCorreo(string correo)
        {
            return new ComandoValidarCorreo(correo);
        }

        public static ComandoEncriptar FabricarComandoEncriptar(string palabra)
        {
            return new ComandoEncriptar(palabra);
        }

        public static ComandoCompararClaves FabricarComandoCompararClaves(Usuario user, string clave)
        {
            return new ComandoCompararClaves(user, clave);
        }

        public static ComandoVerificarExisteUsuario FabricarComandoVerificarExisteUsuario(string correo)
        {
            return new ComandoVerificarExisteUsuario(correo);
        }

        public static ComandoVerificarStatusUsuario FabricarComandoVerificarStatusUsuario(int status)
        {
            return new ComandoVerificarStatusUsuario(status);
        }

        public static ComandoObtenerDashboard FabricarComandoObtenerDashboard(string correo)
        {
            return new ComandoObtenerDashboard(correo);
        }

        public static ComandoModificarClave FabricarComandoModificarClave(string correo, string viejaClave, string nuevaClave, string nuevaClaveDos)
        {
            return new ComandoModificarClave(correo, viejaClave, nuevaClave, nuevaClaveDos);
        }

        public static ComandoVerificarNuevaClave FabricarComandoVerificarNuevaClave(string nuevaClave, string nuevaClaveDos)
        {
            return new ComandoVerificarNuevaClave(nuevaClave, nuevaClaveDos);
        }

        public static ComandoActualizarClave FabricarComandoActualizarClave(string correo, string nuevaClave, int status)
        {
            return new ComandoActualizarClave(correo, nuevaClave, status);
        }

        public static ComandoVerificarFormatoClave FabricarComandoVerificarFormatoClave(string clave)
        {
            return new ComandoVerificarFormatoClave(clave);
        }

        public static ComandoGenerarClave FabricarComandoGenerarClave()
        {
            return new ComandoGenerarClave();
        }

        public static ComandoEnviarCorreoRecuperacion FabricarComandoEnviarCorreoRecuperacion(string correo, string clave)
        {
            return new ComandoEnviarCorreoRecuperacion(correo, clave);
        }

        public static ComandoRecuperarClave FabricarComandoRecuperarClave(string correo)
        {
            return new ComandoRecuperarClave(correo);
        }

        public static ComandoIngresoFacebook FabricarComandoIngresoFacebook(string token)
        {
            return new ComandoIngresoFacebook(token);
        }

        public static ComandoGoogleCredentials FabricarComandoGoogleCredentials()
        {
            return new ComandoGoogleCredentials();
        }

        public static ComandoObtenerUsuarioGoogle FabricarComandoObtenerUsuarioGoogle(UserCredential credential)
        {
            return new ComandoObtenerUsuarioGoogle(credential);
        }

        public static ComandoRegistroUsuario FabricarComandoRegistroUsuario(Usuario usuario)
        {
            return new ComandoRegistroUsuario(usuario);
        }

        public static ComandoValidacionCampos FabricarComandoValidacionCampos(Usuario usuario)
        {
            return new ComandoValidacionCampos(usuario);
        }

        public static ComandoInsertarUsuario FabricarComandoComandoInsertarUsuario(Usuario usuario)
        {
            return new ComandoInsertarUsuario(usuario);
        }

        public static ComandoLeerUsuario FabricarComandoLeerUsuario(string correo)
        {
            return new ComandoLeerUsuario(correo);
        }

        public static ComandoIngresoGoogle FabricarComandoIngresoGoogle()
        {
            return new ComandoIngresoGoogle();
        }

        public static ComandoObtenerUsuarioFacebook FabricarComandoObtenerUsuarioFacebook(string token)
        {
            return new ComandoObtenerUsuarioFacebook(token);
        }
    }
}
