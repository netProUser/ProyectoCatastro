﻿using System;
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
    public class SIC_TIPOPROCINSPACT
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: WebApi.SIC_TIPOPROCINSPACT.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPOPROCINSPACT
        /// </summary>
        public ICollection<BE.SIC_TIPOPROCINSPACT> Listar(BE.SIC_TIPOPROCINSPACT entSIC_TIPOPROCINSPACT)
        {
            List<BE.SIC_TIPOPROCINSPACT> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TIPOPROCINSPACT> entQuery = new DA.SIC_TIPOPROCINSPACT().Listar(entSIC_TIPOPROCINSPACT);
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
