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
    public class SIC_EDIFICACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: WebApi.SIC_EDIFICACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_EDIFICACION
        /// </summary>
        public ICollection<BE.SIC_EDIFICACION> Listar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            List<BE.SIC_EDIFICACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_EDIFICACION> entQuery = new DA.SIC_EDIFICACION().Listar(entSIC_EDIFICACION);
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

        public ICollection<BE.SIC_EDIFICACION> Buscar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            List<BE.SIC_EDIFICACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_EDIFICACION> entQuery = new DA.SIC_EDIFICACION().Buscar(entSIC_EDIFICACION);
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
        public BE.SIC_EDIFICACION BuscarInt(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_EDIFICACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_EDIFICACION().BuscarInt(entSIC_EDIFICACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_EDIFICACION Recuperar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_EDIFICACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_EDIFICACION().Recuperar(entSIC_EDIFICACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_EDIFICACION().Grabar(entSIC_EDIFICACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_EDIFICACION().Actualizar(entSIC_EDIFICACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Eliminar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_EDIFICACION().Eliminar(entSIC_EDIFICACION);
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
