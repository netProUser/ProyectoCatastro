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
    public class SIC_CERTIFIRECI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: WebApi.SIC_CERTIFIRECI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIRECI
        /// </summary>
        public ICollection<BE.SIC_CERTIFIRECI> Buscar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            List<BE.SIC_CERTIFIRECI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CERTIFIRECI> entQuery = new DA.SIC_CERTIFIRECI().Buscar(entSIC_CERTIFIRECI);
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
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: WebApi.SIC_CERTIFIRECI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CERTIFIRECI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFIRECI().Grabar(entSIC_CERTIFIRECI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: WebApi.SIC_CERTIFIRECI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CERTIFIRECI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFIRECI().Actualizar(entSIC_CERTIFIRECI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: WebApi.SIC_CERTIFIRECI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIRECI
        /// </summary>
        public BE.SIC_CERTIFIRECI Recuperar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_CERTIFIRECI lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CERTIFIRECI().Recuperar(entSIC_CERTIFIRECI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_RETORNO Eliminar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFIRECI().Eliminar(entSIC_CERTIFIRECI);
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
