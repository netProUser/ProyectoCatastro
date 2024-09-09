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
    public class SAT_OTRAINSTALACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (26/06/2018)
        //Utilizado por	: WebApi.SAT_OTRAINSTALACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SAT_OTRAINSTALACION
        /// </summary>
        public ICollection<BE.SAT_OTRAINSTALACION> Listar(BE.SAT_OTRAINSTALACION entSAT_OTRAINSTALACION)
        {
            List<BE.SAT_OTRAINSTALACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SAT_OTRAINSTALACION> entQuery = new DA.SAT_OTRAINSTALACION().Listar(entSAT_OTRAINSTALACION);
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

        public ICollection<BE.SAT_OTRAINSTALACION> ListarAnioActual()
        {
            List<BE.SAT_OTRAINSTALACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SAT_OTRAINSTALACION> entQuery = new DA.SAT_OTRAINSTALACION().ListarAnioActual();
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
