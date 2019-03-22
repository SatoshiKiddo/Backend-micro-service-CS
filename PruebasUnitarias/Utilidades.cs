using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System.ServiceModel.Security;
using Google.Apis.Auth.OAuth2;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using Google.Apis.Plus.v1.Data;
using static Google.Apis.Plus.v1.Data.Person;
using System.Collections.Generic;
using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login.Utilidades;

namespace ServicioLotoUCAB.Servicio.PruebasUnitarias
{
    [TestClass]
    public class Utilidades
    {

        private Usuario user;
        private string buffer;
        private string comp;
        private LotoUcabException e;
        private Person personGoogle;

        [TestInitialize]
        public void TestInitialize()
        {
            buffer = "perro";
            comp = "perro";
            e = null;
            personGoogle = new Person();
            personGoogle.Nickname = "kiddo";
            EmailsData email = new EmailsData();
            email.Value = "pjfariakiddo@gmail.com";
            email.Type = "acount";
            personGoogle.Emails = new List<EmailsData>();
            personGoogle.Emails.Add(email);
            NameData name = new NameData();
            name.FamilyName = "Faria";
            name.GivenName = "Pedro";
            name.MiddleName = "Jose";
            personGoogle.Name = name;
            user = new Usuario();
            user.Apellido = "Faria";
            user.Caducidad = 3;
            user.Clave = "aA1$123456789";
            user.Correo = "pjfariakiddo@gmail.com";
            user.Id = 13;
            user.Id_TipoUsuario = 7;
            user.Nombre = "Pedro";
            user.Nombre_Usuario = "Kiddo";
            user.Numero_Identificacion = "26466404";
            user.Status = 0;
        }

        [TestMethod]
        public void EncriptacionValida()
        {
            try
            {
                buffer = MD5Encrypth.Encriptar(buffer);
            }
            catch(MD5Exception ex)
            {
                this.e = new LotoUcabException(ex);
            }
            Assert.AreNotEqual(buffer,"perro");
            Assert.IsNull(e);
        }
        [TestMethod]
        public void EncriptacionInvalida()
        {
            try
            {
                buffer = MD5Encrypth.Encriptar(null);
            }
            catch (MD5Exception ex)
            {
                //Se comprueba que hay un error al pasar un parámetro nulo.
                this.e = new LotoUcabException(ex);
            }
            Assert.AreEqual(buffer, "perro");
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ComparacionHashValido()
        {
            try
            {
                buffer = MD5Encrypth.Encriptar(buffer);
            }
            catch (MD5Exception ex)
            {
                this.e = new LotoUcabException(ex);
            }
            Assert.IsTrue(MD5Encrypth.CompararHash(comp,buffer));
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ComparacionHashNull()
        {
            try
            {
                buffer = MD5Encrypth.Encriptar(null);
            }
            catch (MD5Exception ex)
            {
                this.e = new LotoUcabException(ex);
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ComparacionHashInvalido()
        {
            try
            {
                buffer = MD5Encrypth.Encriptar("pelo");
            }
            catch (MD5Exception ex)
            {
                this.e = new LotoUcabException(ex);
            }
            Assert.IsFalse(MD5Encrypth.CompararHash(comp, buffer));
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ConversiondeUsuarioGoogleValido()
        {
            try
            {
                user = null;
                user = PersonConvert.CrearUsuario(personGoogle);
            }
            catch (Exception ex)
            {
                this.e = new LotoUcabException(ex);
            }
            Assert.IsNotNull(user);
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ConversiondeUsuarioGoogleInvalido()
        {
            try
            {
                user = null;
                user = PersonConvert.CrearUsuario(null);
            }
            catch (Exception ex)
            {
                this.e = new LotoUcabException(ex);
            }
            Assert.IsNull(user);
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioClaveEspaciosBlancos()
        {
            try
            {
                user.Clave = " ";
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuario()
        {
            try
            {
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioClaveVacia()
        {
            try
            {
                user.Clave = "";
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioClaveNull()
        {
            try
            {
                user.Clave = null;
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioClaveInvalida()
        {
            try
            {
                user.Clave = "pedritoeleapsoreaf";
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioClaveCorta()
        {
            try
            {
                user.Clave = "pedrito";
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioNull()
        {
            try
            {
                Validador.ValidarFormulario(null);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioAtributoNull()
        {
            try
            {
                user.Apellido = null;
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioAtributoVacio()
        {
            try
            {
                user.Apellido = "";
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
        [TestMethod]
        public void ValidacionFormUsuarioAtributoEspaciosBlancos()
        {
            try
            {
                user.Apellido = "  ";
                Validador.ValidarFormulario(user);
            }
            catch (CamposInvalidosException ex)
            {
                this.e = ex;
            }
            Assert.IsNotNull(e);
        }
    }
}
