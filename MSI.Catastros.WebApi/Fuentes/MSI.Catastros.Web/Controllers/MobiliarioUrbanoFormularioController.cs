using MSI.Catastros.Web.Decoradores;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.MobiliarioUrbanoFormulario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Controllers
{
    [LogExceptionAttribute]
    public class MobiliarioUrbanoFormularioController : Controller
    {
        //
        // GET: /MobiliarioUrbanoFormulario/
        public ActionResult Index()
        {
            return View(new MobiliarioUrbanoFormularioViewModel());
        }
        /*Listado*/
        [HttpPost]
        public ActionResult ListarClase()
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoClase();
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult ListarSubClase(SubClaseViewModel _modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoSubClase(_modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false, data = "" });
        }

        [HttpPost]
        public ActionResult ListarObejeto(ObjetoViewModel _modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoObjeto(_modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }


        /*Matenimiento*/
        [HttpGet]
        public PartialViewResult RegistarClase()
        {
            return PartialView("_Clase", new ClaseViewModel());
        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult RegistrarClase(ClaseViewModel _modelo)
        {
            if (ModelState.IsValid)
            {
                Nullable<bool> EstadoProceso = new MobiliarioUrbanoFormularioHandler().ProcesoClase(_modelo);
                if (EstadoProceso == true)
                {
                    return Json(new { success = true, responseText = "Grabo correctamente" });
                }
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }

        [HttpGet]
        public PartialViewResult RegistarSubClase()
        {
            return PartialView("_SubClase", new SubClaseViewModel());
        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult RegistrarSubClase(SubClaseViewModel _modelo)
        {
            if (ModelState.IsValid)
            {
                Nullable<bool> EstadoProceso = new MobiliarioUrbanoFormularioHandler().ProcesoSubClase(_modelo);
                if (EstadoProceso == true)
                {
                    return Json(new { success = true, responseText = "Grabo correctamente" });
                }
            }
            return Json(new { success = false, responseText = "Error del servidor" });

        }
        [HttpGet]
        public PartialViewResult RegistrarObjeto()
        {
            return PartialView("_Objeto", new ObjetoViewModel());
        }
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult RegistrarObjeto(ObjetoViewModel _modelo)
        {
            if (ModelState.IsValid)
            {
                Nullable<bool> EstadoProceso = new MobiliarioUrbanoFormularioHandler().ProcesoObjeto(_modelo);
                if (EstadoProceso == true)
                {
                    return Json(new { success = true, responseText = "Grabo correctamente" });
                }
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        /*MANT FORMULARIO SUB CLASE*/
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult RegistrarFormSubClase(FormularioDetalleViewModel _modelo)
        {
            if (ModelState.IsValid)
            {
                Nullable<bool> EstadoProceso = new MobiliarioUrbanoFormularioHandler().ProcesoFormularioSubClase(_modelo);
                if (EstadoProceso == true)
                {
                    return Json(new { success = true, responseText = "Grabo correctamente" });
                }
            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult ListarFormularioSubClase(ObjetoViewModel _modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoFormularioSubClase(_modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }

        /*MANT FORMULARIO OBJETO*/
        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult RegistrarFormObjeto(FormularioDetalleViewModel _modelo)
        {
            if (ModelState.IsValid)
            {
                Nullable<bool> EstadoProceso = new MobiliarioUrbanoFormularioHandler().ProcesoFormularioObjeto(_modelo);
                if (EstadoProceso == true)
                {
                    return Json(new { success = true, responseText = "Grabo correctamente" });
                }

            }
            return Json(new { success = false, responseText = "Error del servidor" });
        }
        [HttpPost]
        public ActionResult ListarFormularioObjeto(ObjetoViewModel _modelo)
        {
            //try
            //{
                var datas = new MobiliarioUrbanoFormularioHandler().ListadoFormularioObjeto(_modelo);
                return Json(new { success = true, data = datas });
            //}
            //catch (Exception)
            //{
            //}
            //return Json(new { success = false });
        }
    }
}