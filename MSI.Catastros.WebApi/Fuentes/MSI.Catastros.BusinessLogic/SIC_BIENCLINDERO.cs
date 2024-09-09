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
    public class SIC_BIENCLINDERO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: WebApi.SIC_BIENCLINDERO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_BIENCLINDERO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_BIENCLINDERO().Grabar(entSIC_BIENCLINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: WebApi.SIC_BIENCLINDERO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_BIENCLINDERO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_BIENCLINDERO().Actualizar(entSIC_BIENCLINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: WebApi.SIC_BIENCLINDERO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_BIENCLINDERO
        /// </summary>
        public BE.SIC_BIENCLINDERO Recuperar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_BIENCLINDERO lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_BIENCLINDERO().Recuperar(entSIC_BIENCLINDERO);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: WebApi.SIC_BIENCLINDERO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_BIENCLINDERO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_BIENCLINDERO().Eliminar(entSIC_BIENCLINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: WebApi.SIC_BIENCLINDERO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_BIENCLINDERO
        /// </summary>
        public ICollection<BE.SIC_BIENCLINDERO> Buscar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            List<BE.SIC_BIENCLINDERO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_BIENCLINDERO> entQuery = new DA.SIC_BIENCLINDERO().Buscar(entSIC_BIENCLINDERO);
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
        //Creado por	: AA (29/08/2018)
        //Utilizado por	: WebApi.SIC_BIENCLINDERO.BuscarEdif
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar las Edificaciones de la tabla SIC_UNIDAD
        /// </summary>
        public ICollection<BE.SIC_UNIDAD> ListarEdif(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_BIENCLINDERO().ListarEdif(entSIC_UNIDAD);
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
        //Creado por	: AA (29/08/2018)
        //Utilizado por	: WebApi.SIC_BIENCLINDERO.BuscarUnidad
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar las Unidades de la tabla SIC_UNIDAD
        /// </summary>
        public ICollection<BE.SIC_UNIDAD> ListarUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_BIENCLINDERO().ListarUnidad(entSIC_UNIDAD);
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
        public BE.SIC_BIENCLINDERO BuscarLinderoDetalle(BE.SIC_BIENCLINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_BIENCLINDERO lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_BIENCLINDERO().BuscarLinderoDetalle(entSIC_LOTELINDERO);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public ICollection<BE.SIC_BIENCLINDERO> BuscarLinderoC(BE.SIC_BIENCLINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_BIENCLINDERO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_BIENCLINDERO> entQuery = new DA.SIC_BIENCLINDERO().BuscarLinderoC(entSIC_QUINTALINDERO);
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
        public ICollection<BE.SIC_BIENCLINDERO> BuscarLinderosUnidad(BE.SIC_BIENCLINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_BIENCLINDERO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_BIENCLINDERO> entQuery = new DA.SIC_BIENCLINDERO().BuscarLinderosUnidad(entSIC_QUINTALINDERO);
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
        public BE.SIC_RETORNO EliminarLinderoUnidad(BE.SIC_BIENCLINDERO entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_BIENCLINDERO().EliminarLinderoUnidad(entSIC_LOTELINDEROVIADET);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarDetalleLindero(BE.SIC_BIENCLINDERO entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_BIENCLINDERO().EliminarDetalleLindero(entSIC_LOTELINDERODET);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO GrabarUnidadLinderoDetalle(BE.SIC_BIENCLINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_BIENCLINDERO().GrabarUnidadLinderoDetalle(entSIC_LOTELINDERO);
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
