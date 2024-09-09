using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.Exceptions
{
    public class Exceptions : Exception
    {
        public string Titulo { get; set; }
        public General.ExceptionType Tipo { get; set; }
        public string LogMensaje { get; set; }

        private const string DEFAULT_TITULO = "Oops...";
        private const string DEFAULT_MENSAJE = "Ocurrio un problema inesperado, vuelva a intentarlo porfavor.";
        private const General.ExceptionType DEFAULT_TIPO = General.ExceptionType.Error;

        public Exceptions()
            : base(DEFAULT_MENSAJE)
        {
            init(DEFAULT_TITULO, DEFAULT_MENSAJE, DEFAULT_TIPO);
        }

        public Exceptions(string mensaje)
            : base(mensaje)
        {
            init(DEFAULT_TITULO, mensaje, DEFAULT_TIPO);
        }

        public Exceptions(string mensaje, string logMensaje)
            : base(mensaje)
        {
            init(DEFAULT_TITULO, logMensaje, DEFAULT_TIPO);
        }

        public Exceptions(string titulo, string mensaje, General.ExceptionType tipo)
            : base(mensaje)
        {
            init(titulo, mensaje, tipo);
        }

        public Exceptions(string titulo, string mensaje, string logMensaje, General.ExceptionType tipo)
            : base(mensaje)
        {
            init(titulo, logMensaje, tipo);
        }

        public Exceptions(string mensaje, Exception inner)
            : base(mensaje, inner)
        {
            init(DEFAULT_TITULO, mensaje, DEFAULT_TIPO);
        }

        /// <summary>
        /// 
        /// </summary>
        private void init(string titulo, string logMensaje, General.ExceptionType tipo)
        {
            this.Titulo = titulo;
            this.LogMensaje = logMensaje;
            this.Tipo = tipo;
        }
        /// <summary>
        /// 
        /// </summary>
        public string GetTipoValor()
        {
            switch (Tipo)
            {
                case General.ExceptionType.Warning: return "warning";
                case General.ExceptionType.Error: return "error";
                case General.ExceptionType.Success: return "success";
                case General.ExceptionType.Info: return "info";
                default: return "info";
            }
        }
    }
}
