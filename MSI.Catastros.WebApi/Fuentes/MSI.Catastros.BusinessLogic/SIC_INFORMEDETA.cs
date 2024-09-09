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
    public class SIC_INFORMEDETA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (13/07/2018)
        //Utilizado por	: WebApi.SIC_INFORMEDETA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMEDETA
        /// </summary>
        public ICollection<BE.SIC_INFORMEDETA> Buscar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            List<BE.SIC_INFORMEDETA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_INFORMEDETA> entQuery = new DA.SIC_INFORMEDETA().Buscar(entSIC_INFORMEDETA);
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
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMEDETA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_INFORMEDETA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORMEDETA().Grabar(entSIC_INFORMEDETA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMEDETA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_INFORMEDETA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORMEDETA().Actualizar(entSIC_INFORMEDETA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMEDETA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMEDETA
        /// </summary>
        public BE.SIC_INFORMEDETA Recuperar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_INFORMEDETA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_INFORMEDETA().Recuperar(entSIC_INFORMEDETA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña  Salazar (11/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMEDETA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_INFORMEDETA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORMEDETA().Eliminar(entSIC_INFORMEDETA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public ICollection<BE.SIC_INFORMEDETA> Listar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            List<BE.SIC_INFORMEDETA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_INFORMEDETA> entQuery = new DA.SIC_INFORMEDETA().Listar(entSIC_INFORMEDETA);
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
