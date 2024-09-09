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
    public class SIC_USOCLAS
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (09/07/2018)
        //Utilizado por	: WebApi.SIC_USOCLAS.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USOCLAS
        /// </summary>
        public ICollection<BE.SIC_USOCLAS> Listar()
        {
            List<BE.SIC_USOCLAS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_USOCLAS> entQuery = new DA.SIC_USOCLAS().Listar();
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
        public ICollection<BE.SIC_USOCLAS> Buscar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            List<BE.SIC_USOCLAS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_USOCLAS> entQuery = new DA.SIC_USOCLAS().Buscar(entSIC_USOCLAS);
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
        public BE.SIC_USOCLAS BuscarInt(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_USOCLAS lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_USOCLAS().BuscarInt(entSIC_USOCLAS);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_USOCLAS Recuperar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_USOCLAS lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_USOCLAS().Recuperar(entSIC_USOCLAS);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_USOCLAS().Grabar(entSIC_USOCLAS);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_USOCLAS().Actualizar(entSIC_USOCLAS);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Eliminar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_USOCLAS().Eliminar(entSIC_USOCLAS);
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
