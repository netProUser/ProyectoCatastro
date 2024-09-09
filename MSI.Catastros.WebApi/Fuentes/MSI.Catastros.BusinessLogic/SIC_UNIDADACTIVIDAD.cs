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
    public class SIC_UNIDADACTIVIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADACTIVIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADACTIVIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADACTIVIDAD().Grabar(entSIC_UNIDADACTIVIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADACTIVIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADACTIVIDAD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADACTIVIDAD().Actualizar(entSIC_UNIDADACTIVIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADACTIVIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADACTIVIDAD
        /// </summary>
        public BE.SIC_UNIDADACTIVIDAD Recuperar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_UNIDADACTIVIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADACTIVIDAD().Recuperar(entSIC_UNIDADACTIVIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADACTIVIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADACTIVIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADACTIVIDAD().Eliminar(entSIC_UNIDADACTIVIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (06/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADACTIVIDAD.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADACTIVIDAD
        /// </summary>
        public ICollection<BE.SIC_UNIDADACTIVIDAD> Listar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            List<BE.SIC_UNIDADACTIVIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADACTIVIDAD> entQuery = new DA.SIC_UNIDADACTIVIDAD().Listar(entSIC_UNIDADACTIVIDAD);
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
        
        public ICollection<BE.SIC_UNIDADACTIVIDAD> CargarUnidadActividadEconomicaHistoricas(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            List<BE.SIC_UNIDADACTIVIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADACTIVIDAD> entQuery = new DA.SIC_UNIDADACTIVIDAD().CargarUnidadActividadEconomicaHistoricas(entSIC_UNIDADACTIVIDAD);
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
    }
}
