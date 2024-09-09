using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.PrimeraAsignacion
{
    public class PrimeraAsignacionViewModel
    {
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }


        [Display(Name = "Tipo Procedimiento")]
        public IEnumerable<SelectListItem> ListTipoProcedimiento { get; set; }

        [Display(Name = "Acción")]
        public IEnumerable<SelectListItem> ListAccion { get; set; }

        [Display(Name = "Asignar a Responsable")]
        public IEnumerable<SelectListItem> ListAsignarResponsable { get; set; }

        public IEnumerable<SelectListItem> ListActividad { get; set; }

        [Display(Name = "Actividad")]
        public string CodigoActividad { get; set; }

        public string CodigoTipoSolicitud { get; set; }

        [Display(Name = "Tipo Procedimiento")]
        [Required]
        public string CodigoTipoProcedimiento { get; set; }

        [Display(Name = "Acción")]
        [Required]
        public string CodigoAccion { get; set; }

        [Display(Name = "Asignar a Responsable")]
        [Required]
        public string CodigoResponsable { get; set; }

        [Display(Name = "Número de Solicitud")]
        public string NumeroSolicitud { get; set; }

        [Display(Name = "Folios")]
        public int? Folio { get; set; }

        [Display(Name = "Puesto Responsable")]
        public string PuestoResponsable { get; set; }

        public string NombreTipoSolicitud { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string CodigoTD { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string NombreTipoDocumento { get; set; }
        public string CodigoAreaSolicitante { get; set; }

        [Display(Name = "Area Solicitante")]
        public string NombreAreaSolicitante { get; set; }

        [Display(Name = "Fecha de Recepción")]
        public DateTime? FechaRecepcion { get; set; }


        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        public string Periodo { get; set; }
        public string Correlativo { get; set; }


        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        public string IdRef { get; set; }



        //public FilterPrimeraAsignacionViewModel()
        //{
        //    //ListTipoSolicitud = new List<SelectListItem>() {
        //    //    new SelectListItem { Value = "", Text="Seleccione" , Selected= true },
        //    //    new SelectListItem { Value = "1", Text="Externo" , Selected= true },
        //    //    new SelectListItem { Value = "2", Text="Interno" , Selected= true }
        //    //};
        //    //ListOficio = new List<SelectListItem>() {
        //    //    new SelectListItem { Value = "", Text="Seleccione" , Selected= true },
        //    //    new SelectListItem { Value = "0", Text="NO" , Selected= true },
        //    //    new SelectListItem { Value = "1", Text="SI" , Selected= true }
        //    //};
        //}
    }

    public class FiltrarPrimeraAsignacionViewModel
    {
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }
        public string CodigoTipoSolicitud { get; set; }

        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public string CodigoTipoDocumentoReg { get; set; }

        [Display(Name = "Número de Solicitud")]
        public string NumeroSolicitud { get; set; }


        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
    }

}