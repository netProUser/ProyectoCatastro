using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;

namespace MSI.Catastros.BusinessLogic
{
    public class SIC_DETAFILESERVER
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (04/10/2018)
        //Utilizado por	: WebApi.SIC_DETAFILESERVER.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_DETAFILESERVER
        /// </summary>
        public ICollection<BE.SIC_DETAFILESERVER> Recuperar(BE.SIC_DETAFILESERVER entSIC_DETAFILESERVER)
        {
            List<BE.SIC_DETAFILESERVER> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_DETAFILESERVER> entQuery = new DA.SIC_DETAFILESERVER().Recuperar(entSIC_DETAFILESERVER);
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
        //Creado por	: Eistein Dolores Tarazona (04/10/2018)
        //Utilizado por	: WebApi.SIC_DETAFILESERVER.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_DETAFILESERVER, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_DETAFILESERVER entSIC_DETAFILESERVER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_DETAFILESERVER().Grabar(entSIC_DETAFILESERVER);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (21/11/2018)
        //Utilizado por	: WebApi.SIC_DETAFILESERVER.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_DETAFILESERVER
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_DETAFILESERVER entSIC_DETAFILESERVER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_DETAFILESERVER().Actualizar(entSIC_DETAFILESERVER);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
    }
}
