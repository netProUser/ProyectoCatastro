using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.MobiliarioUrbano
{
    public class MobiliarioUrbanoViewModel
    {
        #region PrimerGrupo
        public string codDistrito { get; set; }
        public string Distrito { get; set; }
        [Display(Name = "Código Sector")]
        public IEnumerable<SelectListItem> listSector { get; set; }
        public string codSector { get; set; }
        [Display(Name = "Código Manzana")]
        public IEnumerable<SelectListItem> listManzana { get; set; }
        public string codManzana { get; set; }
        [Display(Name = "Código Lote")]
        public IEnumerable<SelectListItem> ListLote { get; set; }
        public string codLote { get; set; }

        [Display(Name = "Código Clase")]
        public IEnumerable<SelectListItem> ListClase { get; set; }
        public string codClase { get; set; }
        [Display(Name = "Código Sub-Clase")]
        public IEnumerable<SelectListItem> ListSubClase { get; set; }
        public string codSubClase { get; set; }

        [Display(Name = "Código Objeto")]
        public IEnumerable<SelectListItem> ListObjeto { get; set; }
        public string codObjeto { get; set; }

        [Display(Name = "Número Unidad")]
        public IEnumerable<SelectListItem> listUnidad { get; set; }
        public string codUnidad { get; set; }
        #endregion

        #region "Componentes"
        //[Display(Name = "Tipo de Componente")]
        //public IEnumerable<SelectListItem> listTipoComponente { get; set; }
        //public string codTipoComponente { get; set; }

        [Display(Name = "Número de Unidad")]
        public string numeroUnidad { get; set; }
        [Display(Name = "Código de Campaña")]
        public string CodigoCampaña { get; set; }
        [Display(Name = "Fecha Campaña")]
        public string fechaCampania { get; set; }
        #endregion

        #region ubicacion
        [Display(Name = "Código de Via")]
        public IEnumerable<SelectListItem> listVia_1 { get; set; }
        public Int32 codVia_1 { get; set; }

        [Display(Name = "Ubicación Específica")]
        public string ubicacionEspecificada { get; set; }
        [Display(Name = "Imagen de Fondo ")]
        public string image { get; set; }
        #endregion

        #region Georeferencia
        //pantalla 1-2-3-4-5-6
        [Display(Name = "Latitud")]
        public string latitud { get; set; }
        [Display(Name = "Longitud")]
        public string longitud { get; set; }
        #endregion
        //#region Observacion
        public Observacion Observacion { get; set; }
        //#endregion

        public MobiliarioUrbanoViewModel()
        {
            listSector = new List<SelectListItem>();
            listManzana = new List<SelectListItem>();
            ListLote = new List<SelectListItem>();
            ListClase = new List<SelectListItem>();
            ListSubClase = new List<SelectListItem>();
            ListObjeto = new List<SelectListItem>();
            listUnidad = new List<SelectListItem>();
            listVia_1 = new List<SelectListItem>();
        }
    }
    public class ComponenteViewModel
    {
        public IEnumerable<SelectListItem> listTipoComponente { get; set; }
        public Int32 codTipoComponente { get; set; }

        public string numeroUnidad { get; set; }
        public string CodigoCampaña { get; set; }
        public string fechaCampania { get; set; }
    }
    public class Observacion
    {
        /*
         * 
         */
        public string codTipoCampo { get; set; }
        public string codigoConfiguracion { get; set; }
        public string Descripcion { get; set; }
        public string OpcionDesplegable { get; set; }

        public string valor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string configuracion { get; set; }
        public string codigo { get; set; }
        public string fecha { get; set; }
        
        public string Detalle { get; set; }
    }
    public class Georeferencia
    {
        public string latitud { get; set; }
        public string longitud { get; set; }
    }

    public class formularioDinamico
    {
        public string CodigoCampa_a { get; set; }
        public string codSector { get; set; }
        public string codManzana { get; set; }
        public string codLote { get; set; }
        public string codClase { get; set; }
        public string codSubClase { get; set; }
        public string codObjeto { get; set; }
        public string codUnidad { get; set; }
        public string numeroUnidad { get; set; }
        //public string CodigoCampa_a { get; set; }
        public string fechaCampania { get; set; }

        public string codVia_1 { get; set; }
        public string ubicacionEspecificada { get; set; }
        public string image { get; set; }

        public string latitud { get; set; }
        public string longitud { get; set; }
        public int Estado { get; set; }
        public IEnumerable<Observacion> Dinamico { get; set; }
        public IEnumerable<Observacion> Detalle { get; set; }
        public formularioDinamico()
        {
            Dinamico = new List<Observacion>();
            Detalle = new List<Observacion>();
        }
    }
}