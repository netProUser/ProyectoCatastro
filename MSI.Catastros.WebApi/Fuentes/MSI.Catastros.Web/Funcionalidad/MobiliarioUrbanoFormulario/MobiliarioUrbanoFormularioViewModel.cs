using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.MobiliarioUrbanoFormulario
{
    public class MobiliarioUrbanoFormularioViewModel
    {

        public string codClase { get; set; }
        [Display(Name = "Seleccione Clase")]
        public IEnumerable<SelectListItem> Clase { get; set; }

        public string codSubClase { get; set; }
        [Display(Name = "Seleccione  Sub-Clase")]
        public IEnumerable<SelectListItem> SubClase { get; set; }

        public string codObjeto { get; set; }
        [Display(Name = "Seleccione Objeto")]
        public IEnumerable<SelectListItem> Objeto { get; set; }

        public FormularioDetalleViewModel FormularioSubClase { get; set; }

        public FormularioDetalleViewModel FormularioObjeto { get; set; }
        public MobiliarioUrbanoFormularioViewModel()
        {
            Clase = new List<SelectListItem>();
            SubClase = new List<SelectListItem>();
            Objeto = new List<SelectListItem>();

            FormularioSubClase = new FormularioDetalleViewModel();
            FormularioObjeto = new FormularioDetalleViewModel();

        }
    }
    public class ClaseViewModel
    {
        [Display(Name = "Código")]
        public string CodClase { get; set; }

        [Display(Name = "Clase")]
        public string NombreClase { get; set; }

        public int Estado { get; set; }
    }

    public class SubClaseViewModel
    {
        public string CodClase { get; set; }
        public string NombreClase { get; set; }
        public string CodSubClase { get; set; }

        [Display(Name = "Nombre")]
        public string NombreSubClase { get; set; }
        public int Estado { get; set; }


    }
    public class ObjetoViewModel 
    {
        [Display(Name = "Código")]
        public string CodObjeto { get; set; }
        [Display(Name = "Objeto")]
        public string NombreObjeto { get; set; }
        public string CodClase { get; set; }
        public string CodSubClase { get; set; }
        public int Estado { get; set; }

    }
    public class FormularioDetalleViewModel
    {
        public int Estado { get; set; }

        public string CodClase { get; set; }
        public string CodSubClase { get; set; }
        public string CodObjeto { get; set; }
        public string codigoConfiguracion { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string codTipoCampo { get; set; }
        [Display(Name = "Tipo de Campos")]
        public IEnumerable<SelectListItem> TipoCampo { get; set; }
        [Display(Name = "Tamaño de Campo")]
        public string TamanioCampo { get; set; }
        [Display(Name = "Opciones de Desplegable")]
        public string OpcionDesplegable { get; set; }
        public FormularioDetalleViewModel()
        {
            TipoCampo = new List<SelectListItem>() {
                new SelectListItem() { Value = "TEXTBOX", Text = "TEXT BOX" },
                new SelectListItem() { Value = "COMBOBOX", Text = "COMBO BOX" },
                new SelectListItem() { Value = "CHECKBOX", Text = "CHECK BOX" },
            };
        }
    }
}