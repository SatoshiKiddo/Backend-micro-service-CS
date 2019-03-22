using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login.Simples;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class Dao_y_Comandos
    {
        private Usuario user;
        private DAOLogin dao;
        private DAOGoogleAuth dao2;
        private Exception e;

        [TestInitialize]
        public void initialize()
        {
            user = new Usuario();
            user.Apellido = "Faria";
            user.Caducidad = 3;
            user.Clave = "Perro123pe?1";
            user.Correo = "pjfariakiddo@gmail.com";
            user.Id = 13;
            user.Nombre = "Pedro";
            user.Nombre_Usuario = "Kiddo";
            user.Numero_Identificacion = "26466404";
            user.Status = 0;
            dao = FabricaDAO.crearDaoLogin();
            dao2 = FabricaDAO.crearDaoGoogleAuth();
        }

        [TestMethod]
        public void InsertarUsuarioValido()
        {
            try
            {
                dao.InsertarUsuario(user);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }

        public void UsuarioExistente()
        {
            dao.Conectar();
            dao.ComandoSQL.CommandText = string.Format("DELETE FROM tb_usuario WHERE Nombre = @nombre");
            dao.ComandoSQL.Parameters.Add(new MySqlParameter("nombre", user.Nombre));
            dao.ComandoSQL.ExecuteNonQuery();
            dao.Desconectar();
            InsertarUsuarioValido();
        }

        public void UsuarioRepetido()
        {
            UsuarioExistente();
            InsertarUsuarioValido();
        }

        public void UsuarioHash()
        {
            dao.Conectar();
            dao.ComandoSQL.CommandText = string.Format("DELETE FROM tb_usuario WHERE Nombre = @nombre");
            dao.ComandoSQL.Parameters.Add(new MySqlParameter("nombre", user.Nombre));
            dao.ComandoSQL.ExecuteNonQuery();
            dao.Desconectar();
            user.Clave = MD5Encrypth.Encriptar("pedro");
            InsertarUsuarioValido();
        }

        [TestMethod]
        public void InsertarUsuarioInvalidoUserNull()
        {
            try
            {
                dao.InsertarUsuario(null);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void ConsultarUsuarioExistente()
        {
            try
            {
                UsuarioExistente();
                user = (Usuario) dao.ConsultarUsuario(user.Correo);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void ConsultarUsuarioInexistente()
        {
            try
            {
                dao.Conectar();
                dao.ComandoSQL.CommandText = string.Format("DELETE FROM tb_usuario WHERE Nombre = @nombre");
                dao.ComandoSQL.Parameters.Add(new MySqlParameter("nombre", user.Nombre));
                dao.ComandoSQL.ExecuteNonQuery();
                dao.Desconectar();
                user = (Usuario)dao.ConsultarUsuario("hola");
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(user);
            Assert.IsNull(e);
        }

        [TestMethod]
        public void ConsultarOpcionesMenuInexistente()
        {
            List<OpcionMenu> opciones = new List<OpcionMenu>();
            try
            {
                opciones = (List<OpcionMenu>)dao.ConsultarOpcionesmenu(0);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsTrue( opciones.Count == 0 );
            Assert.IsNull(e);
        }

        [TestMethod]
        public void ConsultarOpcionesMenuValido()
        {
            List<OpcionMenu> opciones = new List<OpcionMenu>();
            try
            {
                opciones = (List<OpcionMenu>)dao.ConsultarOpcionesmenu(7);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsTrue(opciones.Count != 0);
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ConsultarOpcionesMenuInvalido()
        {
            List<OpcionMenu> opciones = new List<OpcionMenu>();
            try
            {
                opciones = (List<OpcionMenu>)dao.ConsultarOpcionesmenu(-1);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsTrue(opciones.Count == 0);
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ConsultarDashboardInvalido()
        {
            Dashboard dashboard = null;
            try
            {
                dashboard = (Dashboard)dao.ConsultarDashboard("pedrito");
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(dashboard);
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ConsultarDashboardValido()
        {
            Dashboard dashboard = null;
            try
            {
                UsuarioExistente();
                dashboard = (Dashboard)dao.ConsultarDashboard(user.Correo);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(dashboard);
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ModificarCaducidadUsuarioValido()
        {
            try
            {
                UsuarioExistente();
                dao.ModificarCaducidad(user.Correo, 2);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ModificarCaducidadUsuarioRepetido()
        {
            try
            {
                UsuarioRepetido();
                dao.ModificarCaducidad(user.Correo, 2);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ModificarCaducidadUsuarioInvalido()
        {
            try
            {
                dao.ModificarCaducidad("hola", 2);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ModificarClaveUsuarioExistente()
        {
            try
            {
                UsuarioExistente();
                dao.ModificarClave(user.Correo,"pedrito",1);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ModificarClaveUsuarioInexistente()
        {
            try
            {
                UsuarioExistente();
                dao.ModificarClave("nulo", "pedrito", 1);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ModificarClaveUsuarioRepetido()
        {
            try
            {
                UsuarioRepetido();
                dao.ModificarClave(user.Correo, "pedrito", 1);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ModificarStatusUsuarioExistente()
        {
            try
            {
                UsuarioExistente();
                dao.ModificarStatusUsuario(user.Correo, 1);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ModificarStatusUsuarioRepetido()
        {
            try
            {
                UsuarioRepetido();
                dao.ModificarStatusUsuario(user.Correo, 1);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ModificarStatusUsuarioInvalido()
        {
            try
            {
                dao.ModificarStatusUsuario("hola", 1);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }

        //DAO Google Auth------------------------------------------------------
        [TestMethod]
        public void GetUserCredentials()
        {
            try
            {
                string error= string.Empty;
                dao2.GetUserCredential(out error);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ObtenerUsuarioGoogle()
        {
            try
            {
                string error = string.Empty;
                dao2.ObtenerUsuario(dao2.GetUserCredential(out error));
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }

        //Comandos de ejecución------------------------------------------------
        [TestMethod]
        public void statusUsuarioBloqueado()
        {
            try
            {
                ComandoVerificarStatusUsuario status = FabricaComandos.FabricarComandoVerificarStatusUsuario(0);
                status.Ejecutar();
            }
            catch (UsuarioBloqueadoException ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void statusUsuarioRecuperacion()
        {
            try
            {
                ComandoVerificarStatusUsuario status = FabricaComandos.FabricarComandoVerificarStatusUsuario(2);
                status.Ejecutar();
            }
            catch (UsuarioRecuperacionException ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void statusUsuarioEstable()
        {
            ComandoVerificarStatusUsuario status = FabricaComandos.FabricarComandoVerificarStatusUsuario(1);
            Assert.IsTrue(status.Ejecutar());
        }
        [TestMethod]
        public void statusUsuarioDesconocido()
        {
            try
            {
                ComandoVerificarStatusUsuario status = FabricaComandos.FabricarComandoVerificarStatusUsuario(-1);
                status.Ejecutar();
            }
            catch (LotoUcabException ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void NuevaClaveValida()
        {
            try
            {
                ComandoVerificarNuevaClave clave = FabricaComandos.FabricarComandoVerificarNuevaClave("pedro","pedro");
                clave.Ejecutar();
            }
            catch (ClaveNuevaInvalidaException ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }
        [TestMethod]
        public void NuevaClaveInvalida()
        {
            try
            {
                ComandoVerificarNuevaClave clave = FabricaComandos.FabricarComandoVerificarNuevaClave("pedro", "pedros");
                clave.Ejecutar();
            }
            catch (ClaveNuevaInvalidaException ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ComandoVerificarExistenciaUsuario()
        {
                UsuarioExistente();
                ComandoVerificarExisteUsuario existencia = FabricaComandos.FabricarComandoVerificarExisteUsuario(user.Correo);
        }
        [TestMethod]
        public void ClaveAleatoriaGenerada()
        {
            string hola= null;
            try
            {
                ComandoGenerarClave clave = FabricaComandos.FabricarComandoGenerarClave();
                hola = clave.Ejecutar();
                Assert.IsTrue(Validador.ValidarClave(hola));
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ComandoEnvioCorreo()
        {
            try
            {
                ComandoEnviarCorreoRecuperacion clave = FabricaComandos.FabricarComandoEnviarCorreoRecuperacion(user.Correo,"epale");
                clave.Ejecutar();
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
            //No se puede enviar correo por el dominio no creado.
        }
        [TestMethod]
        public void ComandoCompararClavesValido()
        {
            try
            {
                UsuarioHash();
                ComandoCompararClaves clave = FabricaComandos.FabricarComandoCompararClaves(user, "pedro");
                clave.Ejecutar();
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
            //No se puede enviar correo por el dominio no creado.
        }
        [TestMethod]
        public void ComandoCompararClavesInvalido()
        {
            try
            {
                UsuarioHash();
                ComandoCompararClaves clave = FabricaComandos.FabricarComandoCompararClaves(user, "pedros");
                clave.Ejecutar();
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(e);
            //No se puede enviar correo por el dominio no creado.
        }
        [TestMethod]
        public void ComandoObtenerUsuarioFacebook()
        {
            try
            {
                e = null;
                user = null;
                ComandoObtenerUsuarioFacebook clave = FabricaComandos.FabricarComandoObtenerUsuarioFacebook("EAAEEJ6PSn74BABlS9vHF1gJyr1uFIcAko1vzClpZCALd26Ii3AXQnczFt4eSj5sZAEOZBGEiWCcKJpI5S2oOgYvkF12WgCu92D9sSuGEWI7vIuZAokvIC5kaa2BPpxHLsNLdo2rIU2lBcQK1WEzz4Uh2CtLFyoznynW17lMusHDbFIcFnTJWOc2cpxKYN3MZD");
                user = clave.Ejecutar();
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNotNull(user);
            Assert.IsNull(e);
            //cambiar a true si se obtiene el correo del token
            Assert.IsFalse(user.Correo.Equals("elesfuerzodeminami21@hotmail.com"));
        }
    }
}
