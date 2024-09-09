using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Cartas
{
    public class CartasViewModel
    {
        [Display(Name = "Tipo de Carta")]
        public IEnumerable<SelectListItem> ListTipoInforme { get; set; }
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public IEnumerable<SelectListItem> ListTipoUbicacion { get; set; }
        public IEnumerable<SelectListItem> ListTipoInspectores { get; set; }
        public IEnumerable<SelectListItem> ListTitulares { get; set; }
        public IEnumerable<SelectListItem> ListDiasProgramados { get; set; }
        [Display(Name = "Tipo Destinatario")]
        public IEnumerable<SelectListItem> ListTipoPersona { get; set; }
        public string TipoPersonas { get; set; }
        public string CodigoDocumentoGenerado { get; set; }
        public string CalidadVerificacion { get; set; }

        public string FiltrarCodigoCorrelativo { get; set; }
        public string FiltrarCodigoPeriodoInforme { get; set; }   
        public string FiltrarCodigoTipoInforme { get; set; }        
        public string FiltrarCodigoTipoSolicitud { get; set; }
        [Display(Name = "Nro. Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoCarta { get; set; }        
        public string FiltrarCodigoTipoDocumentoReg { get; set; }
        public string FiltrarNumeroInspeccion { get; set; }
        public string NombreSolicitante { get; set; }
        public string NombreRepresentante { get; set; }

        public string CodigoCatastral { get; set; }
        public string CodigoUnico { get; set; }
        public string Ubicacion { get; set; }
        public string FechaGeneracion { get; set; }
        public string FechaCitacion { get; set; }
        public string FechaNueva { get; set; }
        public string CodigoUsuario { get; set; }
        public string Documento { get; set; }
        public string Item { get; set; }
        

        //Datos Precargados
        #region REPORTE1
        
        public string FechaInspeccion { get; set; }
        public string Solicitante { get; set; }

        [Display(Name = "TituloGeneral")]
        public string TituloGeneral { get; set; }
        [Display(Name = "CodigoOficina")]
        public string CodigoOficina { get; set; }
        [Display(Name = "Sigla")]
        public string NombreSigla { get; set; }
        [Display(Name = "Nombre del Año")]
        public string NombreAnio { get; set; }
        public string HoraInspeccion { get; set; }

        [Display(Name = "Subtitulo1")]
        public string Subtitulo1 { get; set; }
        [Display(Name = "Subtitulo2")]
        public string Subtitulo2 { get; set; }
        [Display(Name = "Subtitulo3")]
        public string Subtitulo3 { get; set; }
        [Display(Name = "Subtitulo4")]
        public string Subtitulo4 { get; set; }
        [Display(Name = "Subtitulo5")]
        public string Subtitulo5 { get; set; }
        [Display(Name = "Subtitulo6")]
        public string Subtitulo6 { get; set; }
        [Display(Name = "Subtitulo7")]
        public string Subtitulo7 { get; set; }

        [Display(Name = "Parrafo1")]
        public string Parrafo1 { get; set; }
        [Display(Name = "Parrafo2")]
        public string Parrafo2 { get; set; }
        [Display(Name = "Parrafo3")]
        public string Parrafo3 { get; set; }
        [Display(Name = "Parrafo4")]
        public string Parrafo4 { get; set; }
        [Display(Name = "Parrafo5")]
        public string Parrafo5 { get; set; }
        [Display(Name = "Parrafo6")]
        public string Parrafo6 { get; set; }
        [Display(Name = "Parrafo7")]
        public string Parrafo7 { get; set; }
        [Display(Name = "Parrafo8")]
        public string Parrafo8 { get; set; }
        [Display(Name = "Parrafo9")]
        public string Parrafo9 { get; set; }
        [Display(Name = "Parrafo10")]
        public string Parrafo10 { get; set; }

        [Display(Name = "Firma1")]
        public string Firma1 { get; set; }
        [Display(Name = "Firma2")]
        public string Firma2 { get; set; }
        [Display(Name = "Firma3")]
        public string Firma3 { get; set; }
        [Display(Name = "Firma4")]
        public string Firma4 { get; set; }
        [Display(Name = "Firma5")]
        public string Firma5 { get; set; }
        [Display(Name = "PiePagina")]
        public string PiePagina { get; set; }
       
        #endregion
        [Display(Name = "Version")]
        public IEnumerable<SelectListItem> ListVersionInforme { get; set; }
        public string FiltrarCodigoVersion { get; set; }
        public string EstadoResul { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string Inspectores { get; set; }
        public string Inspecciones { get; set; }
        public string CodigoInspectores { get; set; }

        public string EstadoInspeccion { get; set; }


        public string CodigoCorrelativoTramite { get; set; }
    }

    public class RegistrarArchivos
    {
        public string FiltrarCodigoCarta { get; set; }        
        public string FiltrarCodigoPeriodoInforme { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoCorrelativo { get; set; }
        public string FiltrarCodigoTipoInforme { get; set; }
        public string FiltrarCodigoTipoSolicitud { get; set; }
        public string FiltrarCodigoTipoDocumentoReg { get; set; }
        public string FiltrarNumeroSolicitud { get; set; }
        public string CodigoInforme { get; set; }
        public string CodigoCatastral { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public bool Actualizar { get; set; }
        public byte[] documento { get; set; }
        public HttpPostedFileBase File { get; set; }
        public HttpPostedFileBase archivo { get; set; }
    }
}
