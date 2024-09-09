using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = MSI.Catastros.BusinessEntities;

namespace MSI.Catastros.Web.Funcionalidad.ActualizacionEstado
{
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

        public string CodigoCatastral { get; set; }
        public string CodigoUnico { get; set; }
        public string Ubicacion { get; set; }
        public string EstadoUnidad { get; set; }
        public string Referencia { get; set; }
        public string Version { get; set; }
        public string FechaGeneracion { get; set; }
        public string Usuario { get; set; }

        public bool AnularLote { get; set; }
        public bool AnularUnidad { get; set; }
    }

    public class UnidadCatastralViewModel
    {
        public string CodigoDistrito { get; set; }
        public string CodigoSector { get; set; }
        public string CodigoManzana { get; set; }
        public string CodigoLote { get; set; }
        public string Ed { get; set; }
        public string Entrada { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }
        public string Estado { get; set; }
        public string CodigoCatastral { get; set; }
        public string CodigoUnico { get; set; }
        public string Ubicacion { get; set; }
        public string EstadoUnidad { get; set; }
        public string Referencia { get; set; }
        public string Version { get; set; }
        public string FechaGeneracion { get; set; }
        public string Usuario { get; set; }

    }
    
}