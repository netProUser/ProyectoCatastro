using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.SeguimientoSolicitud
{
    public class FiltrarSeguimientoSolicitudViewModel
    {
        [Display(Name = "Tipo de Búsqueda")]
        public IEnumerable<SelectListItem> TipoBusqueda { get; set; }
        public List<SelectListItem> ListTipoSolicitud { get; set; }
        public Int16 codTipoBusqueda { get; set; }
        

        [Display(Name = "Tipo de Solicitud")]
        public string CodigoTipoSolicitud { get; set; }

        [Display(Name = "Nro. de Solicitud")]
        public string NroSolicitud { get; set; }
        [Display(Name = "Desde")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaInicio { get; set; }
        [Display(Name = "Hasta")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaFin { get; set; }
        [Display(Name = "Asunto")]
        public string Asunto { get; set; }
        [Display(Name = "Titular")]
        public string Titular { get; set; }

        public string UnidadCatastral { get; set; }
        public string FiltrarFechaInicio { get; set; }
        public string FiltrarFechaFin { get; set; }
        public IEnumerable<ReporteSeguimiento> ListadoSeguimiento { get; set; }
        public FiltrarSeguimientoSolicitudViewModel()
        {
            TipoBusqueda = new List<SelectListItem>() { 
                new SelectListItem{ Value="0", Text="Todos"},
                new SelectListItem{ Value="1", Text="Tipo Solicitud"},
                new SelectListItem{ Value="2", Text="Nro. Solicitud"},
                new SelectListItem{ Value="3", Text="Fecha"},
                new SelectListItem{ Value="4", Text="Asunto"},
                new SelectListItem{ Value="5", Text="Titular"}  ,
                new SelectListItem{ Value="6", Text="Unidad Catastral"}
            };

            

            ListadoSeguimiento = new List<ReporteSeguimiento>();
        }
    }
    public class ReporteSeguimiento
    {
        public ReporteSeguimiento()
        {
            //codInspectores = new List<SelectListItem>();
        }


        [Display(Name = "Nro. Solicitud")]
        public string NroSolicitud { get; set; }
        [Display(Name = "Asunto")]
        public string Asunto { get; set; }
        [Display(Name = "Tipo Llenado")]
        public string TipoLlenado { get; set; }
        [Display(Name = "Código Catastral")]
        public string CodCatastral { get; set; }
        [Display(Name = "Titular")]
        public string Titular { get; set; }
        [Display(Name = "Fecha de Recepción Original.")]
        public string FechaRecepOriginal { get; set; }


        [Display(Name = "Fecha Limite")]
        public string FechaLimite { get; set; }

        [Display(Name = "Estado Atención")]
        public string EstadoAtencion { get; set; }
        [Display(Name = "Seguimiento")]
        public IEnumerable<String> Seguimiento { get; set; }

        //[Display(Name = "Inspectores")]
        //public string Inspectores { get; set; }
        //[Display(Name = "Observacón")]
        //public string Observacion { get; set; }
    }
    public class DetalleSeguimientoViewModel
    {
        //datosGenrales
        public string TipoSolicitud { get; set; }
        public string TipoDocumento { get; set; }
        public string AreaSolicitante { get; set; }
        public string FormularioProcedimiento { get; set; }

        //Analista
        public string fechaAntecionAnterior { get; set; }
        public string FechaRecepcion { get; set; }
        public string PuestoResponsable { get; set; }
        public string Responsable { get; set; }
        public string TipoProcedimiento { get; set; }
        public string FechaLimiteInformeAnalista { get; set; }

        //Inspeccion

        public string FechaLimiteInspeccion { get; set; }
        public string NumeroInpesccion { get; set; }

        //Actualizacion

        public string FechaLimiteActualizacion { get; set; }
        public string EstadoSeguimiento { get; set; }

    }

}