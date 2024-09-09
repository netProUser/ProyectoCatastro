using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = MSI.Catastros.BusinessEntities;

namespace MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo
{
    public class FiltrarProcedimientoNuevoViewModel
    {
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        public string FiltrarCodigoTipoSolicitud { get; set; }
        [Display(Name = "Número de Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }
        [Display(Name = "Asunto")]
        public string Asunto { get; set; }

        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }

        public IEnumerable<SelectListItem> ListTipoDocumentoInt { get; set; }
        public string FiltrarCodigoTipoDocumentoReg { get; set; }

        public string EstadoPrevio { get; set; }

        public string NombreEstadoPrevio { get; set; }
        public string ProcedimientoPrevio { get; set; }

        public string SolFechaRecepcion { get; set; }
        public string SolFechaEnvio { get; set; }

        public bool DatosEncontrados { get; set; }

        public string Periodo { get; set; }
        public string CodigoResponsable { get; set; }
        public string Observaciones { get; set; }
        public string CodigoAccion { get; set; }
        public string CodigoActividad { get; set; }
        public int? Folios { get; set; }
        public string CodigoTipoProcedimiento { get; set; }
        public string CodigoTipoRequerimiento { get; set; }
        public string CargoResponsable { get; set; }
        public string CodigoEstadoAtencion { get; set; }

        public FiltrarProcedimientoNuevoViewModel()
        {
        }

        public string FiltrarCodigoPeriodo { get; set; }
    }

    public class SoliInspeActViewModel
    {
        public string CodigoNumeroSolicitud { get; set; }
        public string codigoTipoDocumento { get; set; }

        public string anoSolicitud { get; set; }

        public string codigoTipoSolicitud { get; set; }

        public string codIndDet { get; set; }

        public string codTipoInsp { get; set; }

        public string textoDetalle { get; set; }

        public string textDetTipIns { get; set; }

        public string CodTipInspe { get; set; }

        public string CodCorrSeguimiento { get; set; }
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

        public string CodigoTipoDocumento { get; set; }
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
        public string FechaLimiteProgInspec { get; set; }
        public string FechaLimiteInspec { get; set; }
        public string FechaLimiteActual { get; set; }
        public string FechaLimiteInfor { get; set; }
        public string FechaModificacion { get; set; }
        public bool SolicitudSinRecepcionar { get; set; }
        public string IdRef { get; set; }
        public string TipoLlenado { get; set; }
        public string Requerimiento { get; set; }


        public bool Cerrada { get; set; }
    }

    public class RegistrarArchivos
    {
        public int? FiltrarCodigoUnidad { get; set; }
        public string FiltrarVersion { get; set; }
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

    public class UnidadHistoricaViewModel
    {
        public int? CodigoUnico { get; set; }
        public string Ruta { get; set; }
        public string TipoFicha { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
    }

    public class ProcedimientoInicialViewModel
    {
        [Display(Name = "Tipo Procedimiento")]
        public IEnumerable<SelectListItem> ListTipoProcedimiento { get; set; }

        [Display(Name = "Tipo Requerimiento")]
        public IEnumerable<SelectListItem> ListTipoRequerimiento { get; set; }

        [Display(Name = "Tipo Llenado")]
        public IEnumerable<SelectListItem> ListTipoLlenado { get; set; }

        [Display(Name = "Asignar Responsable")]
        public IEnumerable<SelectListItem> ListAsignarReponsable { get; set; }

        [Display(Name = "Tipo Accion")]
        public IEnumerable<SelectListItem> ListTipoAccion { get; set; }


        [Display(Name = "Tipo Inspeccion Exterior")]
        public IEnumerable<BE.SIC_TIPOPROCINSPACT> ListTipoInspeccionExt { get; set; }

        [Display(Name = "Tipo Inspeccion Interior")]
        public IEnumerable<BE.SIC_TIPOPROCINSPACT> ListTipoInspeccionInt { get; set; }

        [Display(Name = "Tipo Actualizacion Informacion Literal")]
        public IEnumerable<BE.SIC_TIPOPROCINSPACT> ListTipoActualizacionInforLit { get; set; }

        [Display(Name = "Tipo Actualizacion Informacion Grafica")]
        public IEnumerable<BE.SIC_TIPOPROCINSPACT> ListTipoActualizacionInforGraf { get; set; }

        [Display(Name = "Tipo Actualizacion Documentos")]
        public IEnumerable<BE.SIC_TIPOPROCINSPACT> ListTipoActualizacionDocumento { get; set; }




        [Display(Name = "Número de Trámite")]
        public string NumeroTramite { get; set; }

