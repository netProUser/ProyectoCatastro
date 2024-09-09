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
    public class SIC_MANZANAController : ApiController
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANA
        /// </summary>
        [HttpGet]
        public IHttpActionResult Buscar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            var lista = new BL.SIC_MANZANA().Buscar(entSIC_MANZANA);
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
        /// Permite recuperar un registro de la tabla SIC_MANZANA
        /// </summary>
        [HttpGet]
        public IHttpActionResult Recuperar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            var lista = new BL.SIC_MANZANA().Recuperar(entSIC_MANZANA);
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
        /// Permite grabar un registro de la tabla SIC_MANZANA, retorna numero de ERROR o ID generado
        /// </summary>
        [HttpPost]
        public IHttpActionResult Grabar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            int intResultado = 0;
            intResultado = new BL.SIC_MANZANA().Grabar(entSIC_MANZANA);
            return Ok(intResultado);
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_MANZANA
        /// </summary>
        [HttpPost]
        public IHttpActionResult Actualizar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            int intResultado = 0;
            intResultado = new BL.SIC_MANZANA().Actualizar(entSIC_MANZANA);
            return Ok(intResultado);
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_MANZANA
        /// </summary>
        [HttpPost]
        public IHttpActionResult Eliminar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            int intResultado = 0;
            intResultado = new BL.SIC_MANZANA().Eliminar(entSIC_MANZANA);
            return Ok(intResultado);
        }
    }
}
