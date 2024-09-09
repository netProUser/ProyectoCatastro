using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Lotes
{
    public class FiltrarLotesViewModel
    {
        [Display(Name = "Nro. Trámite Documentario")]
        public string FiltrarNumeroTramiteDocumentario { get; set; }
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        public string FiltrarCodigoTipoSolicitud { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public string FiltrarCodigoTipoDocumentoReg { get; set; }
        public string FiltrarReferencia { get; set; }

        public bool Estatico { get; set; }
        public bool Consultas { get; set; }
        public string FiltrarCodigoDistrito { get; set; }
        public string FiltrarCodigoSector { get; set; }
        public string FiltrarCodigoManzana { get; set; }
        public string FiltrarCodigoLote { get; set; }
        public string Bloqueado { get; set; }

    }
    public class FiltrarLotes
    {
        public string CodigoDepartamento { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string CodigoLoteColidante { get; set; }
    }

    public class LoteSolicitudViewModel : FiltrarLotes
    {
        public string CodigoNumeroSolicitud { get; set; }
    }
    public class LoteLinderosViewModel : FiltrarLotes
    {
        public IEnumerable<SelectListItem> ListLado { get; set; }
        public IEnumerable<SelectListItem> ListFuente { get; set; }
        public IEnumerable<SelectListItem> ListTipoColindante { get; set; }
        public IEnumerable<SelectListItem> ListColindante { get; set; }

        public IEnumerable<SelectListItem> ListAlturaVia { get; set; }
        public string CodigoAlturaVia { get; set; }
        public string CodigoLado { get; set; }
        public string CodigoVia { get; set; }
        public string NombreLado { get; set; }
        public string CodigoFuenteCol { get; set; }
        public string NombreFuente { get; set; }
        public string NumeroLado { get; set; }
        public decimal? MedidaLadoOfi { get; set; }
        public decimal? MedidaLadoCam { get; set; }
        public string CodigoTipoColind { get; set; }
        public string CodigoColindante2 { get; set; }
        public string NombreTipoColindante { get; set; }

        public List<SelectListItem> ListaCodigoColindante { get; set; }

        public string CodigoColindante { get; set; }
        public string CodigoTipoColindante2 { get; set; }
        public string NombreColindante { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string Codigo { get; set; }

        public string CodigoViaAnterior { get; set; }

        public string Estado { get; set; }

        public string CorrelativoNorma { get; set; }
        public bool Estatico { get; set; }

        public List<SelectListItem> ListaColindantes { get; set; }
        public string ListaLoteColindantes { get; set; }
        public string Correlativo { get; set; }
        public string CodigoCorManzana { get; set; }

        public string CodigoTipoDocumento { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string Solicitante { get; set; }
        public string FechaDocumento { get; set; }
        public string Observacion { get; set; }
        public string CodigoTramite { get; set; }
        public string CodigoSolicitante { get; set; }

        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        public string CodigoFlatAvenida { get; set; }
        public string CodigoFlatParque { get; set; }
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
    }
    public class UnidadCatastralViewModel
    {
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string Ed { get; set; }
        public string Entrada { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }

        public string Titular { get; set; }
        public string Ubicacion { get; set; }

        public int? CodigoUni { get; set; }

        public string CodigoCorrelativo { get; set; }
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }

        public string CodigoTitular { get; set; }


        public int Indice { get; set; }

        public string Activo { get; set; }

    }
    public class FiltrarUnidadCatastralViewModel
    {
        [Required]
        public string FiltrarCodigoDistrito { get; set; }
        [Required]
        public string FiltrarCodigoSector { get; set; }
        [Required]
        public string FiltrarCodigoManzana { get; set; }
        [Required]
        public string FiltrarCodigoLote { get; set; }
        public string FiltrarEd { get; set; }
        public string FiltrarEntrada { get; set; }
        public string FiltrarPiso { get; set; }
        public string FiltrarUnidad { get; set; }

        public string CodigoCorrelativo { get; set; }
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }

        public int Estado { get; set; }
    }

    public class LoteNormaUrbanaViewModel : FiltrarLotes
    {
        public decimal? Altura { get; set; }
        public string Observacion { get; set; }
        public string Via { get; set; }
        public string CodVia { get; set; }
        public string CodManzanaVia { get; set; }

        public IEnumerable<SelectListItem> ListZonificacion { get; set; }
        public IEnumerable<SelectListItem> ListAltura { get; set; }
        public string ZonificacionVia { get; set; }
        public string AlturaVia { get; set; }
        public string Estado { get; set; }
        public bool Estatico { get; set; }
    }
    public class RegistrarLoteNuevoViewModel : FiltrarLotes
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
    public class LoteDocumentosRRPPViewModel : FiltrarLotes
    {
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public string CodigoDocumento { get; set; }
        public string PartidaElectronica { get; set; }
        public string TomoFicha { get; set; }
        public string Folio { get; set; }
        public string Asiento { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public string Ruta { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
        public string NombreDocumento { get; set; }

        public string Item { get; set; }
        public bool Estatico { get; set; }
    }
    public class RegistrarDirecMunicipalViewModel : FiltrarLotes 
    {
        public string Codigo { get; set; }
        public string CodigoManzanaVia { get; set; }
        public string CodigoManzanaViaAnt { get; set; }
        public string NombreVia { get; set; }
        public string CodigoVia { get; set; }
        public string CodigoViaAnt { get; set; }
        public string NumeroCuadra { get; set; }
        public string NombreLado { get; set; }
        public string CodigoLado { get; set; }
        public string TipoEdificacion { get; set; }
        public string NombreTipoEdificacion { get; set; }
        public string NumTipoEdificacion { get; set; }
        public string CodigoAsignacion { get; set; }
        public string NombreAsignacion { get; set; }
        public string CodigoTipoPuerta { get; set; }
        public string NombreTipoPuerta { get; set; }
        public string NumeroPuerta { get; set; }
        public string LetraPuerta { get; set; }
        public string Estado { get; set; }
        public string Item { get; set; }
        public bool Estatico { get; set; }

        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        public string CodigoVia_Unidad { get; set; }
        public string NumeroMunicipal { get; set; }
        public string ExManzana { get; set; }
        public string ExLote { get; set; }
        public string SubLote { get; set; }
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN

    }
    public class ManzanaMediasViewModel
    {
        public decimal? Retiro { get; set; }
        public decimal? Jardin { get; set; }
    }
    public class RegistrarRetiroMunicipalViewModel : FiltrarLotes
    {
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }
        public string CodigoManzanaVia { get; set; }
        public string NombreVia { get; set; }
        public string CodigoVia { get; set; }
        public string NumeroCuadra { get; set; }
        public string NombreLado { get; set; }
        public string CodigoLado { get; set; }

        public decimal? RetiroOficial { get; set; }
        [Display(Name = "Retiro Campo")]
        public decimal? RetiroCampo { get; set; }

        public decimal? JardinOficial { get; set; }
        [Display(Name = "Jardín Aislam Oficial")]
        public decimal? JardinAislamOfi { get; set; }

        [Display(Name = "Ocupación")]
        public string OcupacionRetiro { get; set; }

        [Display(Name = "Descripción")]
        public string DescripcionRetiro { get; set; }
        [Display(Name = "Ocupación")]
        public string OcupacionJardin { get; set; }
        [Display(Name = "Descripción")]
        public string DescripcionJardin { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        public string Estado { get; set; }
        public string Item { get; set; }
        public bool Estatico { get; set; }

        //CAMBIOS NUEVOS CATASTRO GJLR-INI
        public string CodigoOcupacionRetiro { get; set; }
        public string CodigoOcupacionJardin { get; set; }
        public decimal? AreaPublicaOficial { get; set; }
        public decimal? AreaPublicaCampo { get; set; }
        public string CodigoOcupacionAreaPublica { get; set; }
        public string DescripcionAreaPublica { get; set; }
        public decimal? AnchoViaOficial { get; set; }
        public decimal? AnchoViaCampo { get; set; }
        public string CodigoOcupacionAnchoVia { get; set; }
        public string DescripcionAnchoVia { get; set; }
        //CAMBIOS NUEVOS CATASTRO GJLR-FIN
    }
    public class LoteDocumentosViewModel : FiltrarLotes
    {
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public string Solicitante { get; set; }
        public string Documento { get; set; }
        public string Numero { get; set; }
        public string Codigo { get; set; }
        public string Correlativo { get; set; }
        public string CodSoli { get; set; }
        public string Flag { get; set; }

        public string Estado { get; set; }
        public bool Estatico { get; set; }
    }
    public class LoteOtrosDocumentosViewModel : FiltrarLotes
    {
        public bool Estatico { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Observacion { get; set; }
        public string FechaDocumento { get; set; }
        public string Correlativo { get; set; }
        public string Estado { get; set; }
        public string NroItem { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string Codigo { get; set; }
        public IEnumerable<SelectListItem> ListTipoDocumento{ get; set; }
        public HttpPostedFileBase Archivo { get; set; }

    }
    public class ZonifManzaViewModel : FiltrarLotes
    {
        public string CodigoZonificacion { get; set; }
        public string Descripcion { get; set; }
    }
    public class ZonifLoteViewModel : FiltrarLotes 
    {
        public string Codigo { get; set; }
        public string Correlativo { get; set; }
        public string Estado { get; set; }
        public bool Estatico { get; set; }
    }
    public class LoteObservacionViewModel : FiltrarLotes
    {
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public bool Estatico { get; set; }
    }
    public class ProcedimientoNuevoViewModel
    {
        public int Item { get; set; }


        [Display(Name = "Tipo Procedimiento")]
        public IEnumerable<SelectListItem> ListTipoProcedimiento { get; set; }

        public string CodigoTipoSolicitud { get; set; }
        public string NumeroSolicitud { get; set; }

        public DateTime? FechaRecepcion { get; set; }
        public string EFechaRecepcion { get; set; }
        public string EFechaSolicitud { get; set; }
        public string Asunto { get; set; }

        public bool DatosEncontrados { get; set; }

        public string ResponsableActual { get; set; }

        public string CargoResponsable { get; set; }

        public string EstadoPrevio { get; set; }

        public string NombreEstadoPrevio { get; set; }

        public string SolFechaRecepcion { get; set; }
        public string SolFechaEnvio { get; set; }

        public string ObservacionPrevia { get; set; }

        public string Periodo { get; set; }
        public string CodigoResponsable { get; set; }
        public string Observaciones { get; set; }
        public string CodigoAccion { get; set; }
        public string CodigoActividad { get; set; }
        public int? Folios { get; set; }
        public string CodigoTipoProcedimiento { get; set; }
        public string CodigoTipoRequerimiento { get; set; }
        public string CodigoTipoLlenado { get; set; }
        public string CodigoEstadoAtencion { get; set; }

        public string CodigoCorrelativo { get; set; }

        public string FechaLimite { get; set; }
        public string FechaLimiteInspec { get; set; }
        public string FechaLimiteActual { get; set; }
        public string FechaLimiteInfor { get; set; }
        public string FechaModificacion { get; set; }
        public bool SolicitudSinRecepcionar { get; set; }

    }
    public class RegistrarLoteViewModel
    {
        public string CodigoDepartamento { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string LoteUrbano { get; set; }
        public string SubLoteUrbano { get; set; }
        public string AlturaEdificacion { get; set; }
        public string Denominacion { get; set; }
        public string Cuc { get; set; }
        public bool Estatico { get; set; }
        public string LoteEsquina { get; set; }
        public string TipoLote { get; set; }
        public string UsoPredio { get; set; }
        public string MonumentoHistorico { get; set; }
        public string NumeroResolucion { get; set; }
        public string FechaResolucion { get; set; }

        public decimal? AreaTerrenoCampo { get; set; }
        public decimal? AreaTerrenoOficial { get; set; }
        public string CodigoFuente { get; set; }
        public decimal? AreaConstruidaTotal { get; set; }

        public string SectorCatastral { get; set; }
        public string SectorPlaneamiento { get; set; }
        public string SectorSeguridad { get; set; }
        public string SectorVecinal { get; set; }
        public string SubSectorCatastral { get; set; }
        public string SubSectorPlaneamiento { get; set; }
        public string SubSectorSeguridad { get; set; }
        public string SubSectorVecinal { get; set; }

        public HttpPostedFileBase archivo { get; set; }

    }
    public class SolicitudUnidadViewModel
    {
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string TipoPropietario { get; set; }
        public string CodigoLote { get; set; }
        public string Ed { get; set; }
        public string Entrada { get; set; }
        public string Bloqueado { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }
        public int? CodigoUni { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string Referencia { get; set; }
        public string Titular { get; set; }
        public string Solicitante { get; set; }
        public string Ubicacion { get; set; }
        public string EstadoUnidad { get; set; }
        public string TipoLote { get; set; }
        public string NumeroLote { get; set; }
        public string NumeroLoteNuevo { get; set; }
        public string FlagTrabajo { get; set; }
        public string FlagUsuario { get; set; }
        public string TotalFilas { get; set; }
        public bool Estatico { get; set; }

        public string CodigoCatastral { get; set; }
        public string LoteCodigoCatastral { get; set; }
        public string CodigoLado { get; set; }
        public string FechaDocumento { get; set; }
        public string Observacion { get; set; }
        public string CodigoTramite { get; set; }
        public string CodigoSolicitante { get; set; }
        public string Habilitado { get; set; }
        public string Asunto { get; set; }
    }
    public class RegistrarHabilitacionViewModel
    {
        [Display(Name = "Tipo Habilitación Urbana")]
        public IEnumerable<SelectListItem> ListTipoHabilitacionUrbana { get; set; }
        [Display(Name = "Nombre Habilitación Urbana")]
        public IEnumerable<SelectListItem> ListHabilitacionUrbana { get; set; }
        [Display(Name = "Manzana Urbana")]
        public IEnumerable<SelectListItem> ListManzanaUrbana { get; set; }
        public string CodigoHabilitacionUrbana { get; set; }
        public string CodigoManzanaUrbana { get; set; }
        public string NombreManzanaUrbana { get; set; }

        public string CodigoTipoHabilitacion { get; set; }
        [Display(Name = "Tipo Habilitación Urbana")]
        public string NombreTipoHabilitacion { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }

        public string Estado { get; set; }
        public bool ModalEstatico { get; set; }
        public bool Estatico { get; set; }

        public string NombreHabilitacion { get; set; }
    }
    public class PorcentajeBienComunViewModel
    {
        [Display(Name = "Dist")]
        public string CodigoDistrito { get; set; }
        [Display(Name = "Sec")]
        public string CodigoSector { get; set; }
        [Display(Name = "Mz")]
        public string CodigoManzana { get; set; }
        [Display(Name = "Lote")]
        public string CodigoLote { get; set; }
    }
    public class FiltrarLicenciaViewModel : LicenciaViewModel
    {
        public string CodigoCatastral { get; set; }
    }
    public class LicenciaViewModel: FiltrarLotes
    {
        public string Item { get; set; }
        public string Solicitante { get; set; }
        public string Beneficiario { get; set; }
        public string TipoLicencia { get; set; }
        public string NumeroLicencia { get; set; }
        public string Giros { get; set; }
        public string CodGiro { get; set; }
        public string FechaLicencia { get; set; }
        public string CodigoCatastral { get; set; }
        public string Observaciones { get; set; }
        public string PDF { get; set; }
        public string EstadoLicencia { get; set; }
        public string Codigo { get; set; }
        public bool Estatico { get; set; }
    }
    public class LicenciaEdificacionViewModel : FiltrarLotes
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
        public bool Estatico { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumenro { get; set; }
        public string FechaDocumento { get; set; }
        public string Correlativo { get; set; }
        public string PdfHabilitado { get; set; }
    }
    public class InspeccionesViewModel : FiltrarLotes
    {
        public string Item { get; set; }
        public string FechaInspeccion { get; set; }
        public string CodigoUnidad { get; set; }
        public string InspectorResponsable { get; set; }
        public string Inspectores { get; set; }
        public string Observacion { get; set; }
        public string Codigo { get; set; }
    }
   

}