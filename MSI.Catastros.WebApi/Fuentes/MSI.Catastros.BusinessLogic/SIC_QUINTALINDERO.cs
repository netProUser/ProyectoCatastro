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
    public class SIC_QUINTALINDERO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/08/2018)
        //Utilizado por	: WebApi.SIC_QUINTALINDERO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_QUINTALINDERO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_QUINTALINDERO().Grabar(entSIC_QUINTALINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/08/2018)
        //Utilizado por	: WebApi.SIC_QUINTALINDERO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_QUINTALINDERO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_QUINTALINDERO().Actualizar(entSIC_QUINTALINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/08/2018)
        //Utilizado por	: WebApi.SIC_QUINTALINDERO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_QUINTALINDERO
        /// </summary>
        public BE.SIC_QUINTALINDERO Recuperar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_QUINTALINDERO lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_QUINTALINDERO().Recuperar(entSIC_QUINTALINDERO);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/08/2018)
        //Utilizado por	: WebApi.SIC_QUINTALINDERO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_QUINTALINDERO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_QUINTALINDERO().Eliminar(entSIC_QUINTALINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/08/2018)
        //Utilizado por	: WebApi.SIC_QUINTALINDERO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_QUINTALINDERO
        /// </summary>
        public ICollection<BE.SIC_QUINTALINDERO> Buscar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_QUINTALINDERO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_QUINTALINDERO> entQuery = new DA.SIC_QUINTALINDERO().Buscar(entSIC_QUINTALINDERO);
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
        public BE.SIC_QUINTALINDERO BuscarLinderoDetalle(BE.SIC_QUINTALINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_QUINTALINDERO lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_QUINTALINDERO().BuscarLinderoDetalle(entSIC_LOTELINDERO);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public ICollection<BE.SIC_QUINTALINDERO> BuscarHistoricoLoteLinderos(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_QUINTALINDERO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_QUINTALINDERO> entQuery = new DA.SIC_QUINTALINDERO().BuscarHistoricoLoteLinderos(entSIC_QUINTALINDERO);
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
        public ICollection<BE.SIC_QUINTALINDERO> BuscarLinderosUnidad(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_QUINTALINDERO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_QUINTALINDERO> entQuery = new DA.SIC_QUINTALINDERO().BuscarLinderosUnidad(entSIC_QUINTALINDERO);
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
        public BE.SIC_RETORNO EliminarLinderoUnidad(BE.SIC_QUINTALINDERO entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_QUINTALINDERO().EliminarLinderoUnidad(entSIC_LOTELINDEROVIADET);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarDetalleLindero(BE.SIC_QUINTALINDERO entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_QUINTALINDERO().EliminarDetalleLindero(entSIC_LOTELINDERODET);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO GrabarUnidadLinderoDetalle(BE.SIC_QUINTALINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_QUINTALINDERO().GrabarUnidadLinderoDetalle(entSIC_LOTELINDERO);
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
