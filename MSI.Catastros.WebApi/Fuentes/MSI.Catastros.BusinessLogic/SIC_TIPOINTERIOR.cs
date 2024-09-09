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
    public class SIC_TIPOINTERIOR
    {
        public ICollection<BE.SIC_TIPOINTERIOR> Listar()
        {
            List<BE.SIC_TIPOINTERIOR> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TIPOINTERIOR> entQuery = new DA.SIC_TIPOINTERIOR().Listar();
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
        public ICollection<BE.SIC_TIPOINTERIOR> Buscar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            List<BE.SIC_TIPOINTERIOR> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TIPOINTERIOR> entQuery = new DA.SIC_TIPOINTERIOR().Buscar(entSIC_TIPOINTERIOR);
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
        public BE.SIC_TIPOINTERIOR BuscarInt(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_TIPOINTERIOR lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TIPOINTERIOR().BuscarInt(entSIC_TIPOINTERIOR);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_TIPOINTERIOR Recuperar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_TIPOINTERIOR lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TIPOINTERIOR().Recuperar(entSIC_TIPOINTERIOR);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_TIPOINTERIOR().Grabar(entSIC_TIPOINTERIOR);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_TIPOINTERIOR().Actualizar(entSIC_TIPOINTERIOR);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Eliminar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_TIPOINTERIOR().Eliminar(entSIC_TIPOINTERIOR);
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
