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
    public class SIC_TIPOLLENA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (29/05/2018)
        //Utilizado por	: WebApi.SIC_TIPOLLENA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TIPOLLENA
        /// </summary>
        public BE.SIC_TIPOLLENA Recuperar(BE.SIC_TIPOLLENA entSIC_TIPOLLENA)
        {
            BE.SIC_TIPOLLENA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TIPOLLENA().Recuperar(entSIC_TIPOLLENA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_TIPOLLENA ObtenerDiasHabiles(DateTime FechaInicio, int Dias)
        {
            BE.SIC_TIPOLLENA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TIPOLLENA().ObtenerDiasHabiles(FechaInicio, Dias);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (29/05/2018)
        //Utilizado por	: WebApi.SIC_TIPOLLENA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPOLLENA
        /// </summary>
        public ICollection<BE.SIC_TIPOLLENA> Listar()
        {
            List<BE.SIC_TIPOLLENA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TIPOLLENA> entQuery = new DA.SIC_TIPOLLENA().Listar();
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
