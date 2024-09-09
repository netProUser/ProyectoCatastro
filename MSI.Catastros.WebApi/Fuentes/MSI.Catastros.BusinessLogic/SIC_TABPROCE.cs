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
    public class SIC_TABPROCE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (24/05/2018)
        //Utilizado por	: WebApi.SIC_TABPROCE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TABPROCE
        /// </summary>
        public ICollection<BE.SIC_TABPROCE> Listar(BE.SIC_TABPROCE entSIC_TABPROCE)
        {
            List<BE.SIC_TABPROCE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TABPROCE> entQuery = new DA.SIC_TABPROCE().Listar(entSIC_TABPROCE);
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
        //Creado por	: Jaime Díaz Espinoza (24/05/2018)
        //Utilizado por	: WebApi.SIC_TABPROCE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TABPROCE
        /// </summary>
        public BE.SIC_TABPROCE Recuperar(BE.SIC_TABPROCE entSIC_TABPROCE)
        {
            BE.SIC_TABPROCE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TABPROCE().Recuperar(entSIC_TABPROCE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
    }
}
