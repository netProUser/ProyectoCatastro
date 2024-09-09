using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.Exceptions
{
    public class ExceptionsParameters : Exceptions
    {
        private const string DEFAULT_TITULO = "Advertencia";
        private const string DEFAULT_MENSAJE = "Revise los parámetros enviados";
        private const General.ExceptionType DEFAULT_TIPO = General.ExceptionType.Warning;

        public ExceptionsParameters() : base(DEFAULT_MENSAJE) { }

        public ExceptionsParameters(string mensaje)
            : base(mensaje)
        {
            this.Tipo = DEFAULT_TIPO;
            this.Titulo = DEFAULT_TITULO;
        }

        public ExceptionsParameters(string mensaje, string logMensaje)
            : base(mensaje, logMensaje)
        {
            this.Tipo = DEFAULT_TIPO;
            this.Titulo = DEFAULT_TITULO;
        }

        public ExceptionsParameters(string titulo, string mensaje, General.ExceptionType tipo) :
            base(titulo, mensaje, tipo) { }

        public ExceptionsParameters(string titulo, string mensaje, string logMensaje, General.ExceptionType tipo) :
            base(titulo, mensaje, logMensaje, tipo) { }

        public ExceptionsParameters(string mensaje, Exception inner)
            : base(mensaje, inner)
        {
            this.Tipo = DEFAULT_TIPO;
            this.Titulo = DEFAULT_TITULO;
        }
    }
}
