using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.Exceptions.Abstracts
{
    public class ExceptionsBadRequest : Exceptions
    {
        private const string DEFAULT_TITULO = "Alerta";
        private const string DEFAULT_MENSAJE = "Ocurrio un problema y no se encontraron datos.";
        private const General.ExceptionType DEFAULT_TIPO = General.ExceptionType.Warning;

        public ExceptionsBadRequest() : base(DEFAULT_MENSAJE) { }

        public ExceptionsBadRequest(string mensaje)
            : base(mensaje)
        {
            this.Tipo = DEFAULT_TIPO;
            this.Titulo = DEFAULT_TITULO;
        }

        public ExceptionsBadRequest(string mensaje, string logMensaje)
            : base(mensaje, logMensaje)
        {
            this.Tipo = DEFAULT_TIPO;
            this.Titulo = DEFAULT_TITULO;
        }

        public ExceptionsBadRequest(string titulo, string mensaje, General.ExceptionType tipo) :
            base(titulo, mensaje, tipo) { }

        public ExceptionsBadRequest(string titulo, string mensaje, string logMensaje, General.ExceptionType tipo) :
            base(titulo, mensaje, logMensaje, tipo) { }

        public ExceptionsBadRequest(string mensaje, Exception inner)
            : base(mensaje, inner)
        {
            this.Tipo = DEFAULT_TIPO;
            this.Titulo = DEFAULT_TITULO;
        }
    }
}
