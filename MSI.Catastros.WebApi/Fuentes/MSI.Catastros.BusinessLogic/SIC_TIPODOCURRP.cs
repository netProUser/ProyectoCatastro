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
    public class SIC_TIPODOCURRP
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (10/07/2018)
        //Utilizado por	: WebApi.SIC_TIPODOCURRP.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPODOCURRP
        /// </summary>
        public ICollection<BE.SIC_TIPODOCURRP> Listar(BE.SIC_TIPODOCURRP entSIC_TIPODOCURRP)
        {
            List<BE.SIC_TIPODOCURRP> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TIPODOCURRP> entQuery = new DA.SIC_TIPODOCURRP().Listar(entSIC_TIPODOCURRP);
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
    }
}
