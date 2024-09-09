using MSI.Catastros.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class RegistrarAtencionController : Controller
    {
        //
        // GET: /RegistrarAtencion/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: /RegistrarAtencion/ControlCalidad
        public PartialViewResult ControlCalidad()
        {
            return PartialView("_ControlCalidad");
        }

        //
        // GET: /RegistrarAtencion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /RegistrarAtencion/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RegistrarAtencion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            
        }

        //
        // GET: /RegistrarAtencion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /RegistrarAtencion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
                // TODO: Add update logic here

                return RedirectToAction("Index");
           
        }

        //
        // GET: /RegistrarAtencion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RegistrarAtencion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            
        }
    }
}
