using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Parametros
{
    public class ParametrosHandler
    {
        public List<ParametrosViewModel> ListarParametros(string parametros)
        {
            //ACA SE VA A CONSUMIR LOS SERVICIOS REST
            var dataPrueba = new List<ParametrosViewModel>();
            dataPrueba.Add(new ParametrosViewModel
            {
                Abreviatura = "LIMA",
                CodigoParametro = "001",
                Descripcion = "LIMA"
            });
            dataPrueba.Add(new ParametrosViewModel
            {
                Abreviatura = "SAN ISIDRO",
                CodigoParametro = "002",
                Descripcion = "SAN ISIDRO"
            });
            dataPrueba.Add(new ParametrosViewModel
            {
                Abreviatura = "VILLA EL SALVADOR",
                CodigoParametro = "003",
                Descripcion = "VILLA EL SANVADOR"
            });

            return dataPrueba;
        }

        public List<ParametrosViewModel> ListarParametosAnchoVia()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().AnchoVia();
            var lisDataQuery = new List<ParametrosViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ParametrosViewModel
                {
                    CodigoParametro = item.CODPARAMETRO,
                    Descripcion = item.TXTDESCRIPCION
                });
            }

            return lisDataQuery;
        }
        public List<SelectListItem> ListadoCuadrasVias()
        {
            var lisDataQuery = new List<SelectListItem>();
            lisDataQuery.Add(new SelectListItem() { Value = "0", Text = "0" });
            lisDataQuery.Add(new SelectListItem() { Value = "1", Text = "1" });
            lisDataQuery.Add(new SelectListItem() { Value = "2", Text = "2" });
            lisDataQuery.Add(new SelectListItem() { Value = "3", Text = "3" });
            lisDataQuery.Add(new SelectListItem() { Value = "4", Text = "4" });
            lisDataQuery.Add(new SelectListItem() { Value = "5", Text = "5" });
            lisDataQuery.Add(new SelectListItem() { Value = "6", Text = "6" });
            lisDataQuery.Add(new SelectListItem() { Value = "7", Text = "7" });
            lisDataQuery.Add(new SelectListItem() { Value = "8", Text = "8" });
            lisDataQuery.Add(new SelectListItem() { Value = "9", Text = "9" });
            lisDataQuery.Add(new SelectListItem() { Value = "10", Text = "10" });
            lisDataQuery.Add(new SelectListItem() { Value = "11", Text = "11" });
            lisDataQuery.Add(new SelectListItem() { Value = "12", Text = "12" });
            lisDataQuery.Add(new SelectListItem() { Value = "13", Text = "13" });
            lisDataQuery.Add(new SelectListItem() { Value = "14", Text = "14" });
            lisDataQuery.Add(new SelectListItem() { Value = "15", Text = "15" });
            lisDataQuery.Add(new SelectListItem() { Value = "16", Text = "16" });
            lisDataQuery.Add(new SelectListItem() { Value = "17", Text = "17" });
            lisDataQuery.Add(new SelectListItem() { Value = "18", Text = "18" });
            lisDataQuery.Add(new SelectListItem() { Value = "19", Text = "19" });
            lisDataQuery.Add(new SelectListItem() { Value = "20", Text = "20" });
            lisDataQuery.Add(new SelectListItem() { Value = "21", Text = "21" });
            lisDataQuery.Add(new SelectListItem() { Value = "22", Text = "22" });
            lisDataQuery.Add(new SelectListItem() { Value = "23", Text = "23" });
            lisDataQuery.Add(new SelectListItem() { Value = "24", Text = "24" });
            lisDataQuery.Add(new SelectListItem() { Value = "25", Text = "25" });
            lisDataQuery.Add(new SelectListItem() { Value = "26", Text = "26" });
            lisDataQuery.Add(new SelectListItem() { Value = "27", Text = "27" });
            lisDataQuery.Add(new SelectListItem() { Value = "28", Text = "28" });
            lisDataQuery.Add(new SelectListItem() { Value = "29", Text = "29" });
            return lisDataQuery;
        }

    }
}