using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;

namespace MSI.Catastros.BusinessLogic
{
    public class SIC_TIPPROCED
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/05/2018)
        //Utilizado por	: WebApi.SIC_TIPPROCED.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPPROCED
        /// </summary>
        public ICollection<BE.SIC_TIPPROCED> Buscar(BE.SIC_TIPPROCED entSIC_TIPPROCED)
        {
            List<BE.SIC_TIPPROCED> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TIPPROCED> entQuery = new DA.SIC_TIPPROCED().Buscar(entSIC_TIPPROCED);
                if (entQuery != null)
                {
                    lisQuery = entQuery.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/05/2018)
        //Utilizado por	: WebApi.SIC_TIPPROCED.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TIPPROCED
        /// </summary>
        public BE.SIC_TIPPROCED Recuperar(BE.SIC_TIPPROCED entSIC_TIPPROCED)
        {
            BE.SIC_TIPPROCED lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TIPPROCED().Recuperar(entSIC_TIPPROCED);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
    }
}
