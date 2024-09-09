using MSI.Catastros.Web.Funcionalidad.ConsultaCertificados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proc = MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Certificados;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Controllers
{
    public class ConsultaCertificadosController : Controller
    {
        // GET: ConsultaCertificados
        public ActionResult Index(ConsultaCertificadosViewModel cartas)
        {
            return View(new ConsultaCertificadosViewModel()
            {
                ListTipoInforme = new List<SelectListItem>() {
                    new SelectListItem(){ Value = "CEJU", Text = "CERTIFICADO DE JURISDICCIÓN"},
                    new SelectListItem(){ Value = "CENO", Text = "CERTIFICADO DE NOMENCLATURA"},
                    new SelectListItem(){ Value = "CNMU", Text = "CERTIFICADO DE NUMERACIÓN"},
                    new SelectListItem(){ Value = "RNUM", Text = "RESOLUCIÓN DE NUMERACIÓN"},
                    new SelectListItem(){ Value = "HINF", Text = "HOJA INFORMATIVA"},
                    new SelectListItem(){ Value = "CEAC", Text = "PLANO DE ACUMULACIÓN"}
                },
                ListTipoSolicitud = new Proc.ProcedimientoNuevoHandler().ListadoTipoSolicitud(),
                ListTipoDocumento = new Proc.ProcedimientoNuevoHandler().ListadoTipoDocumento(),
               
            });
        }

        public ActionResult CargarGrillaCertificados(DataTableAjaxPostModel model, ConsultaCertificadosViewModel FiltroConsultaCertificado)
        {
            int totalResultado = 0;

            FiltroConsultaCertificado.FiltrarCodigoTipoCertificado = Request.Form.GetValues("FiltrarCodigoTipoCertificado").FirstOrDefault();
            FiltroConsultaCertificado.FiltrarCodigoTipoSolicitud = Request.Form.GetValues("FiltrarCodigoTipoSolicitud").FirstOrDefault();
            FiltroConsultaCertificado.FiltrarCodigoTipoDocumentoReg = Request.Form.GetValues("FiltrarCodigoTipoDocumentoReg").FirstOrDefault();
            FiltroConsultaCertificado.FiltrarNumeroSolicitud = Request.Form.GetValues("FiltrarNumeroSolicitud").FirstOrDefault();
            FiltroConsultaCertificado.FechaInicio = Request.Form.GetValues("FecInicio").FirstOrDefault();
            FiltroConsultaCertificado.FechaFin = Request.Form.GetValues("FecFin").FirstOrDefault();
            FiltroConsultaCertificado.txtCodigoCatastral = Request.Form.GetValues("txtCodigoCatastral").FirstOrDefault();

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal;


            List<ConsultaCertificadosViewModel> resultado;

                resultado = new ConsultaCertificadosHandler().CargarGrillaCertificados(draw, start, length, pageSize, skip, model, FiltroConsultaCertificado, out recordsTotal);
                totalResultado = resultado.Count;
          
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = resultado });


        }

    }
}