        [Display(Name = "Número de Solicitud")]
        public string NumeroSolicitud { get; set; }

        [Display(Name = "Folio")]
        public int? Folio { get; set; }

        public string anosolicitud { get; set; }

        [Display(Name = "Responsable Previo")]
        public string ResponsablePrevio { get; set; }

        //[Display(Name = "Fecha Limite")]
        //public DateTime? FechaLimite { get; set; }

        [Display(Name = "Fecha Proceso Inspección")]
        public DateTime? FechaProcesoInspeccion { get; set; }

        [Display(Name = "Fecha Proceso Actualización")]
        public DateTime? FechaProcesoActualizacion { get; set; }

        [Display(Name = "Fecha Proceso Final Analista")]
        public DateTime? FechaProcesoFinal { get; set; }

        [Display(Name = "Fecha Remision")]
        public DateTime? FechaRemision { get; set; }

        [Display(Name = "Fecha de Recepción")]
        public DateTime? FechaRecepcion { get; set; }

        [Display(Name = "Acción")]
        public IEnumerable<SelectListItem> ListAccion { get; set; }

        [Display(Name = "Obervacion de Remitente")]
        public string ObservacionRemitente { get; set; }

        [Display(Name = "Observacion de Recepción")]
        public string ObservacionRecepcion { get; set; }

        public string CodigoTipoSolicitud { get; set; }
        public string Asunto { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        public string NombreTipoSolicitud { get; set; }
        public string CodigoTipoDocumento { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string NombreTipoDocumento { get; set; }
        public string CodigoAreaSolicitante { get; set; }

        [Display(Name = "Area Solicitante")]
        public string NombreAreaSolicitante { get; set; }

        [Display(Name = "Estado Solicitud Previo")]
        public string EstadoSolicitudPrevio { get; set; }

        [Display(Name = "Codigo Estado Solicitud Previo")]
        public string CodigoEstadoPrevio { get; set; }

        public string cadfechasolicitud { get; set; }

        public string cadfecharecepcion { get; set; }

        public string cadfechaenvio { get; set; }

        public string CodigoAsignarReponsable { get; set; }

        public string CodigoTipoProcedimiento { get; set; }

        public string CodigoCargoResponsable { get; set; }

        public string CodigoCargoAnterior { get; set; }

        public string CodigoTipoLlenado { get; set; }

        public string PuestoResponsable { get; set; }

        public string CodigoTipoAccion { get; set; }

        public string CodigoTipoRequerimiento { get; set; }

        public string CodigoCorrelativo { get; set; }

        public int Estado { get; set; }

        public DateTime? fechaLimite { get; set; }
        public DateTime? fechaProgIns { get; set; }
        public DateTime? fechaProcIns { get; set; }
        public DateTime? fechaProcAct { get; set; }
        public DateTime? fechaAnalista { get; set; }

    }
    public class FiltrarProcedimientoInicialViewModel
    {
        public string FiltrarCodigoTipoSolicitud { get; set; }
        public string FiltrarNumeroSolicitud { get; set; }

        public string FiltrarCodigoTipoDocumento { get; set; }

        public int Item { get; set; }
        public string CodigoTipoProcedimiento { get; set; }
        public string CodigoTipoRequerimiento { get; set; }
        public string CodigoTipoLlenado { get; set; }
        public string Responsable { get; set; }
        public string FechaLimite { get; set; }
        public string FechaLimiteInspec { get; set; }
        public string FechaLimiteActual { get; set; }
        public string FechaLimiteInfor { get; set; }
        public string FormularioProc { get; set; }
        public string EstadoAtencion { get; set; }
        public string FechaRecepcion { get; set; }
        public string FechaModificacion { get; set; }

        public string FiltrarCodigoPeriodo { get; set; }
    }

    public class FiltrarSolicitudUnidadViewModel
    {
        public string FiltrarCodigoTipoSolicitud { get; set; }
        public string FiltrarNumeroSolicitud { get; set; }
    }
    public class SolicitudUnidadViewModel
    {
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }
        public string CodigoTipoDocumento { get; set; }
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

        public string CodigoTitular { get; set; }
    }


    public class FiltrarRegistroErroresViewModel
    {
        public string FiltrarCodigoTipoSolicitud { get; set; }
        public string FiltrarNumeroSolicitud { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }

