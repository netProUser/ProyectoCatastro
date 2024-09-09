using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BE = MSI.Catastros.BusinessEntities;
using BL = MSI.Catastros.BusinessLogic;
using HP = MSI.Catastros.Helpers;

namespace MSI.Catastros.WebApi.Controllers
{
    public class SIC_VIADETALLEController : ApiController
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIADETALLE
        /// </summary>
        //[HttpGet]
        //public IHttpActionResult Buscar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        //{
        //    var lista = new BL.SIC_VIADETALLE().Listar(entSIC_VIADETALLE);
        //    if (lista == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(lista);
        //}
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        [HttpGet]
        public IHttpActionResult Recuperar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            var lista = new BL.SIC_VIADETALLE().Recuperar(entSIC_VIADETALLE);
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_VIADETALLE, retorna numero de ERROR o ID generado
        /// </summary>
        [HttpPost]
        public IHttpActionResult Grabar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            int intResultado = 0;
           // intResultado = new BL.SIC_VIADETALLE().Grabar(entSIC_VIADETALLE);
            return Ok(intResultado);
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        [HttpPost]
        public IHttpActionResult Actualizar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            int intResultado = 0;
          //  intResultado = new BL.SIC_VIADETALLE().Actualizar(entSIC_VIADETALLE);
            return Ok(intResultado);
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_VIADETALLE
        /// </summary>
        [HttpPost]
        public IHttpActionResult Eliminar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            int intResultado = 0;
           // intResultado = new BL.SIC_VIADETALLE().Eliminar(entSIC_VIADETALLE);
            return Ok(intResultado);
        }
    }
}
