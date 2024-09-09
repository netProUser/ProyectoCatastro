using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Masivo
{
    public class MasivoViewModel
    {
        [Display(Name = "Tipo de Solicitud")]
        public IEnumerable<SelectListItem> TipoSolicitud { get; set; }
        public string codTipoSolicitud { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public string CodigoTipoDocumentoReg { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string nroSolicitud { get; set; }
        public string AniSolcitud { get; set; }
        public string Estado { get; set; }

        [Display(Name = "Inscripción Catastral")]
        public IEnumerable<SelectListItem> ListInscripcionCatastral { get; set; }

        public List<ObservacionViewModel> ListObservacionIndi { get; set; }
    }

    public class Configuacion
    {
        public string distrito { get; set; }
        public string sector { get; set; }
        public string manzana { get; set; }
        public string lote { get; set; }
        public List<DetalleConfigracion> configuracion { get; set; }
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CORRELUNIDAD { get; set; }
        public string CODUNI { get; set; }

        

    }
    public class DetalleConfigracion
    {
        public string tipoInscripcion { get; set; }
        public int nroUnidad { get; set; }
        public string edificacion { get; set; }
        public string entrada { get; set; }
        public string piso { get; set; }
    }

    public class ClasificacionUnidadViewModel
    {

        public string CODUNI { get; set; }
        public string CodigoClasificacionPredio { get; set; }
        public IEnumerable<SelectListItem> ListClasificacionPredio { get; set; }
    }

    public class ObservacionIndividual
    {
        public string CodigoUnidadCatastral { get; set; }
        public string Fecha { get; set; }
        public string TipoObservacion { get; set; }
        public string Observacion { get; set; }
        public string CodigoCorrelativo { get; set; }
    }

    public class AreaTerreno
    {
        [Display(Name = "Area Ocupada (m2)")]
        public string areaOcupada { get; set; }
        //[Display(Name = "Area Común Oficial (%)")]
        [Display(Name = "% Oficial")]
        public string areaComun { get; set; }
        public string CodTipoDepartamento { get; set; }
        [Display(Name = "Tipo Departamento/Oficina")]
        public IEnumerable<SelectListItem> ListTipoDepartamento { get; set; }
        public string CodUsoPredio { get; set; }
        [Display(Name = "Código Uso Predio CIIU")]
        public IEnumerable<SelectListItem> ListUsoPredio { get; set; }
        public AreaTerreno()
        {
            ListTipoDepartamento = new List<SelectListItem>();
            ListUsoPredio = new List<SelectListItem>();
        }
    }
}