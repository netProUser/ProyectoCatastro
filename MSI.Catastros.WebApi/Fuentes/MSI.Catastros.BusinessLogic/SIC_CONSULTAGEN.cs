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
    public class SIC_CONSULTAGEN
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (24/09/2018)
        //Utilizado por	: WebApi.SIC_CONSULTAGEN.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_URBAMANZA
        /// </summary>
        public ICollection<BE.SIC_CONSULTAGEN> Buscar(BE.SIC_CONSULTAGEN entSIC_URBAMANZA)
        {
            List<BE.SIC_CONSULTAGEN> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CONSULTAGEN> entQuery = new DA.SIC_CONSULTAGEN().Buscar(entSIC_URBAMANZA);
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
        public ICollection<BE.SIC_CONSULTAGEN> BuscarSimple(BE.SIC_CONSULTAGEN entSIC_URBAMANZA)
        {
            List<BE.SIC_CONSULTAGEN> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CONSULTAGEN> entQuery = new DA.SIC_CONSULTAGEN().BuscarSimple(entSIC_URBAMANZA);
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
        //Creado por	: Pedro Peña Salazar (24/09/2018)
        //Utilizado por	: WebApi.SIC_CONSULTAGEN.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CONSULTAGEN
        /// </summary>
        public BE.SIC_CONSULTAGEN BuscarInt(BE.SIC_CONSULTAGEN entSIC_VIA)
        {
            BE.SIC_CONSULTAGEN lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CONSULTAGEN().BuscarInt(entSIC_VIA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        
    }
}
