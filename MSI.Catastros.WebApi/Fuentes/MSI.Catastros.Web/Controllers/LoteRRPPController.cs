using MSI.Catastros.Web.Funcionalidad.Lotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    public class LoteRRPPController : Controller
    {
        // GET: LoteRRPP
        public ActionResult Index()
        {
            ViewBag.TipoDocRRPP = new LotesHandler().ListarTipoDocRRPP();
            return View();
        }

        // GET: LoteRRPP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoteRRPP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoteRRPP/Create
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

        // GET: LoteRRPP/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoteRRPP/Edit/5
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

        // GET: LoteRRPP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoteRRPP/Delete/5
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
