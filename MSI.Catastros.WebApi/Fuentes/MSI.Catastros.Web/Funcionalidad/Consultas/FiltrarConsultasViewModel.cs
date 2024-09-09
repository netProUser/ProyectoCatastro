using MSI.Catastros.Web.Funcionalidad.Parametros;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foolproof;

namespace MSI.Catastros.Web.Funcionalidad.Consultas
{
    public class FiltrarConsultasViewModel : PaginacionViewModel
    {
        public string Titulares { get; set; }
        public string Ubicacion { get; set; }
        public string Urbanizacion { get; set; }
        public string CodigoCatastral { get; set; }
        public string CodigoVia { get; set; }
        public IEnumerable<SelectListItem> ListCodigoVia { get; set; }
        public string CodigoTipoHabilitacion { get; set; }
        public IEnumerable<SelectListItem> ListTipoHabilitacion { get; set; }
        public string CodigoHabilitacion { get; set; }
        public IEnumerable<SelectListItem> ListHabilitacion { get; set; }
        public string NombreTitular { get; set; }
        public IEnumerable<SelectListItem> ListNombreTitulares { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public IEnumerable<SelectListItem> ListNumeroDocumento { get; set; }
        public string UsoPredio { get; set; }
        public IEnumerable<SelectListItem> ListUsoPredio { get; set; }
        public string Clasificacion { get; set; }
        public IEnumerable<SelectListItem> ListClasificacion { get; set; }
        public string EstadoConstruccion { get; set; }
        public IEnumerable<SelectListItem> ListEstadoConstruccion { get; set; }
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
        public string Nivel { get; set; }
        public string CodigoUnico { get; set; }

        public bool TablaNull { get; set; }
    }
}