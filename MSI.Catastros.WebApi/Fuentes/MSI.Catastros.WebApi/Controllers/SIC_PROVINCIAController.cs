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
    public class SIC_PROVINCIAController : ApiController
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: Web
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PROVINCIA
        /// </summary>
        [HttpGet]
        public IHttpActionResult Buscar(BE.SIC_PROVINCIA entSIC_PROVINCIA)
        {
            var lista = new BL.SIC_PROVINCIA().Listar(entSIC_PROVINCIA);
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }
    }
}
