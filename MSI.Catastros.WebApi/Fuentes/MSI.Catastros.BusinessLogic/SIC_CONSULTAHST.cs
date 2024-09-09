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
    public class SIC_CONSULTAHST
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (15/10/2018)
        //Utilizado por	: WebApi.SIC_CONSULTAHST.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos del filtro Consulta Historica
        /// </summary>
        public ICollection<BE.SIC_CONSULTAHST> Buscar(BE.SIC_CONSULTAHST entSIC_CONSULTAHST)
        {
            List<BE.SIC_CONSULTAHST> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CONSULTAHST> entQuery = new DA.SIC_CONSULTAHST().Buscar(entSIC_CONSULTAHST);
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
        //Creado por	: AA (15/10/2018)
        //Utilizado por	: WebApi.SIC_CONSULTAHST.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite CONTAR los datos de la tabla SIC_CONSULTAHST
        /// </summary>
        public BE.SIC_CONSULTAHST BuscarInt(BE.SIC_CONSULTAHST entSIC_CONSULTAHST)
        {
            BE.SIC_CONSULTAHST lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CONSULTAHST().BuscarInt(entSIC_CONSULTAHST);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_SOLUNIDAD obtenerReferen(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_SOLUNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CONSULTAHST().obtenerReferen(entSIC_SOLUNIDAD);             
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
    }
}
