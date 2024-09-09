using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Decoradores
{
    public static class Util
    {
        /// <summary>
        /// Paginador que retornas una seccion aplicada a una grilla
        /// </summary>
        /// <param name="helper">Helper a extender</param>
        /// <param name="cantRegxPag">Nro de Registros por Pagina</param>
        /// <param name="totalVirtual">Total de Paginas</param>
        /// <param name="pagActual">Nro de pagina Actual</param>
        /// <param name="id">id para identificar al paginador</param>
        /// <param name="totalTexto">Texto a mostrar en la seccion de total</param>
        /// <param name="paginaTexto">Texto a mostrar en la seccion de paginado</param>
        /// <returns></returns>
        public static MvcHtmlString MSIPaginador(this HtmlHelper helper, int cantRegxPag, int totalVirtual, int pagActual, string id = "paginacion_grilla", string totalTexto = "", string paginaTexto = "", string paginas = "5,10,20,100")
        {
            var wrapper = new TagBuilder("div");
            //wrapper.Attributes.Add("id", "paginacion_grilla");
            wrapper.AddCssClass("row form-horizontal");

            #region Campos Ocultos

            var inputHidePag = new TagBuilder("input");
            inputHidePag.Attributes.Add("value", pagActual.ToString());
            inputHidePag.Attributes.Add("type", "hidden");
            inputHidePag.Attributes.Add("name", "hdPag_" + id);
            inputHidePag.Attributes.Add("id", "hdPag_" + id);

            wrapper.InnerHtml += inputHidePag.ToString();

            var inputHideTotal = new TagBuilder("input");
            inputHideTotal.Attributes.Add("value", totalVirtual.ToString());
            inputHideTotal.Attributes.Add("type", "hidden");
            inputHideTotal.Attributes.Add("name", "hdTotal_" + id);
            inputHideTotal.Attributes.Add("id", "hdTotal_" + id);

            wrapper.InnerHtml += inputHideTotal.ToString();

            var inputHideRegXPag = new TagBuilder("input");
            inputHideRegXPag.Attributes.Add("value", cantRegxPag.ToString());
            inputHideRegXPag.Attributes.Add("type", "hidden");
            inputHideRegXPag.Attributes.Add("name", "hdRegxPag_" + id);
            inputHideRegXPag.Attributes.Add("id", "hdRegxPag_" + id);

            wrapper.InnerHtml += inputHideRegXPag.ToString();

            #endregion


            #region Grupo Total Registros

            var divNroRegistros = new TagBuilder("div");
            divNroRegistros.AddCssClass("col-md-2");
            var labelRegistros = new TagBuilder("label");
            labelRegistros.AddCssClass("control-label small");
            if (!string.IsNullOrEmpty(totalTexto))
            {
                labelRegistros.InnerHtml = totalTexto;
            }
            else
            {
                labelRegistros.InnerHtml = "Total de Registros: ";
            }


            var strongRegistros = new TagBuilder("strong");
            strongRegistros.InnerHtml = totalVirtual.ToString();
            labelRegistros.InnerHtml += strongRegistros.ToString();

            divNroRegistros.InnerHtml += labelRegistros.ToString();

            wrapper.InnerHtml += divNroRegistros.ToString();
            #endregion

            #region Numero de Paginas

            var divNroPaginas = new TagBuilder("div");
            divNroPaginas.AddCssClass("col-md-4");

            #region Texto Paginador
            var divCol5Paginas = new TagBuilder("div");
            divCol5Paginas.AddCssClass("col-md-5 text-right");
            var divLabel5Paginas = new TagBuilder("label");
            divLabel5Paginas.AddCssClass("control-label small");
            if (!string.IsNullOrEmpty(paginaTexto))
            {
                divLabel5Paginas.InnerHtml = paginaTexto;
            }
            else
            {
                divLabel5Paginas.InnerHtml = "Mostrar de ";
            }

            divCol5Paginas.InnerHtml += divLabel5Paginas.ToString();
            divNroPaginas.InnerHtml += divCol5Paginas.ToString();
            #endregion

            #region Combo paginador
            var divCol7Paginas = new TagBuilder("div");
            divCol7Paginas.AddCssClass("col-md-7");

            var selectPagina = new TagBuilder("select");
            selectPagina.AddCssClass("selectpicker");
            selectPagina.Attributes.Add("data-width", "100%");
            selectPagina.Attributes.Add("id", "select" + id);

            string[] listaPaginas = paginas.Split(',');

            foreach (string item in listaPaginas)
            {
                var opcion = new TagBuilder("option");
                opcion.Attributes.Add("value", item);
                opcion.InnerHtml = item + " en " + item;
                selectPagina.InnerHtml += opcion.ToString();
            }
            /*
            var opcion1 = new TagBuilder("option");
            opcion1.Attributes.Add("value", "5");
            opcion1.InnerHtml = "5 en 5";
            selectPagina.InnerHtml += opcion1.ToString();

            var opcion2 = new TagBuilder("option");
            opcion2.Attributes.Add("value", "10");
            opcion2.InnerHtml = "10 en 10";
            selectPagina.InnerHtml += opcion2.ToString();

            var opcion3 = new TagBuilder("option");
            opcion3.Attributes.Add("value", "20");
            opcion3.InnerHtml = "20 en 20";
            selectPagina.InnerHtml += opcion3.ToString();

            var opcion4 = new TagBuilder("option");
            opcion4.Attributes.Add("value", "50");
            opcion4.InnerHtml = "50 en 50";
            selectPagina.InnerHtml += opcion4.ToString();
            */
            divCol7Paginas.InnerHtml += selectPagina.ToString();

            divNroPaginas.InnerHtml += divCol7Paginas.ToString();

            #endregion


            wrapper.InnerHtml += divNroPaginas.ToString();


            #endregion

            #region Paginado

            var divPaginado = new TagBuilder("div");
            divPaginado.AddCssClass("col-md-6 pagination-conteiner");

            var divPagList = new TagBuilder("div");
            //divPagList.Attributes.Add("class", "paglist");
            divPagList.AddCssClass("paginationMTC");
            divPagList.Attributes.Add("id", id);
            divPagList.Attributes.Add("style", "height: 50px;overflow:hidden;");

            //var divSlider = new TagBuilder("div");
            ////divSlider.Attributes.Add("id", "pagination-slider");
            //divSlider.Attributes.Add("id", id);

            //divPagList.InnerHtml = divSlider.ToString();
            divPaginado.InnerHtml += divPagList.ToString();

            wrapper.InnerHtml += divPaginado.ToString();
            #endregion

            return new MvcHtmlString(wrapper.ToString());
        }
    }
}