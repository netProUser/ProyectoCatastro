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
    public class SIC_SECTORController : ApiController
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SECTOR
        /// </summary>
        [HttpGet]
        public IHttpActionResult Buscar(BE.SIC_SECTOR entSIC_SECTOR)
        {
            var lista = new BL.SIC_SECTOR().Buscar(entSIC_SECTOR);
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
        /// Permite recuperar un registro de la tabla SIC_SECTOR
        /// </summary>
        [HttpGet]
        public IHttpActionResult Recuperar(BE.SIC_SECTOR entSIC_SECTOR)
        {
            var lista = new BL.SIC_SECTOR().Recuperar(entSIC_SECTOR);
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
        /// Permite grabar un registro de la tabla SIC_SECTOR, retorna numero de ERROR o ID generado
        /// </summary>
        [HttpPost]
        public IHttpActionResult Grabar(BE.SIC_SECTOR entSIC_SECTOR)
        {
            int intResultado = 0;
            intResultado = new BL.SIC_SECTOR().Grabar(entSIC_SECTOR);
            return Ok(intResultado);
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SECTOR
        /// </summary>
        [HttpPost]
        public IHttpActionResult Actualizar(BE.SIC_SECTOR entSIC_SECTOR)
        {
            int intResultado = 0;
            intResultado = new BL.SIC_SECTOR().Actualizar(entSIC_SECTOR);
            return Ok(intResultado);
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_SECTOR
        /// </summary>
        [HttpPost]
        public IHttpActionResult Eliminar(BE.SIC_SECTOR entSIC_SECTOR)
        {
            int intResultado = 0;
            intResultado = new BL.SIC_SECTOR().Eliminar(entSIC_SECTOR);
            return Ok(intResultado);
        }
    }
}
