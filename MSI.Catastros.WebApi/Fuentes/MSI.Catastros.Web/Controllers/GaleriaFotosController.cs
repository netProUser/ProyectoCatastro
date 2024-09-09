using MSI.Catastros.Web.Funcionalidad.Lotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    public class GaleriaFotosController : Controller
    {
        // GET: GaleriaFotos
        public ActionResult Index()
        {
            return View();
        }

        // GET: GaleriaFotos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GaleriaFotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GaleriaFotos/Create
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

        // GET: GaleriaFotos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GaleriaFotos/Edit/5
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

        // GET: GaleriaFotos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GaleriaFotos/Delete/5
        [HttpPost]
        public ActionResult CargarImagen(RegistrarLoteViewModel model)
        {
            return Json(new { success = true, responseText = "Imagen subida correctamente ", imagen = new LotesHandler().RecuperarLoteImagen(model) });
           
        }
    }
}
