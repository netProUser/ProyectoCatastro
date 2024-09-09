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
    public class SIC_USOGENE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (09/07/2018)
        //Utilizado por	: WebApi.SIC_USOESPE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USOESPE
        /// </summary>
        public ICollection<BE.SIC_USOGENE> Listar()
        {
            List<BE.SIC_USOGENE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_USOGENE> entQuery = new DA.SIC_USOGENE().Listar();
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
        public ICollection<BE.SIC_USOGENE> Buscar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            List<BE.SIC_USOGENE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_USOGENE> entQuery = new DA.SIC_USOGENE().Buscar(entSIC_USOGENE);
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
        public BE.SIC_USOGENE BuscarInt(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_USOGENE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_USOGENE().BuscarInt(entSIC_USOGENE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_USOGENE Recuperar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_USOGENE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_USOGENE().Recuperar(entSIC_USOGENE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_USOGENE().Grabar(entSIC_USOGENE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_USOGENE().Actualizar(entSIC_USOGENE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Eliminar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_USOGENE().Eliminar(entSIC_USOGENE);
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
