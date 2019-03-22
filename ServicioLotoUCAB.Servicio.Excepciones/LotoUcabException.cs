using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones
{
    public class LotoUcabException : Exception
    {
        protected string _error;
        protected int _codigo;
        protected Exception _excepcionOrigen;

        public LotoUcabException(Exception ex)
        {
            this.ExcepcionOrigen = ex;
        }

        public LotoUcabException(string error, int codigo)
        {
            this.Error = error;
            this.Codigo = codigo;
        }

        public LotoUcabException(Exception ex, string error, int codigo)
        {
            this.ExcepcionOrigen = ex;
            this.Error = error;
            this.Codigo = codigo;
        }

        public LotoUcabException(){ }

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public Exception ExcepcionOrigen
        {
            get { return _excepcionOrigen; }
            set { _excepcionOrigen = value; }
        }
    }
}
