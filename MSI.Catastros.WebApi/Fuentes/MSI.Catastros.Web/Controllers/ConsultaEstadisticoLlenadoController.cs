using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    public class ConsultaEstadisticoLlenadoController : Controller
    {
        // GET: ConsultaEstadisticoLlenado
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConsultaEstadisticoLlenado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConsultaEstadisticoLlenado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsultaEstadisticoLlenado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ConsultaEstadisticoLlenado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConsultaEstadisticoLlenado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ConsultaEstadisticoLlenado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConsultaEstadisticoLlenado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
