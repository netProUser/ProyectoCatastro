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
    public class DDU_LICENCIAEDIFICACION
    {
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (16/07/2018)
        //Utilizado por	: WebApi.DDU_LICENCIAEDIFICACION.Consulta
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla DDU_LICENCIAEDIFICACION
        /// </summary>
        public ICollection<BE.DDU_LICENCIAEDIFICACION> Consulta(BE.DDU_LICENCIAEDIFICACION entDDU_LICENCIA)
        {
            List<BE.DDU_LICENCIAEDIFICACION> lisQuery = null;
            try
            {
                IEnumerable<BE.DDU_LICENCIAEDIFICACION> entQuery = new DA.DDU_LICENCIAEDIFICACION().Consulta(entDDU_LICENCIA);
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
