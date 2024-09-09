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
    public class SIC_USUCARCAT
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_USUCARCAT.InspectoresLis
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USUCARCAT
        /// </summary>
        public ICollection<BE.SIC_USUCARCAT> InspectoresLis()
        {
            List<BE.SIC_USUCARCAT> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_USUCARCAT> entQuery = new DA.SIC_USUCARCAT().InspectoresLis(new BE.SIC_USUCARCAT() {CODCARCAT = "02" });
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

        public BE.SIC_USUCARCAT Recuperar(BE.SIC_USUCARCAT entUSUCARCAT)
        {
            BE.SIC_USUCARCAT lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_USUCARCAT().Recuperar(entUSUCARCAT);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
    }
}
