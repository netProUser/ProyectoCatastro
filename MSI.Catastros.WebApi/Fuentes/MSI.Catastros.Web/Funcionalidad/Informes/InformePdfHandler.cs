using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using System.Text;
//using IronPdf;
using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MSI.Catastros.Web.Funcionalidad.Informes
{
    public class InformePdfHandler
    {
        public Byte[] VerificacionPdfSharpConvert(string CodigoTipoInforme, string NumeroInforme, string CorrelativoInforme, string CodigoAnioInforme)
        {
            Byte[] res = null;
            Byte[] pdfBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                InformesViewModel Informe = ObtenerDatosInforme(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);
                String strHtmlTotal = string.Empty; ;
                String strCabecera = "";
                String strCuerpo = string.Empty;
                strCabecera = strCabecera + "<META http-equiv=\'Content-Type\' content=\'text/html; charset=utf-8\'>";//publica
                strCabecera = strCabecera +  "<style>" +
                                "table, tr, th, td {" +
                                    "border: 1px solid black;" +
                                    "border-collapse: collapse;" +
                                    "text-align: center;" +
                                    "font-family: Tahoma;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                "table {" +
                                    "page-break-inside: avoid;" +
                                "}" +
                                "th {" +
                                    "padding-top: 5px;" +
                                    "padding-bottom: 5px;" +
                                    "font-weight: bold;" +
                                "}" +
                                "td {" +
                                    "padding-top: 5px;" +
                                    "padding-bottom: 5px;" +
                                    "page-break-inside: avoid;" +
                                "}" +
                                ".tablaizq {" +
                                    "text-align: left;" +
                                    "padding-left: 10px" +
                                "}"+
                                "p {" +
                                    "font-family: Tahoma;" +
                                    "margin-top: 0px;" +
                                    "padding-top: 0px;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                "text {" +
                                    "font-family: Tahoma;" +
                                    "margin-top: 5px;" +
                                    "padding-top: 5px;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                "li {" +
                                    "font-family: Tahoma;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                "</style>";

                strCabecera = strCabecera + "<div style='padding-left: 80px; padding-right: 80px'>";
                strCabecera = strCabecera + "<img src='" + System.Web.Hosting.HostingEnvironment.MapPath("~/assets/Images/logo-rep-msi.jpg") + "' border='0' alt='Este es el ejemplo de un texto alternativo' width='200' height='100'>";
                strCabecera = strCabecera + "<text style='float: right; font-weight:bold;'> F-SC-04 <br> Ver. 04 </text>";
                strCabecera = strCabecera + "<h2 style='font-family: Tahoma; font-size:20px; text-align: center'>" + (Informe.NombreOficina == null ? "" : Informe.NombreOficina.ToUpper()) + "</h2>";
                strCabecera = strCabecera + "<h2 style='font-family: Tahoma; font-size:20px; text-align: center'>" + (Informe.DescripcionInforme == null ? "" : Informe.DescripcionInforme.ToUpper()) + " N° " + 
                                                                                                                     (Informe.CodTramite == null ? Informe.FiltrarCodigoCorrelativo : Informe.CodTramite) +
                                                                                                                     (Informe.CodTramite == null ? " - " + Informe.FiltrarCodigoPeriodo + " - " + ((Informe.CodigoOficina != null) ? Informe.CodigoOficina.Replace(".", ""): "") : "") + "</h2><br><br>";

                //var tipoDoc = (Informe.FiltrarCodigoTipoSolicitud == '010002') ? ''
                strCabecera = strCabecera + "<table width='100%' cellspacing='0' cellpadding='0'>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<th width='40%'>CÓDIGO DE REFERENCIA <br> CATASTRAL";
                strCabecera = strCabecera + "</th>";
                strCabecera = strCabecera + "<th width='30%'>"+Informe.CodigoTipoDocumento;
                strCabecera = strCabecera + "</th>";
                strCabecera = strCabecera + "<th width='30%'>"+Informe.TipoVerificacion;
                strCabecera = strCabecera + "</th>";
                strCabecera = strCabecera + "</tr>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td>" + Informe.CodigoCatastral.Replace("|", "<br>");
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td>" + Informe.FiltrarNumeroSolicitud;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td>" + Informe.NumeroInspeccion;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";
                strCabecera = strCabecera + "</table><br />";
                strCabecera = strCabecera + "<table width='100%' cellspacing='0' cellpadding='0'>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='tablaizq'><b>UBICACION: </b> <br>" + Informe.UbicacionPredio.Replace("|", "<br>");
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='tablaizq'><b>" + Informe.TipoPErsonaDeclarante +" </b> <br>" + Informe.Solicitante.Replace("|", "<br>");
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='tablaizq'><b>FECHA DE INSPECCIÓN: </b>" + Informe.FechaInspeccion;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='tablaizq'><b>TIPO DE LLENADO: </b>" + Informe.NombreTipoLlenado;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";
                strCabecera = strCabecera + "</table><br />";
                strCabecera = strCabecera + "</div>";

                List<RegistrarInformeDetalle> ListaDetalleInforme =  ObtenerListaInformeDetalle(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);
                strCuerpo = strCuerpo + "<div style='padding-left: 60px; padding-right: 80px'>";
                strCuerpo = strCuerpo + "<ol>";
                foreach (RegistrarInformeDetalle DetalleInforme in ListaDetalleInforme)
                {
                    string DetalleTitulo = (DetalleInforme.Titulo == null) ? "" : DetalleInforme.Titulo.ToUpper();
                    strCuerpo = strCuerpo + "<li style='font-family: Tahoma; font-size:16px; font-weight: bold;'>" +
                        "<h2 style='font-family: Tahoma; font-size:16px; font-weight: bold; text-align: left'>" + DetalleTitulo + "</h2></li>";
                    if (DetalleInforme.Detalle != null) {
                        //strCuerpo = strCuerpo + DetalleInforme.Detalle;
                        string contexto = (System.Web.HttpContext.Current.Request.ApplicationPath != "/") ? System.Web.HttpContext.Current.Request.ApplicationPath : "";
                        string oldVal = "src=\"" + contexto + "/Informes/CargarImagenes/";
                        string newVal = "src=\"" + "file:///" + @ConfigurationManager.AppSettings["RUTA_FILSERVER"] + "\\DOCUMENTOS\\INFORMES\\IMAGENES\\";
                        strCuerpo = strCuerpo + DetalleInforme.Detalle.Replace(oldVal, newVal).Replace("/JPG", ".jpg").Replace("/PNG", ".png").Replace("/jpg", ".jpg").Replace("/png", ".png") + "";
                    }
                    
                    
                }
                strCuerpo = strCuerpo + "</ol>";
                strCuerpo = strCuerpo + "</div>";

                strCuerpo = strCuerpo + "<br><div style='padding-left: 80px; padding-right: 80px'>";
                strCuerpo = strCuerpo + "<text style='font-weight:bold;'>TÉCNICO RESPONSABLE: </text><br>";
                strCuerpo = strCuerpo + "<text>" + Informe.Responsable + "</text><br><br>";
                strCuerpo = strCuerpo + "<text style='font-weight:bold;'>FECHA: </text><text>" + Informe.FechaActual.Replace(".","/") + "</text><br>";
                strCuerpo = strCuerpo + "</div>";

                strHtmlTotal = strCabecera + strCuerpo;
                res = ms.ToArray();
                var htmlContent = strHtmlTotal;
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.PageHeaderHtml = "<div style = 'text-align: right; padding-top: 60px;'> " +
                                           
                                           "</ div>";
                htmlToPdf.PageFooterHtml = "<div style = 'text-align: left; padding-top: 60px;'><hr></hr> " +
                                            "<text style='font-family: Tahoma; font-size:12px; text-align: left'><i>" + (Informe.DescripcionInforme == null ? "" : Informe.DescripcionInforme.ToUpper()) + " N° " +
                                                                                                                     (Informe.CodTramite == null ? Informe.FiltrarCodigoCorrelativo : Informe.CodTramite) +
                                                                                                                     (Informe.CodTramite == null ? " - " + Informe.FiltrarCodigoPeriodo + " - " + Informe.CodigoOficina.Replace(".", "") : "") + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                                            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                                            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                                             @"Pág. <span  class=""page""></span> / <span class=""topage""></span>" + "</i></text>" +
                                           "</ div>";
                pdfBytes = htmlToPdf.GeneratePdf(htmlContent);

            }
            return pdfBytes;
        }


        public Byte[] TecnicoPdfSharpConvert(string CodigoTipoInforme, string NumeroInforme, string CorrelativoInforme, string CodigoAnioInforme)
        {

            Byte[] res = null;
            Byte[] pdfBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                InformesViewModel Informe = ObtenerDatosInforme(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);


                String strHtmlTotal = string.Empty; ;
                String strCabecera = "";
                String strCuerpo = string.Empty;
                strCabecera = strCabecera + "<META http-equiv=\'Content-Type\' content=\'text/html; charset=utf-8\'>";
                strCabecera = strCabecera + "<style>" +
                                "table, tr, th, td {" +
                                    //"border: 1px solid black;" +
                                    "border-collapse: collapse;" +
                                    "text-align: center;" +
                                    "font-family: Tahoma;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                "table {" +
                                    "page-break-inside: avoid;" +
                                "}" +
                                "th {" +
                                    "padding-top: 5px;" +
                                    "padding-bottom: 5px;" +
                                    "font-weight: bold;" +
                                "}" +
                                "td {" +
                                    "padding-top: 5px;" +
                                    "vertical-align: top;" +
                                    "padding-bottom: 5px;" +
                                    "page-break-inside: avoid;" +
                                "}" +
                                ".tablaizq {" +
                                    "text-align: left;" +
                                    "padding-left: 10px" +
                                "}" +
                                "p {" +
                                    "font-family: Tahoma;" +
                                    "margin-top: 0px;" +
                                    "padding-top: 0px;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                "li {" +
                                    "font-family: Tahoma;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                ".CabTecLeft{" +
                                    "text-align: left;" +
                                    "font-weight: bold;" +
                                "}" +
                                ".CabTecRight{" +
                                    "text-align: left;" +
                                "}" +

                                "</style>";

                strCabecera = strCabecera + "<div style='padding-left: 60px; padding-right: 80px; padding-top: 0px; '><br>";
                //strCabecera = strCabecera + "<img src='C:/Archivos/logo-rep-msi.jpg' border='0' alt='Este es el ejemplo de un texto alternativo' width='200' height='100'>";
                //strCabecera = strCabecera + "<h2 style='font-family: Tahoma; font-size:16px; text-align: center'>" + Informe.NombreOficina.ToUpper() + "</h2>";
                strCabecera = strCabecera + "<h2 style='font-family: Tahoma; font-size:16px; text-align: center'>" + (Informe.DescripcionInforme == null ? "" : Informe.DescripcionInforme.ToUpper()) + " N° " +
                                                                                                                     (Informe.CodTramite == null ? Informe.FiltrarCodigoCorrelativo : Informe.CodTramite) +
                                                                                                                     (Informe.CodTramite == null ? " - " + Informe.FiltrarCodigoPeriodo + " - " + Informe.CodigoOficina.Replace(".", "") : "") + "</h2>";
                strCabecera = strCabecera + "<table width='100%' style='vertical-align: text-top;'>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td width='20%' class='CabTecLeft'>EXPEDIENTES";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td width='5%' class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td width='75%' class='CabTecRight'>" + Informe.FiltrarNumeroSolicitud;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>SOLICITANTE";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + Informe.Solicitante.Replace("|", "<br>");
                strCabecera = strCabecera + "</td>" ;
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>UBICACION";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + Informe.UbicacionPredio.Replace("|", "<br>");
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>ASUNTO";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + Informe.Asunto;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr style='border-bottom: 1px solid black;'>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>FECHA";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + Informe.FechaActual;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "</table><br />";
                
                strCabecera = strCabecera + "</div>";


                List<RegistrarInformeDetalle> ListaDetalleInforme = ObtenerListaInformeDetalle(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);

                strCuerpo = strCuerpo + "<div style='padding-left: 60px; padding-right: 80px'><br><br>";

                strCuerpo = strCuerpo + "<p>Por medio del presente, en atención al Expediente de la referencia se cumple con informar lo siguiente:</p>";

                strCuerpo = strCuerpo + "<ol>";
                foreach (RegistrarInformeDetalle DetalleInforme in ListaDetalleInforme)
                {
                    strCuerpo = strCuerpo + "<li style='font-family: Tahoma; font-size:16px;'>" +
                        DetalleInforme.Detalle + "</li>";
                    //strCuerpo = strCuerpo + DetalleInforme.Detalle + "";

                }
                strCuerpo = strCuerpo + "</ol><br><br>";

                strCuerpo = strCuerpo + "<p>Atentamente;</p><br><br><br><br>";
                strCuerpo = strCuerpo + "<p>" + Informe.CargoFirma + ": " + Informe.NombreFirma.Substring(0, Informe.NombreFirma.IndexOf('-')) + "</p>";
                //strCuerpo = strCuerpo + "<p>" + Informe.NombreOficina +  "</p>";
                strCuerpo = strCuerpo + "<p>Sub Gerencia de Catastro</p>";

                strCuerpo = strCuerpo + "</div>";



                strHtmlTotal = strCabecera + strCuerpo;

                

                var htmlContent = strHtmlTotal;
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                //htmlToPdf.
                htmlToPdf.PageHeaderHtml = "<div style = 'text-align: center; padding-top: 10px; padding-bottom: 30px;'>" +
                                           " <img src='" + System.Web.Hosting.HostingEnvironment.MapPath("~/assets/Images/logo-rep-msi.jpg") + "' border='0' alt='Este es el ejemplo de un texto alternativo' width='200' height='80'><br>" +
                                           "<h2 style='font-family: Tahoma; font-size:12px;'>" + Informe.NombreAnio + "</h2>" +
                                           "</div>";
                htmlToPdf.PageFooterHtml = "<div style = 'text-align: right; padding-top: 80px;'>  </ div>";
                pdfBytes = htmlToPdf.GeneratePdf(htmlContent);


            }//assets/Images/logo-rep-msi.jpg
            return pdfBytes;
//D:\MSI_SISTEMAS_INTEGRADO\MSI.Catastros.WebApi\MSI.Catastros.Web\assets\Images\logo-rep-msi.jpg
        }

        public Byte[] NumeracionPdfSharpConvert(string CodigoTipoInforme, string NumeroInforme, string CorrelativoInforme, string CodigoAnioInforme)
        {

            Byte[] res = null;
            Byte[] pdfBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                InformesViewModel Informe = ObtenerDatosInforme(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);


                String strHtmlTotal = string.Empty; ;
                String strCabecera = "";
                String strCuerpo = string.Empty;
                strCabecera = strCabecera + "<META http-equiv=\'Content-Type\' content=\'text/html; charset=utf-8\'>";
                strCabecera = strCabecera + "<style>" +
                                "table, tr, th, td {" +
                    //"border: 1px solid black;" +
                                    "border-collapse: collapse;" +
                                    "text-align: center;" +
                                    "font-family: Tahoma;" +
                                    "font-size:16px;" +
                                    "color:black;" +
                                "}" +
                                "table {" +
                                    "page-break-inside: avoid;" +
                                "}" +
                                "th {" +
                                    "padding-top: 5px;" +
                                    "padding-bottom: 5px;" +
                                    "font-weight: bold;" +
                                "}" +
                                "td {" +
                                    "padding-top: 5px;" +
                                    "vertical-align: top;" +
                                    "padding-bottom: 5px;" +
                                    "page-break-inside: avoid;" +
                                "}" +
                                ".tablaizq {" +
                                    "text-align: left;" +
                                    "padding-left: 10px" +
                                "}" +
                                "p {" +
                                    "font-family: Tahoma !important;" +
                                    "margin-top: 0px;" +
                                    "padding-top: 0px;" +
                                    "font-size:16px !important;" +
                                    "color:black;" +
                                "}" +
                                "span {" +
                                    "font-family: Tahoma !important;" +
                                    "font-size:16px !important;" +
                                "}" +
                                "text {" +
                                    "font-family: Tahoma !important;" +
                                    "font-size:16px !important;" +
                                "}" +
                                "li {" +
                                    "font-family: Tahoma !important;" +
                                    "font-size:16px !important;" +
                                    "color:black;" +
                                "}" +
                                ".CabTecLeft{" +
                                    "text-align: left;" +
                                    "font-weight: bold;" +
                                "}" +
                                ".CabTecRight{" +
                                    "text-align: left;" +
                                "}" +

                                "</style>";

                strCabecera = strCabecera + "<div style='padding-left: 60px; padding-right: 80px; padding-top: 0px; '><br>";
                //strCabecera = strCabecera + "<img src='C:/Archivos/logo-rep-msi.jpg' border='0' alt='Este es el ejemplo de un texto alternativo' width='200' height='100'>";
                //strCabecera = strCabecera + "<h2 style='font-family: Tahoma; font-size:16px; text-align: center'>" + Informe.NombreOficina.ToUpper() + "</h2>";
                strCabecera = strCabecera + "<h2 style='font-family: Tahoma; font-size:16px; text-align: center'>" + (Informe.DescripcionInforme == null ? "" : Informe.DescripcionInforme.ToUpper()) + " N° " +
                                                                                                                     (Informe.CodTramite == null ? Informe.FiltrarCodigoCorrelativo : Informe.CodTramite) +
                                                                                                                     (Informe.CodTramite == null ? " - " + Informe.FiltrarCodigoPeriodo + " - " + Informe.CodigoOficina.Replace(".", "") : "") + "</h2>";
                strCabecera = strCabecera + "<table width='100%' style='vertical-align: text-top;'>";
                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td width='20%' class='CabTecLeft'>EXPEDIENTES";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td width='5%' class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td width='75%' class='CabTecRight'>" + Informe.FiltrarNumeroSolicitud;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>SOLICITANTE";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + ((Informe.Solicitante != null) ? Informe.Solicitante.Replace("|", "<br>") : "");
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>UBICACION";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + Informe.UbicacionPredio.Replace("|", "<br>");
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>ASUNTO";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + Informe.Asunto;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "<tr style='border-bottom: 1px solid black;'>";
                strCabecera = strCabecera + "<td class='CabTecLeft'>FECHA";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecLeft'> :";
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "<td class='CabTecRight'>" + Informe.FechaActual;
                strCabecera = strCabecera + "</td>";
                strCabecera = strCabecera + "</tr>";

                strCabecera = strCabecera + "</table><br />";

                strCabecera = strCabecera + "</div>";


                List<RegistrarInformeDetalle> ListaDetalleInforme = ObtenerListaInformeDetalle(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);

                strCuerpo = strCuerpo + "<div style='padding-left: 60px; padding-right: 80px'>";

                //strCuerpo = strCuerpo + "<ol>";
                foreach (RegistrarInformeDetalle DetalleInforme in ListaDetalleInforme)
                {
                    string DetalleTitulo = (DetalleInforme.Titulo == null) ? "" : DetalleInforme.Titulo.ToUpper();
                    strCuerpo = strCuerpo + "<h2 style='font-family: Tahoma; font-size:16px; font-weight: bold; text-align: left'>" + DetalleTitulo + "</h2>";
                    //strCuerpo = strCuerpo + DetalleInforme.Detalle + "";
                    if (DetalleInforme.Detalle != null)
                    {
                        //strCuerpo = strCuerpo + DetalleInforme.Detalle;
                        string contexto = (System.Web.HttpContext.Current.Request.ApplicationPath != "/") ? System.Web.HttpContext.Current.Request.ApplicationPath : "";
                        string oldVal = "src=\"" + contexto + "/Informes/CargarImagenes/";
                        string newVal = "src=\"" + "file:///" + @ConfigurationManager.AppSettings["RUTA_FILSERVER"] + "\\DOCUMENTOS\\INFORMES\\IMAGENES\\";
                        strCuerpo = strCuerpo + DetalleInforme.Detalle.Replace(oldVal, newVal).Replace("/JPG", ".jpg").Replace("/PNG", ".png").Replace("/jpg", ".jpg").Replace("/png", ".png") + "";
                    }

                }
                //strCuerpo = strCuerpo + "<br><br><br>";
                //strCuerpo = strCuerpo + "</ol>";

                strCuerpo = strCuerpo + "<p>Atentamente.</p><br><br><br>";
                strCuerpo = strCuerpo + "<text style='border-top: 1px solid black;'>" + Informe.NombreFirma.Substring(0, Informe.NombreFirma.IndexOf('-')) + "</text><br>";
                strCuerpo = strCuerpo + "<text>" + Informe.CargoFirma + "</text><br>";
                strCuerpo = strCuerpo + "<text>" + Informe.NombreOficina + "</text><br>";

                strCuerpo = strCuerpo + "</div>";



                strHtmlTotal = strCabecera + strCuerpo;



                var htmlContent = strHtmlTotal;
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.PageHeaderHtml = "<div style = 'text-align: center; padding-top: 10px; padding-bottom: 30px;'>" +
                                           " <img src='" + System.Web.Hosting.HostingEnvironment.MapPath("~/assets/Images/logo-rep-msi.jpg") + "' border='0' alt='Este es el ejemplo de un texto alternativo' width='200' height='80'><br>" +
                                           "<h2 style='font-family: Tahoma; font-size:12px;'>" + Informe.NombreAnio + "</h2>" +
                                           "</div>";
                htmlToPdf.PageFooterHtml = "<div style = 'text-align: right; padding-top: 80px;'>  </ div>";
                pdfBytes = htmlToPdf.GeneratePdf(htmlContent);


            }
            return pdfBytes;

        }

        public InformesViewModel ObtenerDatosInforme(string CodigoTipoInforme, string NumeroInforme, string CorrelativoInforme, string CodigoAnioInforme)
        {
            BE.SIC_INFORME entQuery = new BE.SIC_INFORME()
            {
                CODTIPOINFOR = CodigoTipoInforme,
                CODCORRINFO = CorrelativoInforme,
                CODANOINFO = CodigoAnioInforme,
                CODINFORME = NumeroInforme,
            };
            BE.SIC_INFORME srcQuery = new BL.SIC_INFORME().Recuperar(entQuery);

            BE.SIC_PROGINSPEC entQueryProg = new BE.SIC_PROGINSPEC()
            {
                CODANOSOLI = srcQuery.CODANOINFO,
                CODNUMESOLI = srcQuery.CODNUMESOLI,
                CODTIPOSOLI = srcQuery.CODTIPOSOLI
            };
            BE.SIC_PROGINSPEC srcQueryProg = new BL.SIC_PROGINSPEC().ListarUltima(entQueryProg);
            if (srcQueryProg == null)
            {
                srcQueryProg = new BE.SIC_PROGINSPEC();
            }
            var nroInspec = (srcQueryProg.CODNROINSPEC != null ) ? srcQueryProg.CODNROINSPEC.Substring(4,6) : "";
            var NroInspeccion = srcQueryProg.NROINSPECCION;
            var NroCalidad = srcQuery.NROCALIDADVERIFICACION;
            var txtNumeroInpeccion="";
            if (NroCalidad == null)
            {
                txtNumeroInpeccion = NroInspeccion;
            }
            else
            {
                txtNumeroInpeccion = NroCalidad;
                
            }

            InformesViewModel Informe = new InformesViewModel()
            {
                FiltrarCodigoPeriodo = srcQuery.CODANOINFO,
                FiltrarCodigoInforme = srcQuery.CODINFORME,
                FiltrarCodigoTipoInforme = srcQuery.CODTIPOINFOR,
                FiltrarCodigoCorrelativo = srcQuery.CODCORRINFO,
                Asunto = srcQuery.TXTASUNTO,
                DescripcionInforme = srcQuery.TXTDESCRIPCIONINFORME,
                NombreOficina = srcQuery.TXTOFICINA,
                CodigoOficina = srcQuery.CODOFICINA,
                CodigoCatastral = srcQuery.TXTUNIDAD,
                CodigoUnico = srcQuery.TXTCODIGOUNICO,
                FiltrarNumeroSolicitud = srcQuery.CODNUMESOLI,
                NumeroInspeccion = txtNumeroInpeccion,
                UbicacionPredio = srcQuery.TXTUNIDADDIREC,
                Solicitante = srcQuery.TXTSOLICITANTE,
                FechaInspeccion = srcQuery.FECINSPECCION == null ? "" : srcQuery.FECINSPECCION.Value.ToString("dd/MM/yyyy"),
                NombreTipoLlenado = srcQuery.TXTTIPOLLENADO,
                FechaActual = srcQuery.FECACTUAL,
                NombreAnio = srcQuery.TXTANIO,
                NombreSigla = srcQuery.TXTSIGLA,
                CargoFirma = srcQuery.TXTCARGOFIRMA,
                NombreFirma = srcQuery.TXTNOMBREFIRMA,
                Responsable = srcQuery.RESPONSABLE,
                CodTramite = srcQuery.CODTRAMITE,
                TipoPErsonaDeclarante = srcQuery.TXTPEREMISION,
                CodigoTipoDocumento = srcQuery.TXTTIPODOCUMENTO,
                TipoVerificacion = srcQuery.TIPO_VERIFICACION

            };

            return Informe;
        }
        
        public List<RegistrarInformeDetalle> ObtenerListaInformeDetalle(string CodigoTipoInforme, string NumeroInforme, string CorrelativoInforme, string CodigoAnioInforme)
        {
            BE.SIC_INFORMEDETA entQuery = new BE.SIC_INFORMEDETA()
            {
                CODTIPOINFOR = CodigoTipoInforme,
                CODANOINFO = CodigoAnioInforme,
                CODINFORME = NumeroInforme,
                CODCORRINFO = CorrelativoInforme

            };

            ICollection<BE.SIC_INFORMEDETA> srcQuery = new BL.SIC_INFORMEDETA().Listar(entQuery);
            int cont = 0;
            var contexto = System.Web.HttpContext.Current.Request.ApplicationPath;
            var lisDataQuery = new List<RegistrarInformeDetalle>();
            foreach (var item in srcQuery)
            {
                cont++;
                string output = item.TXTDETALLE;
                if (item.TXTDETALLE != null)
                {
                    Regex regex = new Regex(@"src=.(.[a-zA-Z]*)");
                    Match match = regex.Match(item.TXTDETALLE);
                    if (match.Success)
                    {
                        string key = match.Groups[1].Value;
                        if (key.Substring(0, 4).ToUpper() == "/MSI")
                        {
                            output = Regex.Replace(item.TXTDETALLE, key, contexto);
                        }
                        else
                        {
                            output = Regex.Replace(item.TXTDETALLE, key, contexto + key);
                        }
                        output = output.Replace("//", "/");
                    }
                }
                lisDataQuery.Add(new RegistrarInformeDetalle
                {
                    Detalle = output,
                    Item = cont.ToString(),
                    Titulo = item.TXTTITULO,
                    CodigoCorrelativo = item.CODCORRELDETA,
                    SubTitulo = item.TXTSUBTITULO,
                    CodigoTipoDetalle = item.CODTIPODETALLE
                });


            }

            //var data = srcQuery.ToList();
            //if (srcQuery.Count == 0)
            //{
            //    srcQuery = new List<BE.SIC_INFORMEDETA>();
            //}
            //var lisDataQuery = new List<RegistrarInformeDetalle>();
            //foreach (var item in data)
            //{
            //    lisDataQuery.Add(new RegistrarInformeDetalle
            //    {
            //        CodigoTipoInforme =  item.CODTIPOINFOR,
            //        CodigoPeriodo = item.CODANOINFO,
            //        CodigoInforme = item.CODINFORME,
            //        Titulo = item.TXTTITULO,
            //        Detalle = item.TXTDETALLE,
                   
            //    });
            //}
            return lisDataQuery;
        }

        public List<LineasContructivasViewModel> RecuperarUnidadListaConstruccion(int CodigoUniCat)
        {
            BE.SIC_UNIDADCONSTRUCCION entQuery = new BE.SIC_UNIDADCONSTRUCCION();
            entQuery.CODUNI = CodigoUniCat;

            ICollection<BE.SIC_UNIDADCONSTRUCCION> srcQuery = new BL.SIC_UNIDADCONSTRUCCION().Listar(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADCONSTRUCCION>();
            }
            var lisDataQuery = new List<LineasContructivasViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new LineasContructivasViewModel
                {
                    CodigoUnidadCatastral = item.CODUNI,
                    txtPiso = item.TXTPISO,
                    Mes = item.TXTMES,
                    Ano = item.TXTANO,
                    Material = item.TXTMATEESTR,
                    EstadoConst = item.TXTESTACONSE,
                    Muro = item.CODCATEMURO,
                    Techo = item.CODCATETECH,
                    Piso = item.CODCATEPISO,
                    Puerta = item.CODCATEPUERVENT,
                    Revest = item.CODCATEREVE,
                    Bano = item.CODCATEBANO,
                    Electricas = item.CODCATEINSTELEC,
                    Declarada = item.NUMAREADECL,
                    Verificada = item.NUMAREAVERI,
                    CodigoCorrelativo = item.CODCORRUNIDCONS,
                });
            }
            return lisDataQuery;
        }

        public List<OtrasInstalacionesViewModel> RecuperarUnidadListaInstalaciones(int CodigoUniCat)
        {
            BE.SIC_UNIDINSTALACION entQuery = new BE.SIC_UNIDINSTALACION();
            entQuery.CODUNI = CodigoUniCat;

            ICollection<BE.SIC_UNIDINSTALACION> srcQuery = new BL.SIC_UNIDINSTALACION().Listar(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDINSTALACION>();
            }
            var lisDataQuery = new List<OtrasInstalacionesViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new OtrasInstalacionesViewModel
                {
                    CodigoUnidadCatastral = item.CODUNI,
                    CodigoTipoInstalacion = item.CODINSTALACION,
                    NombreInstalacion = item.TXTNOMBRE,
                    Capacidad = item.NUMCAPACIDAD,
                    Cantidad = item.NUMCANTIDAD,
                    CodigoUnidad = item.CODUNIDAD,
                    Mes = item.TXTMES,
                    Ano = item.TXTANO,
                    EstadoConserva = item.CODESTACONSE,
                    Estado = Convert.ToInt32(item.ESTADO),
                    CodigoCorrelativo = item.CODCORRUNIDINST,
                });
            }
            return lisDataQuery;
        }

        public String ObtenerHtmlConstrucciones(string ParamCodigoUnico, string ParamCodigoCatastral)
        {

            String strCuerpo = string.Empty;
            
            String[] ArrayCodigoUnico = ParamCodigoUnico.Split('|');
            String[] ArrayCodigoCatastral = ParamCodigoCatastral.Split('|');

            int indiceArrayCatastral = 0;

            foreach (String CodigoUnico in ArrayCodigoUnico)
            {
                List<LineasContructivasViewModel> ListaConstrucciones = RecuperarUnidadListaConstruccion(Convert.ToInt32(CodigoUnico));

                int indiceContruccion = 0;

                foreach (LineasContructivasViewModel Construccion in ListaConstrucciones)
                {
                    if (indiceContruccion == 0)
                    {
                        strCuerpo = strCuerpo + "<h2 style='text-align: center'><span style='font-size:16px'><span style='font-family:Tahoma'>CÓDIGO DE REFERENCIA CATASTRAL " + ArrayCodigoCatastral[indiceArrayCatastral] + "</span></span></h2><br>";
                        strCuerpo = strCuerpo + "<table border='1' cellpadding='0' cellspacing='0' width='100%'>";
                        strCuerpo = strCuerpo + "<tr>";
                        strCuerpo = strCuerpo + "<th width='7%'> NIVEL </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> MES </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> AÑO </th>";
                        strCuerpo = strCuerpo + "<th width='11%'> MAT. ESTRUC. </th>";
                        strCuerpo = strCuerpo + "<th width='11%'> EST. CONSERV. </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> MURO </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> TECHO </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> PISOS </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> P/V </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> REV. </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> BAÑOS </th>";
                        strCuerpo = strCuerpo + "<th width='7%'> INST. ELEC. </th>";
                        strCuerpo = strCuerpo + "<th width='8%'> ÁREAS </th>";
                        strCuerpo = strCuerpo + "</tr>";

                        strCuerpo = strCuerpo + "<tr>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.txtPiso + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Mes + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Ano + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Material + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.EstadoConst + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Muro + "</th>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Techo + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Piso + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Puerta + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Revest + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Bano + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Electricas + "</td>";
                        decimal area = (Construccion.Verificada != null)? (decimal)Construccion.Verificada: 0;
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + String.Format("{0:0.0000}", area) + "</td>";
                        
                        strCuerpo = strCuerpo + "</tr>";

                    }
                    else
                    {
                        strCuerpo = strCuerpo + "<tr>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.txtPiso + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Mes + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Ano + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Material + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.EstadoConst + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Muro + "</th>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Techo + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Piso + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Puerta + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Revest + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Bano + "</td>";
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Electricas.Substring(Construccion.Electricas.Length-1) + "</td>";
                        decimal area = (Construccion.Verificada != null) ? (decimal)Construccion.Verificada : 0;
                        strCuerpo = strCuerpo + "<td style='text-align:center'>" + String.Format("{0:0.0000}", area) + "</td>";
                        strCuerpo = strCuerpo + "</tr>";
                    }

                    indiceContruccion++;
                    if (indiceContruccion == ListaConstrucciones.Count)
                    {
                        strCuerpo = strCuerpo + "</table><br>";
                    }

                }

                //strCuerpo = strCuerpo + "</table>";



                indiceArrayCatastral++;

            }

            return strCuerpo;

        }

        public String ObtenerHtmlInstalaciones(string ParamCodigoUnico, string ParamCodigoCatastral)
        {

            String strCuerpo = string.Empty;

            String[] ArrayCodigoUnico = ParamCodigoUnico.Split('|');
            String[] ArrayCodigoCatastral = ParamCodigoCatastral.Split('|');

            int indiceArrayCatastral = 0;

            foreach (String CodigoUnico in ArrayCodigoUnico)
            {
                List<OtrasInstalacionesViewModel> ListaConstrucciones = RecuperarUnidadListaInstalaciones(Convert.ToInt32(CodigoUnico));

                int indiceContruccion = 0;

                foreach (OtrasInstalacionesViewModel Construccion in ListaConstrucciones)
                {
                    if (indiceContruccion == 0)
                    {
                        strCuerpo = strCuerpo + "<h2 style='text-align: center'><span style='font-size:16px'><span style='font-family:Tahoma'>CÓDIGO DE REFERENCIA CATASTRAL " + ArrayCodigoCatastral[indiceArrayCatastral] + "</span></span></h2><br>";
                        strCuerpo = strCuerpo + "<table border='1' cellpadding='0' cellspacing='0' width='100%'>";
                        strCuerpo = strCuerpo + "<tr>";
                        strCuerpo = strCuerpo + "<th width='10%'> CÓDIGO </th>";
                        strCuerpo = strCuerpo + "<th width='40%'> DESCRIPCION </th>";
                        strCuerpo = strCuerpo + "<th width='10%'> UN. </th>";
                        strCuerpo = strCuerpo + "<th width='10%'> CAP.</th>";
                        strCuerpo = strCuerpo + "<th width='10%'> CANT. </th>";
                        strCuerpo = strCuerpo + "<th width='10%'> FECHA </th>";
                        strCuerpo = strCuerpo + "<th width='10%'> EST </th>";
                        strCuerpo = strCuerpo + "</tr>";
                    }
                    strCuerpo = strCuerpo + "<tr>";
                    strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.CodigoTipoInstalacion + "</td>";
                    strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.NombreInstalacion + "</th>";
                    strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.CodigoUnidad + "</td>";
                    strCuerpo = strCuerpo + "<td style='text-align:center'>" + String.Format("{0:0.0000}", Construccion.Capacidad) + "</td>";
                    strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Cantidad + "</td>";
                    strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.Mes + "/" + Construccion.Ano + "</td>";
                    strCuerpo = strCuerpo + "<td style='text-align:center'>" + Construccion.EstadoConserva.Substring(Construccion.EstadoConserva.Length-1) + "</td>";
                    strCuerpo = strCuerpo + "</tr>";

                    indiceContruccion++;
                    if (indiceContruccion == ListaConstrucciones.Count)
                    {
                        strCuerpo = strCuerpo + "</table><br>";
                    }

                }

                //strCuerpo = strCuerpo + "</table>";



                indiceArrayCatastral++;

            }

            return strCuerpo;

        }

    }
}