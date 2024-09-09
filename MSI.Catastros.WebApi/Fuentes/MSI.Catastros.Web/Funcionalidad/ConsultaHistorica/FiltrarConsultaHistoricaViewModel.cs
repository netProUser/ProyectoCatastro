using MSI.Catastros.Web.Funcionalidad.Parametros;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foolproof;

namespace MSI.Catastros.Web.Funcionalidad.ConsultaHistorica
{
    public class FiltrarConsultaHistoricaViewModel : PaginacionViewModel
    {
        public Int32 Nro { get; set; }
        public string Version { get; set; }
        public string FechaGen { get; set; }
        public string Documento { get; set; }
        public string RutaDocu { get; set; }
        public string CODTIPODOC { get; set; }
        public DateTime FECHAINI { get; set; }
        public DateTime FECHAFIN { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public IEnumerable<SelectListItem> ListNumeroDocumento { get; set; }
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
        public string CodigoUnico { get; set; }
    }
}