using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.ConsultaCertificados
{
    public class ConsultaCertificadosViewModel
    {
        [Display(Name = "Tipo de Certificado")]
        public IEnumerable<SelectListItem> ListTipoInforme { get; set; }
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public IEnumerable<SelectListItem> ListTipoUbicacion { get; set; }
        public IEnumerable<SelectListItem> ListTipoInspectores { get; set; }
        public IEnumerable<SelectListItem> ListTitulares { get; set; }
        public IEnumerable<SelectListItem> ListTipoInscripcion { get; set; }
        public IEnumerable<SelectListItem> ListDiasProgramados { get; set; }
        [Display(Name = "Tipo Destinatario")]
        public IEnumerable<SelectListItem> ListTipoPersona { get; set; }
        public string TipoPersonas { get; set; }
        public string CodigoDocumentoGenerado { get; set; }
        public string Ruta { get; set; }
        public string CodigoVia { get; set; }
        public string FlagTrabajo { get; set; }
        public string CalidadVerificacion { get; set; }
        public string FiltrarCodigoCorrelativo { get; set; }
        public string FiltrarCodigoPeriodoCertificado { get; set; }
        public string FiltrarCodigoTipoCertificado { get; set; }
        public string FiltrarCodigoTipoSolicitud { get; set; }
        [Display(Name = "Nro. Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoCertificado { get; set; }
        public string CodigoCertificadoTemp { get; set; }
        public string FiltrarCodigoTipoDocumentoReg { get; set; }
        public string FiltrarNumeroInspeccion { get; set; }
        public string CodigoCatastral { get; set; }
        public string CodigoUnico { get; set; }
        public string Ubicacion { get; set; }
        public string ManzanaUrbana { get; set; }
        public string LoteUrbano { get; set; }
        public string SubLoteUrbano { get; set; }
        public string Bloqueado { get; set; }
        public string FechaGeneracion { get; set; }
        public string FechaNueva { get; set; }
        public string Item { get; set; }
        public string CodigoCorrelativoTramite { get; set; }
        public string Titulo { get; set; }
        public string NumeroSolicitud { get; set; }

        public string FlagReporte { get; set; }
        public string Anotaciones { get; set; }
        public string Interior { get; set; }
        public string CodigoHojaCatastral { get; set; }


        public string TipoInscripcion { get; set; }
        public string UbicacionPolitica { get; set; }
        public string InscripcionCatastral { get; set; }
        public string Recibo { get; set; }
        public string HojaPlano { get; set; }
        public string EscalaPlano { get; set; }

        public string CodigoUsuario { get; set; }
        public string  Nro { get; set; }
        public string CodigoCertificado { get; set; }

        public string CodigoAnioCertificado { get; set; }
        public string codigoAnio { get; set; }
        public string CodigoTipoSolicitud { get; set; }
        public string NombreTipoSolicitud { get; set; }

        public string CodigoTipoCertificado { get; set; }
        public string  NombreTipoCertificado { get; set; }
        public string FechaRegistro { get; set; }
        public string TipoDocumento { get; set; }
        public string CodigoDocumento { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string txtCodigoCatastral { get; set; }
    }




}