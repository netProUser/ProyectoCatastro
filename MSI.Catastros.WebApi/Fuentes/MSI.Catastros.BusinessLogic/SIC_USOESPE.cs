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
    public class SIC_USOESPE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (09/07/2018)
        //Utilizado por	: WebApi.SIC_USOESPE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USOESPE
        /// </summary>
        public ICollection<BE.SIC_USOESPE> Listar()
        {
            List<BE.SIC_USOESPE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_USOESPE> entQuery = new DA.SIC_USOESPE().Listar();
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
        public ICollection<BE.SIC_USOESPE> Buscar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            List<BE.SIC_USOESPE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_USOESPE> entQuery = new DA.SIC_USOESPE().Buscar(entSIC_USOESPE);
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
        public BE.SIC_USOESPE BuscarInt(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_USOESPE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_USOESPE().BuscarInt(entSIC_USOESPE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_USOESPE Recuperar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_USOESPE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_USOESPE().Recuperar(entSIC_USOESPE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_USOESPE().Grabar(entSIC_USOESPE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_USOESPE().Actualizar(entSIC_USOESPE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Eliminar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_USOESPE().Eliminar(entSIC_USOESPE);
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
