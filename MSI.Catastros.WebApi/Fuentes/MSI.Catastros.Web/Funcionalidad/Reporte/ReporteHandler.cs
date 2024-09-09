using MSI.Catastros.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Manzana;

namespace MSI.Catastros.Web.Funcionalidad.Reporte
{
    public class ReporteHandler
    {
        public List<SelectListItem> ListadoSector()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            var collection = new BL.SIC_SECTOR().Listar(new BE.SIC_SECTOR()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                TXTSECTOR = ""
            });
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Value = item.CODSECTOR,
                    Text = item.TXTSECTOR

                });
            }
            return result;
        }

        public List<SelectListItem> ParametroManzana(string id)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var collection = new ManzanaHandler().ListarManzanaCombo(id);
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Text = item.NombreManzana,
                    Value = item.CodigoManzana
                });
            }

            return result;
        }

        public List<SelectListItem> ListaReportes()
        {
            var result = new List<SelectListItem>();

            result.Add(new SelectListItem { Value = "001", Text = "Unidades Catastrales por Tipo de Inscripcion" });
            result.Add(new SelectListItem { Value = "002", Text = "Unidades Catastrales por Sector" });
            result.Add(new SelectListItem { Value = "003", Text = "Total de Lotes por Sector" });
            result.Add(new SelectListItem { Value = "004", Text = "Detalle de Lotes por Sector" });
            result.Add(new SelectListItem { Value = "005", Text = "Total de Lotes por Manzana" });
            result.Add(new SelectListItem { Value = "006", Text = "Uso por Unidad Catastral" });
            result.Add(new SelectListItem { Value = "007", Text = "Vias" });
            result.Add(new SelectListItem { Value = "008", Text = "Via Detalle" });
            result.Add(new SelectListItem { Value = "009", Text = "Via Anterior" });
            result.Add(new SelectListItem { Value = "010", Text = "Via Anterior" });
            result.Add(new SelectListItem { Value = "011", Text = "Sectores" });
            result.Add(new SelectListItem { Value = "012", Text = "Manzana" });
            result.Add(new SelectListItem { Value = "013", Text = "Manzana Via" });
            result.Add(new SelectListItem { Value = "014", Text = "Tipo Habilitacion Urbana" });
            result.Add(new SelectListItem { Value = "015", Text = "Habilitacion Urbana" });
            result.Add(new SelectListItem { Value = "016", Text = "ManzanaUrbana" });

            return result;
        }
        public List<SelectListItem> ListadoTipoFiltro()
        {
            //IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().MaterialEstructural();
            var lisDataQuery = new List<SelectListItem>();
            lisDataQuery.Add(new SelectListItem() { Value = "01", Text = "Año" });
            lisDataQuery.Add(new SelectListItem() { Value = "02", Text = "Fecha" });
            return lisDataQuery;
        }
    }
}