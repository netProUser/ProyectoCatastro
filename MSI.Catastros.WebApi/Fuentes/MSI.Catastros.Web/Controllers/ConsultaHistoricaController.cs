using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using MSI.Catastros.Web.Funcionalidad.ConsultaHistorica;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.DetalleVias;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;
//using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
using System.IO;
using System.Configuration;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ConsultaHistoricaController : Controller
    {
        // GET: ConsultaHistorica
        public ActionResult Index(FiltrarConsultaHistoricaViewModel ConsultaViewModel)
        {        
            ConsultaViewModel.ListTipoDocumento = new List<SelectListItem>();            
            return View(ConsultaViewModel);

        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarConsultaHistoricaViewModel FiltroConsultas)
        {
            int totalResultado = 0;
          
            String sector = Request.Form.GetValues("FiltrarCodigoSector").FirstOrDefault();
            var resultado = new List<FiltrarConsultaHistoricaViewModel>();
            if (sector.Equals("")){}
            else{
               resultado = new ConsultaHistoricaHandler().ListarGrid(model, out totalResultado, FiltroConsultas);
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        public FileResult Descargar(string id)
        {
            //byte[] fileBytes = System.IO.File.ReadAllBytes(@System.Configuration.ConfigurationManager.AppSettings["RUTA_ARCHIVOS"] + "\\" + id + ".pdf");
            //string fileName =  id + ".pdf";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            //return File(System.Configuration.ConfigurationManager.AppSettings["RUTA_ARCHIVOS"] + "\\" + id + ".pdf", System.Net.Mime.MediaTypeNames.Application.Octet);
            byte[] pdfFile;
           // pdfFile = System.IO.File.ReadAllBytes(@System.Configuration.ConfigurationManager.AppSettings["RUTA_ARCHIVOS"] + "\\" + id + ".pdf");
            pdfFile = System.IO.File.ReadAllBytes(id);
            //pdfFile = GetByteArray();
           // var fileName = System.Configuration.ConfigurationManager.AppSettings["RUTA_ARCHIVOS"] + "\\" + id + ".pdf";
           // var fileName = @ConfigurationManager.AppSettings["RUTA_FILSERVER"] + id;
            var fileName =  id;
            var fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            fileStream.Write(pdfFile, 0, pdfFile.Length);
            fileStream.Close();
            return File(pdfFile, "application/pdf");
        }

        public ActionResult ReferenciaCatas(String CodSector, String CodManzana, String CodLote, String CodEdif, String CodEntrada, String CodPiso, String CodUnidad, String CODTIPODOC)
        {
            bool resul = false;
            SolicitudUnidadViewModel resultado = new ConsultaHistoricaHandler().RecuperarReferencia(CodSector, CodManzana, CodLote, CodEdif, CodEntrada,CodPiso,CodUnidad,CODTIPODOC, out resul);
        
            return Json(new
            {
                success = resul,
                resultado = resultado
            });
        }
        
    }
}