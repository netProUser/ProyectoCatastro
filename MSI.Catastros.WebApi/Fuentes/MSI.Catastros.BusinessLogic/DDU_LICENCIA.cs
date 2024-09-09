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
    public class DDU_LICENCIA
    {
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (16/07/2018)
        //Utilizado por	: WebApi.DDU_LICENCIA.Consulta
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla DDU_LICENCIA
        /// </summary>
        public ICollection<BE.DDU_LICENCIA> Consulta(BE.DDU_LICENCIA entDDU_LICENCIA)
        {
            List<BE.DDU_LICENCIA> lisQuery = null;
            try
            {
                IEnumerable<BE.DDU_LICENCIA> entQuery = new DA.DDU_LICENCIA().Consulta(entDDU_LICENCIA);
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
