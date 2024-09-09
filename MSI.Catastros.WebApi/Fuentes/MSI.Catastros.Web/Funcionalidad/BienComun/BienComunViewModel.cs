using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.BienComun
{
    public class BienComunViewModel
    {
        [Display(Name="Nro. Tramite Documentario")]
        public string NumeroTramiteDocumentario { get; set; }
        [Display(Name="Nro. Solicitud")]
        public string NumeroSolicitud { get; set; }

        [Display(Name = "Estado Construccion")]
        public IEnumerable<SelectListItem> ListEstadoContruccion { get; set; }

        [Display(Name = "Código Inscripción Catastral")]
        public IEnumerable<SelectListItem> ListCodigoInscripcionCatastral { get; set; }

        [Display(Name = "Inscripción Catastral")]
        public IEnumerable<SelectListItem> ListInscripcionCatastral { get; set; }

        [Display(Name = "Fuente Inscripción Catastral")]
        public IEnumerable<SelectListItem> ListFuenteInscripcionCatastral { get; set; }

        [Display(Name = "Denominacion")]
        public IEnumerable<SelectListItem> ListDenominacion { get; set; }

        public string FechaUltimaInspeccion { get; set; }
        public string FechaActualizacion { get; set; }

        [Display(Name = "Uso del Predio")]
        public IEnumerable<SelectListItem> ListUsoPredio { get; set; }

        [Display(Name = "Clasificacion de Predio")]
        public IEnumerable<SelectListItem> ListClasificacionPredio { get; set; }

        [Display(Name = "Departamento de Predio")]
        public IEnumerable<SelectListItem> ListDepartamentoPredio { get; set; }

        [Display(Name = "Otras Instalaciones")]
        public IEnumerable<SelectListItem> ListOtrasInstalaciones { get; set; }


        public string CodigoEstadoConstruccion { get; set; }

        public string CodigoCodInscripcionCatastral { get; set; }

        public string CodigoInscripcionCatastral { get; set; }

        public string CodigoFuenteInscripcionCatastral { get; set; }

        public string CodigoDenominacion { get; set; }

        public string CodgiUsoPredio { get; set; }
        public string FlgIndependiente { get; set; }

        public string CodigoClasificacionPredio { get; set; }
        public string CodigoDepartamentoPredio { get; set; }
        public string CodigoCargaRegistral { get; set; }

        public string CodigoOtrasInstalaciones { get; set; }

        [Display(Name = "Codigo Unidad")]
        public int CodigoUnidadCatastral { get; set; }
        public int CodigoUnidadBienComun { get; set; }

        [Display(Name = "Distrito")]
        public string CodigoDistrito { get; set; }

        [Display(Name = "Sector")]
        public string CodigoSector { get; set; }

        [Display(Name = "Manzana")]
        public string CodigoManzana { get; set; }

        [Display(Name = "Lote")]
        public string CodigoLote { get; set; }

        [Display(Name = "Edificación")]
        public string CodigoEdificacion { get; set; }

        [Display(Name = "Entrada")]
        public string CodigoEntrada { get; set; }

        [Display(Name = "Piso")]
        public string CodigoPiso { get; set; }

        [Display(Name = "Unidad")]
        public string CodigoUnidad { get; set; }

        [Display(Name = "Cuc")]
        public string Cuc { get; set; }

        [Display(Name = "CodigoPredial")]
        public string CodigoPredial { get; set; }

        [Display(Name = "CodigoUnico")]
        public string CodigoUnico { get; set; }

        [Display(Name = "Denominacion")]
        public string Denominacion { get; set; }

        [Display(Name = "AvanceConstruccion")]
        public decimal? AvanceConstruccion { get; set; }

        public decimal? AreaTerrenoVerificada { get; set; }
        public decimal? AreaTerrenoComun { get; set; }
        public decimal? AreaTerrenoTotal { get; set; }
        public decimal? AreaConstruidaTotalVerificada { get; set; }
        public decimal? AreaConstruidaTotalDeclarada { get; set; }
        public decimal? AreaOcupada { get; set; }
        public decimal? AreaComunesOficial { get; set; }
        public decimal? AreaComunesCalculado { get; set; }
        public decimal? AreaTerrenoDeclarada { get; set; }
        public decimal? AreaTerrenoSubValuada { get; set; }
        public decimal? AreaTerrenoSobreValuada { get; set; }
        public decimal? AreaConstruidaSubValuada { get; set; }
        public decimal? AreaConstruidaSobreValuada { get; set; }
        public string codigollenado { get; set; }
        public string TipoLlenado { get; set; }

        public int Estado { get; set; }
        public HttpPostedFileBase archivo { get; set; }
        public bool Estatico { get; set; }
        public bool Consultas { get; set; }
    }

    public class RegistrarUnidadCatastralNuevoViewModel : FiltrarLotes
    {
        public string FiltrarCodigoDistrito { get; set; }
        public string FiltrarCodigoSector { get; set; }
        public string FiltrarCodigoManzana { get; set; }
        public string FiltrarCodigoLote { get; set; }
        public string FiltrarEd { get; set; }
        public string FiltrarEntrada { get; set; }
        public string FiltrarPiso { get; set; }
        public string FiltrarUnidad { get; set; }
        public string Estado { get; set; }

    }


    public class FiltrarBienComunViewModel : BienComunViewModel
    {
        [Display(Name = "Nro. Trámite Documentario")]
        public string FiltrarNumeroTramiteDocumentario { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }

        [Display(Name = "Tipo de Requerimiento")]
        public string TipoRequerimiento { get; set; }

        [Display(Name = "Tipo de Solicitud")]
        public string FiltrarCodigoTipoSolicitud { get; set; }
        [Display(Name = "Tipo de Documento")]
        public string FiltrarCodigoTipoDocumento { get; set; }

        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> FiltrarListTipoSolicitud { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> FiltrarListTipoDocumento { get; set; }

        public string FiltrarReferencia { get; set; }

        public string FiltrarCodigoDistrito { get; set; }
        public string FiltrarCodigoSector { get; set; }
        public string FiltrarCodigoManzana { get; set; }
        public string FiltrarCodigoLote { get; set; }
        public string FiltrarEd { get; set; }
        public string FiltrarEntrada { get; set; }
        public string FiltrarPiso { get; set; }
        public string FiltrarUnidad { get; set; }

        public string FiltrarCodigoTipoDocumentoReg { get; set; }

        public decimal Porcentaje { get; set; }
        public int Tipo { get; set; }

        public int Coduni { get; set; }
    }

    public class SolicitudUnidadViewModel
    {
        public string CodigoCatastral { get; set; }
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string Ed { get; set; }
        public string Entrada { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }
        public int? CodigoUni { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string Titular { get; set; }
        public string Ubicacion { get; set; }
        public string TipoLlenado { get; set; }
        public string EstadoUnidad { get; set; }
        public string Referencia { get; set; }
        public string flagTrabajo { get; set; }
        public string Version { get; set; }

        public string Bloqueado { get; set; }
        public string FechaActual { get; internal set; }
        public string Inscripcion { get; set; }
        public string UsoPredio { get; set; }
        public string CUC { get; set; }
        public string cucSEC { get; set; }


        public string NumeroInterior { get; set; }
        public string TipoInterior { get; set; }



        public bool Estatico { get; set; }
        public string FlagUsuario { get; set; }
    }

    public class FiltrarNumeroPredioViewModel : BienComunViewModel
    {
        public string CodigoVia { get; set; }
        public string numero { get; set; }
        public string letra { get; set; }
    }

    public class LineasContructivasViewModel
    {
        public string txtPiso { get; set; }
        public string Ano { get; set; }
        public string Bano { get; set; }
        public string Codigo { get; set; }
        public int? CodigoUnidadCatastral { get; set; }
        public decimal? Declarada { get; set; }
        public string Electricas { get; set; }
        public string EstadoConst { get; set; }
        public string Material { get; set; }
        public string Mes { get; set; }
        public string Muro { get; set; }
        public string Piso { get; set; }
        public string Puerta { get; set; }
        public string Revest { get; set; }
        public string Techo { get; set; }
        public decimal? Verificada { get; set; }
        public int Estado { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string Eliminado { get; set; }
        public string EstadoRegistro { get; set; }
        public bool Estatico { get; set; }

    }

    public class OtrasInstalacionesViewModel
    {
        public int? CodigoUnidadCatastral { get; set; }
        public string CodigoTipoInstalacion { get; set; }
        public string CodigoUnidad { get; set; }
        public decimal? Capacidad { get; set; }
        public int? Cantidad { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public string EstadoConserva { get; set; }
        public int Estado { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string Eliminado { get; set; }
        public string EstadoRegistro { get; set; }
        public bool Estatico { get; set; }
    }

    public class ActividadEconomicaViewModel
    {
        public int? CodigoUnidadCatastral { get; set; }
        public string CodigoUso { get; set; }
        public decimal? Metro { get; set; }
        public string Fecha { get; set; }
        public string Retiro { get; set; }
        public string Anuncio { get; set; }
        public string TipoAnuncio { get; set; }
        public int Estado { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string Eliminado { get; set; }
        public string EstadoRegistro { get; set; }
        public bool Estatico { get; set; }
    }

    public class ObservacionViewModel
    {
        public int? CodigoUnidadCatastral { get; set; }
        public string Fecha { get; set; }
        public string Observacion { get; set; }
        public string TipoObservacion { get; set; }
        public int Estado { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string Eliminado { get; set; }
        public string EstadoRegistro { get; set; }
        public bool Estatico { get; set; }
    }

    public class NumeracionPredioViewModel
    {
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string Ed { get; set; }
        public string Entrada { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }
        public int? CodigoUni { get; set; }
        public string CodigoCorrManzVia { get; set; }
        public string CodigoVia { get; set; }
        public string CodigoCorrLoteDirecc { get; set; }
        public string CodigoLado { get; set; }
        public string TipoInterior { get; set; }
        public string EstadoInterior { get; set; }
        public string NombreTipoInterior { get; set; }
        public string NombreEstadoInterior { get; set; }
        public string NumeroInterior { get; set; }
        public string LetraInterior { get; set; }

        public string TipoInscripcion { get; set; }
        public string Asignacion { get; set; }
        public int Estado { get; set; }
        public string Item { get; set; }
        public string NombreVia { get; set; }
        public string NumeroCuadra { get; set; }
        public string NombreLado { get; set; }
        public string NombreTipoEdificacion { get; set; }
        public string NumTipoEdificacion { get; set; }
        public string NombreInscripcion { get; set; }
        public string NombreTipoPuerta { get; set; }
        public string NumeroPuerta { get; set; }
        public string LetraPuerta { get; set; }
        public string NombreAsignacion { get; set; }
        public string CodigoCorrDirecUnidad { get; set; }
        [Display(Name = "Tipo Interior")]
        public IEnumerable<SelectListItem> ListTipoInterior { get; set; }
        [Display(Name = "Estado Interior")]
        public IEnumerable<SelectListItem> ListEstadoInterior { get; set; }
        public IEnumerable<SelectListItem> ListarTipoDireccion { get; set; }

        public IEnumerable<SelectListItem> ListInscripcionCatastral { get; set; }
        public bool Estatico { get; set; }
        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        public string NumeroMunicipal { get; set; }
        public string NumeroExpediente { get; set; }
        public string NumeroLicencia { get; set; }
        public string CodigoUbicacion { get; set; }
        public string UbicacionAnuncio { get; set; }
        public string CodigoTipo { get; set; }
        public string Tipo { get; set; }
        public string CodigoMaterial { get; set; }
        public string Material { get; set; }
        public string AreaAnuncioLicencia { get; set; }
        public string AreaAnuncioVerificada { get; set; }
        public string DiaFechaExpediente { get; set; }
        public string MesFechaExpediente { get; set; }
        public string AnioFechaExpediente { get; set; }
        public string DiaFechaVencimiento { get; set; }
        public string MesFechaVencimiento { get; set; }
        public string AnioFechaVencimiento { get; set; }
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
    }


    public class LoteLinderosViewModel : FiltrarLotes
    {
        public string CodigoLado { get; set; }
        public string CodigoFuente { get; set; }
        public string NumeroLado { get; set; }
        public decimal? MedidaLadoOfi { get; set; }
        public decimal? MedidaLadoCam { get; set; }
        public string CodigoTipoColind { get; set; }
        public string CodigoColindante { get; set; }
        public string Codigo { get; set; }

        public string CodigoViaAnterior { get; set; }

        public string Estado { get; set; }

        public string CorrelativoNorma { get; set; }
        public bool Estatico { get; set; }
    }

    public class UnidadTitularViewModel
    {
        public int? CodigoUni { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RasonSocial { get; set; }
        public string CodigoContribuyente { get; set; }
        public string TipoPropietario { get; set; }
        public string CondicionPropiedad { get; set; }
        public string PorcentajeTitularidad { get; set; }
        public int Estado { get; set; }
        public string Item { get; set; }
        public bool Estatico { get; set; }

    }

    public class UnidadBCViewModel
    {
        public int? CodigoUniBC { get; set; }
        public int? CodigoUnico { get; set; }
        public string Correlativo { get; set; }
        public string CodigoCatastral { get; set; }
        public int Estado { get; set; }
        //CODIGO DERIVADO DE PROCEDIMIENTO INICIAL
        public int? CodigoUni { get; set; }
        public string Item { get; set; }
        public decimal? AreaComunesOficial { get; set; }
        public decimal? AreaTerrenoComun { get; set; }
        public decimal? AreaOcupada { get; set; }
        public string FlgIndependiente { get; set; }

        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string Ed { get; set; }
        public string Entrada { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }
        public string EstadoUnidad { get; set; }

    }
    public class FiltrarUnidadCatastralViewModel
    {
        [Required]
        public string FiltrarCodigoDistritoReg { get; set; }
        [Required]
        public string FiltrarCodigoSectorReg { get; set; }
        [Required]
        public string FiltrarCodigoManzanaReg { get; set; }
        [Required]
        public string FiltrarCodigoLoteReg { get; set; }
        public string FiltrarTipoBusquedaReg { get; set; }
        public string FiltrarCodigoViaReg { get; set; }
        public int FiltrarNumeroCuadraReg { get; set; }
        public string FiltrarNumeroPuertaReg { get; set; }
        public string FiltrarEdReg { get; set; }
        public string FiltrarEntradaReg { get; set; }
        public string FiltrarPisoReg { get; set; }
        public string FiltrarUnidadReg { get; set; }

        public string CodigoCorrelativo { get; set; }
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }
        public string CodigoUnico { get; set; }


        //CODIGO DERIVADO DE PROCEDIMIENTO INICIAL
        public string CodigoUni { get; set; }

        public string hidTipoBusqueda { get; set; }
        public int Estado { get; set; }
    }

    public class LoteDocumentosRRPPViewModel
    {
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public string CodigoDocumento { get; set; }
        public string PartidaElectronica { get; set; }
        public string TomoFicha { get; set; }
        public string Folio { get; set; }
        public string Asiento { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public string Estado { get; set; }
        public string Ruta { get; set; }
        public string TipoDocumento { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public string Item { get; set; }
        public bool Estatico { get; set; }
    }

    public class LicenciaFuncViewModel : FiltrarLotes
    {
        public string Item { get; set; }
        public string Solicitante { get; set; }
        public string Beneficiario { get; set; }
        public string TipoLicencia { get; set; }
        public string NumeroLicencia { get; set; }
        public string Giros { get; set; }
        public string FechaLicencia { get; set; }
        public string CodigoCatastral { get; set; }
        public string Observaciones { get; set; }
        public string PDF { get; set; }
        public string EstadoLicencia { get; set; }
        public string Codigo { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public bool Estatico { get; set; }
    }
    public class ObrasPublicasViewModel : FiltrarLotes
    {
        public string Item { get; set; }
        public string Solicitante { get; set; }
        public string Beneficiario { get; set; }
        public string TipoObra { get; set; }
        public string NumeroLicencia { get; set; }
        public string FechaLicencia { get; set; }
        public string CodigoCatastral { get; set; }
        public string Observaciones { get; set; }
        public string PDF { get; set; }
        public string EstadoLicencia { get; set; }
        public string Codigo { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public bool Estatico { get; set; }
    }
    public class UnidadDocumentosRRPPViewModel : FiltrarLotes
    {
        public int? CodigoUni { get; set; }
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public string PartidaElectronica { get; set; }
        public string TomoFicha { get; set; }
        public string Folio { get; set; }
        public string Asiento { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public int Estado { get; set; }
        public string Ruta { get; set; }
        public string TipoDocumento { get; set; }
        public string CodigoDocumento { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public string Item { get; set; }
        public bool Estatico { get; set; }
    }

    public class FiltrarLotes
    {
        public string CodigoDepartamento { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
    }

    public class LoteExpedienteDocViewModel : FiltrarLotes
    {
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public string Solicitante { get; set; }
        public string Documento { get; set; }
        public string Numero { get; set; }
        public string Codigo { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public string Flag { get; set; }
        public string Estado { get; set; }
        public string Item { get; set; }
        public bool Estatico { get; set; }
    }

    public class UnidadExpedienteDocViewModel : FiltrarLotes
    {
        public int? CodigoUni { get; set; }
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public string Solicitante { get; set; }
        public string Documento { get; set; }
        public string Numero { get; set; }
        public string Codigo { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public string Flag { get; set; }
        public string Item { get; set; }
        public int Estado { get; set; }
        public bool Estatico { get; set; }
    }
    public class UnidadLicenciaFuncViewModel
    {
        public int? CodigoUni { get; set; }
        public string Solicitante { get; set; }
        public string Beneficiario { get; set; }
        public string TipoLicencia { get; set; }
        public string NumeroLicencia { get; set; }
        public string Giros { get; set; }
        public string FechaLicencia { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public int Estado { get; set; }
        public string Ruta { get; set; }
        public string TipoDocumento { get; set; }
        public string CodigoDocumento { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public string Item { get; set; }
        public string Codigo { get; set; }
        public bool Estatico { get; set; }
    }
    public class UnidadObrasPrivadasViewModel
    {
        public int? CodigoUni { get; set; }
        public string Solicitante { get; set; }
        public string Beneficiario { get; set; }
        public string TipoObra { get; set; }
        public string NumeroLicencia { get; set; }
        public string FechaLicencia { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string CodigoCorrelativoLote { get; set; }
        public int Estado { get; set; }
        public string Ruta { get; set; }
        public string TipoDocumento { get; set; }
        public string CodigoDocumento { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public string Item { get; set; }
        public string Codigo { get; set; }
        public bool Estatico { get; set; }
    }

    public class BienComunLinderosViewModel : FiltrarLotes
    {
        public string CodigoLado { get; set; }
        public string CodigoFuente { get; set; }
        public string NumeroLado { get; set; }
        public decimal? MedidaLadoOfi { get; set; }
        public decimal? MedidaLadoCam { get; set; }
        public string CodigoTipoColind { get; set; }
        public string CodigoColindante { get; set; }
        public string Codigo { get; set; }

        public Int32? CODUNI { get; set; }

        public string CodigoViaAnterior { get; set; }

        public string Estado { get; set; }

        public string CorrelativoNorma { get; set; }
        public bool Estatico { get; set; }
        public string NombreLado { get; set; }
        public IEnumerable<SelectListItem> ListTipoColindante { get; set; }
        public IEnumerable<SelectListItem> ListLado { get; set; }
        public List<SelectListItem> ListaColindantes { get; set; }
        public List<SelectListItem> ListaUnidadesColindantes { get; set; }
        public string CodUnidadLindero { get; set; }
        public string ListaUnidadColindantes { get; set; }
        public string NombreTipoColindante { get; set; }
        public string NombreColindante { get; set; }
        public string Correlativo { get; set; }
        public string CodigoCorrelativo { get; set; }
    }
}