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
    public class SIC_PUERTA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: WebApi.SIC_PUERTA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PUERTA
        /// </summary>
        public ICollection<BE.SIC_PUERTA> Listar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            List<BE.SIC_PUERTA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PUERTA> entQuery = new DA.SIC_PUERTA().Listar(entSIC_PUERTA);
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
        public ICollection<BE.SIC_PUERTA> Buscar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            List<BE.SIC_PUERTA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PUERTA> entQuery = new DA.SIC_PUERTA().Buscar(entSIC_PUERTA);
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
        public BE.SIC_PUERTA BuscarInt(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_PUERTA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_PUERTA().BuscarInt(entSIC_PUERTA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_PUERTA Recuperar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_PUERTA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_PUERTA().Recuperar(entSIC_PUERTA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_PUERTA().Grabar(entSIC_PUERTA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_PUERTA().Actualizar(entSIC_PUERTA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Eliminar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_PUERTA().Eliminar(entSIC_PUERTA);
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
