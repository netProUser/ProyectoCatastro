using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.ViasAnterior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE = MSI.Catastros.BusinessEntities;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ViasAnteriorController : Controller
    {
        //
        // GET: /ViasAnterior/
        public ActionResult Index(FiltrarViasAnteriorViewModel FiltrarViasAnte)
        {
            FiltrarViasAnte.listVia = new ViasAnteriorHandler().ListarVias();
            FiltrarViasAnte.ParamDistritoVia = "SAN ISIDRO";
            return View(FiltrarViasAnte);
        }

        [HttpGet]
        public PartialViewResult Registrar()
        {
            ViewBag.listVias = new ViasAnteriorHandler().ListarVias();
            RegistroViaAnteriorViewModel RegistroVia = new RegistroViaAnteriorViewModel();
            RegistroVia.Estado = 1;
            //RegistroVia.FechaInicio = "";
            RegistroVia.Distrito = "SAN ISIDRO";
            return PartialView("_Registrar", RegistroVia);
        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroViaAnteriorViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            }
            BE.SIC_RETORNO entSIC_RETORNO = new ViasAnteriorHandler().ProcesarViaAnterior(modelo);
            if (entSIC_RETORNO.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente" });
            }
            else
            {
                return Json(new { success = false, responseText = entSIC_RETORNO.MENSAJE });
            }
        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarViasAnteriorViewModel Filtroviasdetalle)
        {
            int totalResultado;
            var resultado = new ViasAnteriorHandler().ListarGrid(model, out totalResultado, Filtroviasdetalle);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }

        [HttpGet]
        public PartialViewResult Editar(string idViaAnte, string idVia)
        {
            ViewBag.listVias = new ViasAnteriorHandler().ListarVias();
            RegistroViaAnteriorViewModel RegistroVia = new ViasAnteriorHandler().BuscarViaAnterior(idViaAnte, idVia);
            RegistroVia.Estado = 2;
            RegistroVia.Distrito = "SAN ISIDRO";
            return PartialView("_Registrar", RegistroVia);

        }

        [HttpGet]
        public ActionResult Eliminar(string idViaAnte, string idVia)
        {
            RegistroViaAnteriorViewModel RegistroVia = new ViasAnteriorHandler().BuscarViaAnterior(idViaAnte, idVia);
            RegistroVia.Estado = 3;
            return PartialView("_Eliminar", RegistroVia);
        }

        [HttpPost]
        public ActionResult Eliminar(RegistroViaAnteriorViewModel modelo)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new ViasAnteriorHandler().ProcesarViaAnterior(modelo);
            if (entSIC_RETORNO.Ok == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }


        //
        // GET: /ViasAnterior/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ViasAnterior/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ViasAnterior/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            
        }

        //
        // GET: /ViasAnterior/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ViasAnterior/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
                // TODO: Add update logic here

                return RedirectToAction("Index");
            
        }

        //
        // GET: /ViasAnterior/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ViasAnterior/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            
        }
    }
}
