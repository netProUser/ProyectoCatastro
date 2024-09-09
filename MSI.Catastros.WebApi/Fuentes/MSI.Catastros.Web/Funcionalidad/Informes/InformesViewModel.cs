using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Informes
{
    public class InformesViewModel
    {
        [Display(Name = "Tipo de Informe")]
        public IEnumerable<SelectListItem> ListTipoInforme { get; set; }
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public IEnumerable<SelectListItem> ListUnidades { get; set; }
        [Display(Name = "Tipo Destinatario")]
        public IEnumerable<SelectListItem> ListTipoPersona { get; set; }
        public string TipoPersonas { get; set; }
        public string Unidades { get; set; }

        public string FiltrarCodigoInforme { get; set; }
        public string FechaGeneracion { get; set; }
        public string FiltrarCodigoPeriodoInforme { get; set; }   
        public string FiltrarCodigoTipoInforme { get; set; }        
        public string FiltrarCodigoTipoSolicitud { get; set; }
        public string FiltrarCodigoCorrelativo { get; set; }        
        [Display(Name = "Nro. Solicitud")]
        public string FiltrarNumeroSolicitud { get; set; }
        public string FiltrarCodigoPeriodo { get; set; }        
        public string FiltrarCodigoTipoDocumentoReg { get; set; }
        public string NumeroInspeccion { get; set; }
        public string NombreSolicitante { get; set; }
        public string NombreRepresentante { get; set; }
        public string NombreTitular { get; set; }
        public string CodigoDocumentoGenerado { get; set; }
        public string CodigoUsuario { get; set; }
        public bool Estatico { get; set; }

        //Datos Precargados

        #region REPORTE1

        public string CodigoOficina { get; set; }
        [Display(Name = "Sigla")]
        public string NombreSigla { get; set; }
        [Display(Name = "Fecha de Inspección")]
        public string FechaInspeccion { get; set; }
        [Display(Name = "Tipo de Llenado")]
        public string NombreTipoLlenado { get; set; }
        [Display(Name = "Asunto")]
        public string Asunto { get; set; }
        [Display(Name = "Código Catastral")]
        public string CodigoCatastral { get; set; }
        [Display(Name = "Codigo Unico")]
        public string CodigoUnico { get; set; }
        [Display(Name = "Ubicación del Predio")]
        public string UbicacionPredio { get; set; }
        [Display(Name = "Titular Catastral")]
        public string TitularCatastral { get; set; }
        [Display(Name = "Solicitante")]
        public string Solicitante { get; set; }
        [Display(Name = "Oficina")]
        public string NombreOficina { get; set; }
        [Display(Name = "Descripcion Informe")]
        public string DescripcionInforme { get; set; }
        [Display(Name = "Nombre del Año")]
        public string NombreAnio { get; set; }
        [Display(Name = "Nombre en la Firma")]
        public string NombreFirma { get; set; }
        [Display(Name = "Cargo")]
        public string CargoFirma { get; set; }

        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string CodigoEdificacion { get; set; }
        public string CodigoEntrada { get; set; }
        public string CodigoPiso { get; set; }
        public string CodigoUnidad { get; set; }
        public string FechaActual { get; set; }

        public string Documento { get; set; }
        public string Item { get; set; }
        public string Bloqueado { get; set; }

        [Display(Name = "N° Calidad de Verificación A1")]
        public string NroCalidadVerificacion { get; set; }

        #endregion


        [Display(Name = "Version")]
        public IEnumerable<SelectListItem> ListVersionInforme { get; set; }
        public string FiltrarCodigoVersion { get; set; }
        public string Responsable { get; set; }
        public string CodTramite { get; set; }

        public string CodigoCorrelativoTramite { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string TipoPErsonaDeclarante { get; set; }
        public string TipoVerificacion { get; set; }
    }

    public class RegistrarArchivos {
        public string FiltrarCodigoInforme { get; set; }
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

    public class ImagenModel {
        public ImagenInfo data { get; set; }
        public bool success { get; set; }
    }
    public class ImagenInfo {
        public string url { get; set; }
    }

    public class RegistrarInformeDetalle {
        public string CodigoInforme { get; set; }
        public string CodigoPeriodo { get; set; }
        public string CodigoCorrelativo { get; set; }
        public string CodigoSubCorrelativo { get; set; }
        public string CodigoTipoInforme { get; set; }
        public string NombreRuta { get; set; }
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public string SubTitulo { get; set; }
        public string SubDetalle { get; set; }
        public string Usuario { get; set; }
        public string Item { get; set; }

        public string Estado { get; set; }

        public string CodigoTipoDetalle { get; set; }
    }
}