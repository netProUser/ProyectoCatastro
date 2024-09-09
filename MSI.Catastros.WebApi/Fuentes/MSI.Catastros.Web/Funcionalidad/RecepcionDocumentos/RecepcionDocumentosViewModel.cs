using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos
{
    public class RecepcionDocumentosViewModel
    {
        [Display(Name = "Tipo Solicitud")]
        public IEnumerable<SelectListItem> ListTipoSolicitud { get; set; }

        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }

        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumentoInt { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string NumeroSolicitud { get; set; }

        public string CodigoCorrelativo { get; set; }

        public string CodigoPeriodoSolicitud { get; set; }

        public string CodigoTipoSolicitud { get; set; }
        public string NombreTipoSolicitud { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; }

        public string CodigoTipoDocumentoInt { get; set; }
        public string NombreTipoDocumentoInt { get; set; }
        public string CodigoAreaSolicitante { get; set; }
        public string NombreAreaSolicitante { get; set; }
        public string Asunto { get; set; }
        public int? Folios { get; set; }
        public string FechaRecepcion { get; set; }
        public string FechaSolicitud { get; set; }
        public string PuestoRemitente { get; set; }
        public string PuestoRecepcion { get; set; }
        public string UsuarioRecepcion { get; set; }
        public int Indice { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        public string PrimeraRecepcion { get; set; }
        public string IdRef  { get; set; }

        public string CodigoContribuyente { get; set; }
        public string CodigoRecurrente { get; set; }
        public string Solicitante { get; set; }
        public string TipoDocRec { get; set; }
        public string IdRecurrente { get; set; }
        public string RepresentanteEl { get; set; }
        public string CodTipoDocRec { get; set; }
        public string TipoDocRepl { get; set; }
        public string CodTipoDocRepl { get; set; }
        public string IdRepresentante { get; set; }
        public Nullable<DateTime> FechaIngreso { get; set; }

        public Nullable<DateTime> FecRecepcion { get; set; }
        public Nullable<int> nro { get; set; }

        public string CodigoAccion { get; set; }
        public string CodigoActividad { get; set; }

        public Nullable<DateTime> fecsolicitud  { get; set; }
        public string CorrelativoMaximo { get; set; }

    }

    

    public class FiltrarRecepcionDocumentosViewModel : RecepcionDocumentosViewModel
    {
        public string CodigoTipoSolicitudReg { get; set; }
        public string NombreTipoSolicitudReg { get; set; }
        public string NumeroSolicitudReg { get; set; }
        public string CodigoTipoDocumentoReg { get; set; }
        public string NombreTipoDocumentoReg { get; set; }
        public string AreaSolicitante { get; set; }
        public string EstadoRecepcion { get; set; }
        public string EstadoInicial { get; set; }

        public string Periodo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
    
}