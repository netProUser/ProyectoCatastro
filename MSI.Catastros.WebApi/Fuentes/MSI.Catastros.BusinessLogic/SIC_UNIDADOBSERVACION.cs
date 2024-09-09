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
    public class SIC_UNIDADOBSERVACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADOBSERVACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADOBSERVACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADOBSERVACION().Grabar(entSIC_UNIDADOBSERVACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADOBSERVACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADOBSERVACION().Actualizar(entSIC_UNIDADOBSERVACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADOBSERVACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public BE.SIC_UNIDADOBSERVACION Recuperar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_UNIDADOBSERVACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADOBSERVACION().Recuperar(entSIC_UNIDADOBSERVACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADOBSERVACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADOBSERVACION().Eliminar(entSIC_UNIDADOBSERVACION);
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
        //Utilizado por	: WebApi.SIC_UNIDADOBSERVACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public ICollection<BE.SIC_UNIDADOBSERVACION> Listar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADACTIVIDAD)
        {
            List<BE.SIC_UNIDADOBSERVACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADOBSERVACION> entQuery = new DA.SIC_UNIDADOBSERVACION().Listar(entSIC_UNIDADACTIVIDAD);
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
        
        public ICollection<BE.SIC_UNIDADOBSERVACION> BuscarHistoricoObservacion(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADACTIVIDAD)
        {
            List<BE.SIC_UNIDADOBSERVACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADOBSERVACION> entQuery = new DA.SIC_UNIDADOBSERVACION().BuscarHistoricoObservacion(entSIC_UNIDADACTIVIDAD);
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
