using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Certificados
{
    public class CertificadosViewModel
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
        public string[] Partida { get; set; }
        public string PartidaString { get; set; }
        public string Urbanizacion { get; set; }
        public string Direccion { get; set; }
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }

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
        public string EstadoResul { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string CodigoEdificacion { get; set; }
        public string CodigoEntrada { get; set; }
        public string CodigoPiso { get; set; }
        public string CodigoUnidad { get; set; }
        public string CUC { get; set; }
        public string FechaPago { get; set; }
        public string CodigoLado { get; set; }
        public string UnidadDireccion { get; set; }
        public string Nivel { get; set; }
        public string NivelDescripcion { get; set; }
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
        public string CodAnioSolicitud { get; set; }
    }

    public class ImagenCertificado
    {
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoCertificado { get; set; }
        public string FiltrarCodigoTipoCertificado { get; set; }
        public string CodigoImagen { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public string rutaImagen { get; set; }
        public string CodAnioSolicitud { get; set; }
    }
    public class RegistrarArchivos
    {
        public string FiltrarCodigoCertificado { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoCorrelativo { get; set; }
        public string FiltrarCodigoTipoCertificado { get; set; }
        public string FiltrarCodigoTipoSolicitud { get; set; }
        public string FiltrarCodigoTipoDocumentoReg { get; set; }
        public string FiltrarNumeroSolicitud { get; set; }
        public string CodigoCatastral { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public bool Actualizar { get; set; }
        public string CodAnioSolicitud { get; set; }
        public byte[] documento { get; set; }
        public HttpPostedFileBase File { get; set; }
        public HttpPostedFileBase archivo { get; set; }
    }
    public class CertificadosReciboViewModel
    {
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoCertificado { get; set; }
        public string FiltrarCodigoTipoCertificado { get; set; }
        public string FiltrarCodigoCorrelativo { get; set; }
        public string Item { get; set; }
        public string NumeroRecibo { get; set; }
        public string FechaRecibo { get; set; }
        public string Correlativo { get; set; }
        public string CodigoUnico { get; set; }
        public string Estado { get; set; }
        public string CodAnioSolicitud { get; set; }

    }
    public class CertificadosDetalleViewModel
    {
        public string FiltrarCodigoPeriodo { get; set; }
        public string FiltrarCodigoCertificado { get; set; }
        public string FiltrarCodigoTipoCertificado { get; set; }
        public string FiltrarCodigoCorrelativo { get; set; }
        public string Item { get; set; }
        public string CodigoVia { get; set; }
        public string NombreVia { get; set; }
        public string TipoPuerta { get; set; }
        public string CodigoTipoPuerta { get; set; }
        public string NombrePuerta { get; set; }
        public string NumeroPuerta { get; set; }
        public string Interior { get; set; }
        public string NombreViaAntReal { get; set; }
        public string TipoInterior { get; set; }
        public string CodigoTipoInterior { get; set; }
        public string CodigoViaEsq { get; set; }
        public string Marcado { get; set; }
        public string NombreViaEsq { get; set; }
        public string NombreViaAnt { get; set; }
        public string TipoVia { get; set; }
        public string TipoViaAnt { get; set; }
        public string DescripcionInscrip { get; set; }
        public string NombreTipoVia { get; set; }
        public string Nivel { get; set; }
        public string Edificacion { get; set; }


        public string CodigoCorrelativoUnidad { get; set; }
        public string CodigoUni { get; set; }

        public string TipoViaEsq { get; set; }
        public string NombreViaEsqAnt { get; set; }
        public string TipoViaEsqAnt { get; set; }
        public string CodAnioSolicitud { get; set; }

    }
}