        public string FiltrarCodigoCorrelativo { get; set; }
    }
    public class RegistroErroresViewModel
    {
        public int Item { get; set; }
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string CodigoErrorCalidad { get; set; }
        public string CodigoTipoError { get; set; }
        public string NombreTipoError { get; set; }
        public string NombreErrorCalidad { get; set; }
        public string Detalle { get; set; }
        public string NombreSolicitante { get; set; }
        public string CodigoSolicitante { get; set; }
        public string NombreResponsable { get; set; }
        public string NumeroInspecRef { get; set; }

        public string FechaRevision { get; set; }
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
        public string FiltrarTipoBusqueda { get; set; }
        public string FiltrarCodigoVia { get; set; }
        public int FiltrarNumeroCuadra { get; set; }
        public string FiltrarNumeroPuerta { get; set; }
        public string FiltrarEd { get; set; }
        public string FiltrarEntrada { get; set; }
        public string FiltrarPiso { get; set; }
        public string FiltrarUnidad { get; set; }

        public string CodigoCorrelativo { get; set; }
        public string CodigoPeriodo { get; set; }
        public string CodigoNumeroSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }
        public string CodigoVia { get; set; }

        public IEnumerable<SelectListItem> ParametroCuadra { get; set; }
        [Display(Name = "Cuadra")]
        public Nullable<int> NumcuadraReg { get; set; }

        [Display(Name = "Número Puerta")]
        public string NumeroPuerta { get; set; }

        public string hidTipoBusqueda { get; set; }

        public int Estado { get; set; }
    }

    public class UnidadCatastralViewModel
    {
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string  CodigoLote { get; set; }
        public string  Ed { get; set; }
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

    public class FiltrarSolicitarProcedimientoViewModel
    {
        [Display(Name = "Nro Solicitud")]
        public string CodigoNumeroSolicitud { get; set; }

        [Display(Name = "Responsable Actual")]
        public string Responsable { get; set; }

        [Display(Name = "Asunto")]
        public string AsuntoProcedimiento { get; set; }

        [Display(Name = "Estado Atención Previa")]
        public string EstadoAtencionPrevia { get; set; }

        [Display(Name = "Tipo Procedimiento")]
        public IEnumerable<SelectListItem> ListTipoProcedimiento { get; set; }

        [Display(Name = "Tipo Requerimiento")]
        public IEnumerable<SelectListItem> ListTipoRequerimiento { get; set; }

        [Display(Name = "Asignar Responsable")]
        public IEnumerable<SelectListItem> ListAsignarResponsable { get; set; }

        [Display(Name = "Tipo Llenado")]
        public IEnumerable<SelectListItem> ListTipoLlenado { get; set; }
        public string CodigoTipoProcedimiento { get; set; }

        public string CodigoTipoRequerimiento { get; set; }

        public string CodigoAsignarResponsable { get; set; }

        [Display(Name = "Puesto Responsable")]
        public string PuestoResponsable { get; set; }

        public string CodigoTipoLlenado { get; set; }

        [Display(Name = "Fecha Derivación Previa")]
        public string FechaDerivacionPrevia { get; set; }

        [Display(Name = "Fecha Recepción")]
        public string FechaRecepcion { get; set; }

        [Display(Name = "Acción")]
        public IEnumerable<SelectListItem> ListAccion { get; set; }

        public string CodigoAccion { get; set; }

        [Display(Name = "Observación Remitente")]
        public string ObservacionRemitente { get; set; }

        [Display(Name = "Observación Recepción")]
        public string ObservacionRecepcion { get; set; }

        public string ModoApertura { get; set; }
    
    }

    public class InspeccionesViewModel
    {
        public string FiltrarCodigoTipoSolicitud { get; set;}
        public string FiltrarNumeroSolicitud { get; set;}
        public string NumeroInspeccion { get; set; }
        public string NumeroSolicitud { get; set; }
        public string FechaInspeccion { get; set; }
        public string HoraInspeccion { get; set; }
        public string Inspector { get; set; }
        public string Responsable { get; set; }
        public string CodigoCatastral { get; set; }
        public string EstadoInspeccion { get; set; }
        public string Observaciones { get; set; }

        public int Item { get; set; }
        public string NumeroInspeccionSolicitud { get; set; }

        public IEnumerable<CodigoCatastralAsignado> ListunidadCatastral { get; set; }
    }

    public class CodigoCatastralAsignado
    {
        public int Indice { get; set; }
        public string Distrito { get; set; }
        public string Sec { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string Ed { get; set; }
        public string Entr { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }
        public string UbicacionPredio { get; set; }

    }

    public class EstadoActualViewModel 
    {
        public string CodigoCargo { get; set; }
        public string NombreCargo { get; set; }
        public string CodigoEstado { get; set; }
        public string NombreEstado { get; set; }
    }

}