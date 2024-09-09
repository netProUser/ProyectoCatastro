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
    public class SIC_CERTIFIDETA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/07/2018)
        //Utilizado por	: WebApi.SIC_CERTIFIDETA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public ICollection<BE.SIC_CERTIFIDETA> Buscar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            List<BE.SIC_CERTIFIDETA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CERTIFIDETA> entQuery = new DA.SIC_CERTIFIDETA().Buscar(entSIC_CERTIFIDETA);
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

        public ICollection<BE.SIC_CERTIFIDETA> BuscarCertificados(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            List<BE.SIC_CERTIFIDETA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CERTIFIDETA> entQuery = new DA.SIC_CERTIFIDETA().BuscarCertificados(entSIC_CERTIFIDETA);
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
        //Utilizado por	: WebApi.SIC_CERTIFIDETA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CERTIFIDETA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFIDETA().Grabar(entSIC_CERTIFIDETA);
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
        //Utilizado por	: WebApi.SIC_CERTIFIDETA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFIDETA().Actualizar(entSIC_CERTIFIDETA);
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
        //Utilizado por	: WebApi.SIC_CERTIFIDETA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public BE.SIC_CERTIFIDETA Recuperar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_CERTIFIDETA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CERTIFIDETA().Recuperar(entSIC_CERTIFIDETA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_RETORNO Eliminar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFIDETA().Eliminar(entSIC_CERTIFIDETA);
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
