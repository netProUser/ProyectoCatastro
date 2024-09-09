using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Informes;
using MSI.Catastros.Web.Filters;

namespace MSI.Catastros.Web.Controllers
{
    [LogExceptionAttribute]
    public class InformePdfController : Controller
    {
        //
        // GET: /InformePdf/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InformeVerificacion(string CodigoTipoInforme, string NumeroInforme , string CorrelativoInforme, string CodigoAnioInforme)
        {
            Byte[] pdfBytes = new InformePdfHandler().VerificacionPdfSharpConvert(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);
            FileResult fileResult = null;
            string filename = "InformeVerificacion_" + NumeroInforme + "_" + CorrelativoInforme + ".pdf";
            
            HttpContext.Response.ContentType = "applicacion/pdf";
            HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Response.AppendHeader("content.disposition", String.Format("attachment; filename = {0}", filename));
            fileResult = new FileContentResult(pdfBytes, "application/pdf");
            fileResult.FileDownloadName = filename;
            return fileResult;

        }


        [HttpGet]
        public ActionResult InformeTecnico(string CodigoTipoInforme, string NumeroInforme, string CorrelativoInforme, string CodigoAnioInforme)
        {
            Byte[] pdfBytes = new InformePdfHandler().TecnicoPdfSharpConvert(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);
            FileResult fileResult = null;
            string filename = "InformeTecnico_" + NumeroInforme + "_" + CorrelativoInforme + ".pdf";
            HttpContext.Response.ContentType = "applicacion/pdf";
            HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Response.AppendHeader("content.disposition", String.Format("attachment; filename = {0}", filename));
            fileResult = new FileContentResult(pdfBytes, "application/pdf");
            fileResult.FileDownloadName = filename;
            return fileResult;
        }

        [HttpGet]
        public ActionResult InformeNumeracion(string CodigoTipoInforme, string NumeroInforme, string CorrelativoInforme, string CodigoAnioInforme)
        {
            Byte[] pdfBytes = new InformePdfHandler().NumeracionPdfSharpConvert(CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);
            FileResult fileResult = null;
            string filename = "InformeNumeracion_" + NumeroInforme + "_" + CorrelativoInforme + ".pdf";
            HttpContext.Response.ContentType = "applicacion/pdf";
            HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Response.AppendHeader("content.disposition", String.Format("attachment; filename = {0}", filename));
            fileResult = new FileContentResult(pdfBytes, "application/pdf");
            fileResult.FileDownloadName = filename;
            return fileResult;
        }

        
	}
}