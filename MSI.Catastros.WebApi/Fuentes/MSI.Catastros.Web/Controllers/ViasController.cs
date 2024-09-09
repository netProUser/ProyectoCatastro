using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Vias;
using MSI.Catastros.Web.Funcionalidad.Parametros;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Decoradores;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.ViasAnterior;

namespace MSI.Catastros.Web.Controllers
{
    [Authorize]
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class ViasController : Controller
    {
        // GET: Vias
        public ActionResult Index(FiltrarViasViewModel Vias)
        {
            Vias.listTipoVias = new ViasHandler().ListarParametosVias(); 
            Vias.DistritoVia = "SAN ISIDRO";
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListarVias", Vias);
            }                
            return View(Vias);            
        }

        public ActionResult ViaList(FiltrarViasViewModel Vias)
        {
            Vias.listTipoVias = new ViasHandler().ListarParametosVias();
            return View("Index", Vias);
        }

        [HttpGet]
        public PartialViewResult Registrar()
        {
            ViewBag.listTipoVias = new ViasHandler().ListarParametosVias();
            ViewBag.listClaseVia = new ViasHandler().ListarParametosClaseVia();
            RegistroViaViewModel RegistroVia = new RegistroViaViewModel() {Estado = 1 };
            RegistroVia.Distrito = "SAN ISIDRO";
            return PartialView("_Registrar", RegistroVia);
        }

        [HttpPost]
        [ValidateAjaxAttribute]
        public ActionResult Registrar(RegistroViaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = "No es un modelo válido" });
            
            }

            if (modelo.Estado == 2 && modelo.ConvertirViaAnterior == true) {
                RegistroViaAnteriorViewModel modeloViaAnterior = new RegistroViaAnteriorViewModel()
                {
                    CodigoVia = modelo.CodigoVia,
                    DesViaAnterior = modelo.NombreViaAnterior,
                    DesTipoViaAnterior = modelo.NombreTipoViaAnterior,
                    Normativa = modelo.Normativa,
                    FechaInicio = modelo.FechaInicio,
                    FechaFinal = DateTime.Now,
                    Estado = 1,
                };

                BE.SIC_RETORNO entSIC_RETORNO = new ViasAnteriorHandler().ProcesarViaAnterior(modeloViaAnterior);

                if (entSIC_RETORNO.Ok == false)
                {
                    return Json(new { success = false, responseText = entSIC_RETORNO.MENSAJE });
                }

            }


            BE.SIC_RETORNO entSIC_RETORNOVIAS = new ViasHandler().ProcesarVias(modelo);
            if (entSIC_RETORNOVIAS.Ok == true)
            {
                return Json(new { success = true, responseText = "Grabo correctamente, codigo de via: " + entSIC_RETORNOVIAS.CODIGO });
            } else {
                return Json(new { success = false, responseText = "Código de Vía ya Registrado" });
            }
            
        }

        [HttpGet]
        public PartialViewResult Editar(string id)
        {
            ViewBag.listTipoVias = new ViasHandler().ListarParametosVias();
            ViewBag.listClaseVia = new ViasHandler().ListarParametosClaseVia();
            RegistroViaViewModel RegistroVia = new ViasHandler().BuscarVia(id);
            RegistroVia.Estado = 2;
            RegistroVia.Distrito = "SAN ISIDRO";
            return PartialView("_Registrar", RegistroVia);

        }

        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            RegistroViaViewModel Via = new ViasHandler().BuscarVia(id);
            Via.Estado = 3;
            return PartialView("_Eliminar", Via);
        }

        [HttpPost]
        public ActionResult Eliminar(RegistroViaViewModel modelo)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new ViasHandler().ProcesarVias(modelo);
            if (entSIC_RETORNO.Ok == true)
            {
                return Json(new { success = true, responseText = "Elimino correctamente" });
            }
            return Json(new { success = false, responseText = "Se ha detectado un problema en el servidor" });
        }

        [HttpGet]
        public ActionResult ListarGridVias(string id)
        {
            RegistroViaViewModel RegistroVia = new ViasHandler().BuscarVia(id);
            RegistroVia.Estado = 3;
            return PartialView("_Eliminar", RegistroVia);
        }

        [HttpPost]
        public ActionResult CargarGrid(DataTableAjaxPostModel model, FiltrarViasViewModel Filtrovias)
        {
            int totalResultado;
            var resultado = new ViasHandler().ListarGrid(model, out totalResultado, Filtrovias);
            return Json(new { draw = model.draw, recordsTotal = totalResultado, recordsFiltered = totalResultado, data = resultado });
        }
        
        [HttpPost]
        public ActionResult CargarGrid2(DataTableAjaxPostModel model, FiltrarViasViewModel Filtrovias) 
        {
            int resultadoFiltrados; 
            int totalResultadoFiltrados;
            var res = new ViasHandler().ListarGrid2(model, out resultadoFiltrados, out totalResultadoFiltrados, Filtrovias);

            var resultado = new List<ViaViewModel>(res.Count);
            foreach (var s in res) 
            {
                resultado.Add(new ViaViewModel { CodigoVia = s.CODVIA, NombreVia = s.TXTVIA, DesTipoVia = s.TXTTIPODEVIA, DesClaseVia = s.TXTCLASIFICACIONVIA  });
            }
            return Json(new { draw = model.draw, recordsTotal = totalResultadoFiltrados, recordsFiltered = resultadoFiltrados, data = resultado });

  
        }

        [HttpPost]
        public ActionResult LoadData2()
        {
            //try
            //{
                //Creating instance of DatabaseContext class  
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();  
                //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();  
                //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();  


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                // int recordsTotal = 0;


                #region Obtener datos
                BE.SIC_VIA entQuery = new BE.SIC_VIA();
                entQuery.PAGINANUMERO = 1;
                entQuery.PAGINAREGISTROS = 5;
                entQuery = new BL.SIC_VIA().BuscarInt(entQuery);

                entQuery.ORDEN = "CODVIA";
                entQuery.PAGINANUMERO = 1;
                entQuery.PAGINAREGISTROS = 5;
                var srcQuery = new BL.SIC_VIA().Buscar(entQuery);
                #endregion
                //return PartialView("_ListarVias", entQuery);

                //IEnumerable<BE.SIC_VIA> lisQuery = new BL.SIC_VIA().Buscar(entQuery);


                // Getting all Customer data    
                //var customerData = (from tempcustomer in _context.Customers  
                //                    select tempcustomer);  

                //Sorting    
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))  
                //{  
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);  
                //}  
                //Search    
                //if (!string.IsNullOrEmpty(searchValue))  
                //{  
                //    customerData = customerData.Where(m => m.CompanyName == searchValue);  
                //}  

                //total number of rows count     

                //Paging     
                var data = srcQuery.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = entQuery.TOTALREGISTROS, recordsTotal = entQuery.TOTALREGISTROS, data = data });
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

        }
    }
}
